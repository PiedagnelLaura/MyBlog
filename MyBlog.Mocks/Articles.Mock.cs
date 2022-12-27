using MyBlog.Models;

namespace MyBlog.Mocks
{
    public static class ArticlesMock
    {
        public static List<ArticlesModel> listArticles = new List<ArticlesModel>
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
        };
    }
}