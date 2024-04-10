// 查詢出來的文章內容會透過ArticleViewModel.cs傳送前端畫面呈現

namespace Blog.ViewModels.ArticleService
{
    public class ArticleViewModel
    {
        public long Id { get; set; }  
        public string Title { get; set; }
        public string ArticleContent { get; set; } = string.Empty;
    }
}
