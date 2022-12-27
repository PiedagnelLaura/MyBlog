namespace MyBlog.Models
{

    //Une classe identique à ma table en bdd
    public class ArticlesModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Available { get; set; }
    }
}