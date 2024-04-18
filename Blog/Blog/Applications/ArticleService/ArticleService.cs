using Blog.DbAccess;
using Blog.Models;
using Blog.ViewModels.ArticleService;
using Microsoft.EntityFrameworkCore;

namespace Blog.Applications.ArticleService
{
    public class ArticleService : IArticleService
    {
        private readonly ApplicationDbContext _db;
        public ArticleService(ApplicationDbContext db) 
        {
            _db = db;
        }

        public async Task CreateArticle(UpdateArticleViewModel model)
        {
            var article = new Article
            {
                Title = model.Title,
                ArticleContent = model.ArticleContent,
                IsDelete = model.IsDelete
            };
            _db.Articles.Add(article); //新增Article至資料庫
            await _db.SaveChangesAsync(); //更新資料表資料
        }

        public async Task<ImageUploadResponse> UploadImage(IFormFile upload)
        {
            if (upload.Length <= 0) return null!;
            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var stream = File.Create(filePath))
            {
                //圖片存入本地的資料夾裡面
                await upload.CopyToAsync(stream);
            }

            var url = $"{"/images/"}{fileName}";
            var result = new ImageUploadResponse
            {
                Uploaded = 1,
                FileName = fileName,
                Url = url,
                Msg = "success",
            };

            return result;
        }

        public async Task UpdateArticle(UpdateArticleViewModel model)
        {
            var data = await _db.Articles
                .Where(x => x.Id == model.Id)
                .FirstOrDefaultAsync();
            if (data == null)
            {
                throw new Exception("Search fail");
            }

            data.Title = model.Title;
            data.ArticleContent = model.ArticleContent;
            data.IsDelete = model.IsDelete;

            _db.Articles.Update(data);
            await _db.SaveChangesAsync();

        }

        // 從資料庫中檢索所有未刪除的文章，並映射為 ArticleViewModel
        // 返回一個包含所有符合條件的文章的集合
        public async Task<IList<ArticleViewModel>> GetListArticle()
        {
            
            return await _db.Articles
                .Where(x => x.IsDelete == false)    // 從ApplicationDbContext中選擇所有未刪除的文章
                .Select(x => new ArticleViewModel   // 將文章映射為ArticleViewModel模型
                {
                    Id = x.Id,
                    Title = x.Title,
                    ArticleContent = x.ArticleContent
                })
                .ToListAsync(); // 將查詢結果轉換為 List<ArticleViewModel> 集合並返回
        }


        public async Task<ArticleViewModel> GetArticle(long id)
        {
            var result = await _db.Articles
                .Where(x => x.IsDelete == false && x.Id == id)
                .Select(x => new ArticleViewModel
                {
                    Id = id,
                    ArticleContent = x.ArticleContent,
                    Title = x.Title
                })
                .FirstOrDefaultAsync();
            return result ?? new(); //避免result為null(查詢不到資料)
        }

        public async Task<IList<UpdateArticleViewModel>> GetUpdateArticleList()
        {
            return await _db.Articles
                .Select(x => new UpdateArticleViewModel
                {
                    Id = x.Id,
                    IsDelete = x.IsDelete,
                    Title = x.Title,
                    ArticleContent = x.ArticleContent
                })
                .ToListAsync();
        }

        public Task<UpdateArticleViewModel> GetUpdateArticle(long id)
        {
            var data = _db.Articles
                .Where(x => x.Id == id)
                .Select(x => new UpdateArticleViewModel
                {
                    Id = x.Id,
                    IsDelete = x.IsDelete,
                    Title = x.Title,
                    ArticleContent = x.ArticleContent
                })
                .FirstOrDefaultAsync();
            if(data == null)
            {
                throw new Exception("Search fail");
            }
            return data;
        }

        public async Task DeleteArticle(long id)
        {
            var data = await _db.Articles
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if(data != null)
            {
                _db.Remove(data);
                await _db.SaveChangesAsync();
            }
        }
    }
}