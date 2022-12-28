using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.Mocks;
using MyBlog.Models;
using MyBlog.Repository.Context;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly DbBlogContext _dbBlogContext;
        public ArticlesController(DbBlogContext dbBlogContext)
        {
            _dbBlogContext= dbBlogContext;
        }
        public async Task<IActionResult> Index()
        {
            
            var vm = new ArticlesViewModel
            {
                Articles = await _dbBlogContext.Articles.ToListAsync()
            };

            return View(vm);
        }

        /// <summary>
        /// Get the data from the mock to put them in a database
        /// </summary>
        /// <returns>redirect to the article list</returns>
        public async Task<IActionResult> AddDataFromMock() 
        {
            var lstArticlesMock = ArticlesMock.listArticles;
            _dbBlogContext.Articles.AddRange(lstArticlesMock);
            await _dbBlogContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
