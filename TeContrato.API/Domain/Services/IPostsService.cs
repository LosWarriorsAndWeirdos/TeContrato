using System.Collections.Generic;
using System.Threading.Tasks;
using TeContrato.API.Domain.Models;
using TeContrato.API.Domain.Services.Communications;

namespace TeContrato.API.Domain.Services
{
    public interface IPostService
    {
        Task<IEnumerable<Posts>> ListAsync();
        Task<PostsResponse> GetByIdAsync(int id);
        Task<PostsResponse> SaveAsync(int userId, Posts posts);
        Task<PostsResponse> UpdateAsync(int id, Posts posts);
        Task<PostsResponse> DeleteAsync(int id);
    }
}