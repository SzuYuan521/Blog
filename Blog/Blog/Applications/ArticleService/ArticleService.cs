using Blog.ViewModels.ArticleService;

namespace Blog.Applications.ArticleService
{
    public class ArticleService : IArticleService
    {
        //  private readonly ApplicationDbContext _db;
        //  public ArticleService(ApplicationDbContext db) { }

        public Task CreateArticle(UpdateArticleViewModel model)
        {
            return null;
        }

        public Task<ImageUploadResponse> UploadImage(IFormFile upload)
        {
            return null;
        }

        public Task UpdateArticle(UpdateArticleViewModel model)
        {
            return null;
        }


        public Task<IList<ArticleViewModel>> GetListArticle()
        {
            return null;
        }


        public Task<ArticleViewModel> GetArticle(long id)
        {
            return null;
        }

        public Task<IList<ArticleViewModel>> GetUpdateArticleList()
        {
            return null;
        }

        public Task<UpdateArticleViewModel> GetUpdateArticle(long id)
        {
            return null;
        }
    }
}