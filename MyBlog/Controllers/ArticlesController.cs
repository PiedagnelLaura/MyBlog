using Microsoft.AspNetCore.Mvc;
using MyBlog.Mocks;
using MyBlog.Models;
using MyBlog.ViewModels;

namespace MyBlog.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            // Créer une liste d'article EN DUR
            var vm = new ArticlesViewModel
            {
                Articles = ArticlesMock.listArticles
            };

            //Chercher les articles ou tu veux
            //Transforme en données pour ta vue (ici en viewModel)

            return View(vm);
        }
    }
}
