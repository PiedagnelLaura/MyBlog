using Microsoft.EntityFrameworkCore;
using MyBlog.Models;
using MyBlog.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Repository.DAL
{
    public class ArticlesPublicDAL
    {
        private readonly DbBlogContext _context;
        public ArticlesPublicDAL(DbBlogContext context)
        {
            _context= context;
        }

        /// <summary>
        /// Return article with id and if available
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public async Task<ArticleModel> GetArticle (int id)
       {
            var articleModel = await _context.Articles.FirstOrDefaultAsync(article => article.Id == id && article.Available);

            return articleModel;
       }

       public async Task<List<ArticleModel>> GetAllArticle()
       {
            return await _context.Articles.Where(article => article.Available).ToListAsync();
       }
    }
}
