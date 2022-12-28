using Microsoft.AspNetCore.Mvc;
using MyBlog.Mocks;
using MyBlog.Models;
using MyBlog.Repository.Context;
using MyBlog.Repository.DAL;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class ArticlesController : Controller
    {
      
        private readonly ArticlesPublicDAL _articlesPublicRepository;
        public ArticlesController(ArticlesPublicDAL articlesPublicRepository)
        {
            _articlesPublicRepository = articlesPublicRepository;
        }
        public async Task<IActionResult> Index()
        {
            
            var vm = new ArticlesViewModel
            {
                Articles = await _articlesPublicRepository.GetAllArticle()
            };

            return View(vm);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var articlesModel = await _articlesPublicRepository.GetArticle(id.Value);

            if (articlesModel == null || !articlesModel.Available)
            {
                return NotFound();
            }

            return View(articlesModel);
        }
    }
}
