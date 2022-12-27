using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
