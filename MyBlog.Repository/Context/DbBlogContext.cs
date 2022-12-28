using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.Context
{
    public class DbBlogContext : DbContext
    {
        public DbBlogContext(DbContextOptions<DbBlogContext> options)
          : base(options)
        {
        }

        public DbSet<ArticlesModel> Articles { get; set; }
    }
}
