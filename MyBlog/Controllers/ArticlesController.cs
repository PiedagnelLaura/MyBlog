using Microsoft.AspNetCore.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            // Créer une liste d'article EN DUR
            var vm = new ArticlesViewModel
            {
                Articles = new List<ArticlesModel>
                {
                    new ArticlesModel
                    {
                        Id = 0,
                        Title = "Les objets connectés en 2022",
                        Content = "...",
                        Available= true,
                    } ,
                    new ArticlesModel
                    {
                        Id = 1,
                        Title = "Les objets connectés en 2023",
                        Content = "...",
                        Available= true,
                    } ,
                    new ArticlesModel
                    {
                        Id = 2,
                        Title = "Les objets connectés en 2024",
                        Content = "...",
                        Available= false,
                    } ,
                }
            };

            //Chercher les articles ou tu veux
            //Transforme en données pour ta vue (ici en viewModel)

            return View(vm);
        }
    }
}
