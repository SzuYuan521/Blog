// 新增、編輯文章的前端資料會透過UpdateArticleViewModel.cs進行傳送

namespace Blog.ViewModels.ArticleService
{
    public class UpdateArticleViewModel
    {
        public long Id { get; set; }        
        public string Title { get; set; }      
        public string ArticleContent { get; set; } = string.Empty;
        public bool IsDelete { get; set; }
    }
}
