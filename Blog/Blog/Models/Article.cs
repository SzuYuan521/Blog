namespace Blog.Models
{
    public class Article
    {
        public long Id { get; set; }

        public string Title { get; set; } 
        
        public string ArticleContent {  get; set; }

        public bool IsDelete { get; set; }
    }
}
