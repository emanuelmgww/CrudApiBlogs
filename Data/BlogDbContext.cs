using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApiBlogs.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiBlogs.Data
{
    public class BlogDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public BlogDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<BlogModel> Blogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var stringConection = _configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(stringConection);
        }
    }
}