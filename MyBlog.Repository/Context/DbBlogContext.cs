using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Context
{
    public class DbBlogContext : IdentityDbContext<MyBlogUser>
    {
        public DbBlogContext(DbContextOptions<DbBlogContext> options)
          : base(options)
        {
        }

        public DbSet<ArticleModel> Articles { get; set; }
    }
}