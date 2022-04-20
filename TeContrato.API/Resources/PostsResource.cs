using System;
using Microsoft.VisualBasic;
using TeContrato.API.Domain.Models;

namespace TeContrato.API.Resources
{
    public class PostsResource
    {
        public int Cposts { get; set; }
        public string Ntitle { get; set; }
        public string Tbody { get; set; }
        public DateTime Created_at { get; set; }
        public int Mbudget { get; set; }
        public int Views { get; set; }
        public int Pic { get; set; }
        
        public int UserId { get; set; }
        public User CUser { get; set; }
    }
}