using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBlog.Models;

namespace MyBlog.Data
{
    public class MyBlogContext : DbContext
    {
        public MyBlogContext (DbContextOptions<MyBlogContext> options)
            : base(options)
        {
        }

        public DbSet<MyBlog.Models.ArticlesModel> Articles { get; set; } = default!;
    }
}
