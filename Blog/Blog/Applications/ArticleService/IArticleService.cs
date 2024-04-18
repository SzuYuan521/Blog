using Blog.ViewModels.ArticleService;

namespace Blog.Applications.ArticleService
{
    public interface IArticleService
    {
        /// <summary>
        /// 新增文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task CreateArticle(UpdateArticleViewModel model);

        /// <summary>
        /// CKEditor上傳圖片
        /// </summary>
        /// <param name="upload"></param>
        /// <returns></returns>
        Task<ImageUploadResponse> UploadImage(IFormFile upload);

        /// <summary>
        /// 編輯文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task UpdateArticle(UpdateArticleViewModel model);

        /// <summary>
        /// 查詢文章列表
        /// </summary>
        /// <returns></returns>
        Task<IList<ArticleViewModel>> GetListArticle();

        /// <summary>
        /// 查詢文章內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArticleViewModel> GetArticle(long id);

        /// <summary>
        /// 取得需要編輯的文章列表
        /// </summary>
        /// <returns></returns>
        Task<IList<UpdateArticleViewModel>> GetUpdateArticleList();

        /// <summary>
        /// 取得需要編輯的文章內容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UpdateArticleViewModel> GetUpdateArticle(long id);

        /// <summary>
        /// 刪除文章
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteArticle(long id);
    }
}
