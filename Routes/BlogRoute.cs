using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudApiBlogs.Data;
using CrudApiBlogs.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiBlogs.Routes
{
    public static class BlogRoute
    {
        public static void BlogRoutes(this WebApplication app)
        {
            var route = app.MapGroup("blog");

            route.MapPost("", async (BlogRequest req, BlogDbContext context) => 
            {
                var blog = new BlogModel(req.NomeUsusario, req.Titulo, req.Conteudo);
                await context.AddAsync(blog);
                await context.SaveChangesAsync();
            });

            route.MapGet("", async (BlogDbContext context) => 
            {
                var blogs = await context.Blogs.ToListAsync();
                return Results.Ok(blogs);
            });

            route.MapGet("{id:guid}", async (Guid id, BlogDbContext context) => 
            {
                var blog = await context.Blogs.FindAsync(id);

                if (blog == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(blog);
            });

            route.MapPut("{id:guid}", async (Guid id, BlogRequest req, BlogDbContext context) => 
            {
                var blog = await context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

                if (blog == null)
                {
                    return Results.NotFound();
                }

                blog.EditarBlog(req.Titulo, req.Conteudo);

                await context.SaveChangesAsync();
                return Results.Ok(blog);
            });

            route.MapDelete("{id:guid}", async (Guid id, BlogDbContext context) => 
            {
                var blog = await context.Blogs.FirstOrDefaultAsync(x => x.Id == id);

                if (blog == null)
                {
                    return Results.NotFound();
                }

                blog.DeletarBlog();
                await context.SaveChangesAsync();
                return Results.Ok(blog);
            });
        }
    }
}