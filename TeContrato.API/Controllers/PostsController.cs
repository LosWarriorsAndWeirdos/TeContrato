using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeContrato.API.Extensions;
using Swashbuckle.AspNetCore.Annotations;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services;
using TeContrato.API.Resources;

namespace TeContrato.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;

        public PostsController(IPostService postService, IMapper mapper)
        {
            _postService = postService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "List all Posts")]
        [ProducesResponseType(typeof(IEnumerable<PostsResource>), 200)]
        public async Task<IEnumerable<PostsResource>> GetAllAsync()
        {
            var post = await _postService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Posts>, IEnumerable<PostsResource>>(post);
            return resources;
        }

        [HttpGet("{Cposts}")]
        [SwaggerOperation(Summary = "Get a post by Id")]
        [ProducesResponseType(typeof(PostsResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _postService.GetByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Posts, PostsResource>(result.Resource);
            return Ok(postResource);
        }
        
        [HttpPut("{Cposts}")]
        [SwaggerOperation(Summary = "Update a post by Id")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostsResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var posts = _mapper.Map<SavePostsResource, Posts>(resource);
            var result = await _postService.UpdateAsync(id, posts);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Posts, PostsResource>(result.Resource);

            return Ok(postResource);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a Post")]
        [ProducesResponseType(typeof(PostsResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> PostAsync(int userId,[FromBody] SavePostsResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var post = _mapper.Map<SavePostsResource, Posts>(resource);
            var result = await _postService.SaveAsync(userId, post);

            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Posts, PostsResource>(result.Resource);
            return Ok(postResource);
        }
        
        [HttpDelete("{Cposts}")]
        [SwaggerOperation(Summary = "Delete a Post")]
        [ProducesResponseType(typeof(CityResource), 200)]
        [ProducesResponseType(typeof(BadRequestResult), 404)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var postResource = _mapper.Map<Posts, PostsResource>(result.Resource);
            return Ok(postResource);
        }
    }
}
