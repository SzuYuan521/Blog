using Blog.Applications.ArticleService;
using Blog.ViewModels.ArticleService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet("Article/{id}")] //文章首頁
        public async Task<IActionResult> Index(long id)
        {
            try
            {
                var model = await _articleService.GetArticle(id); //取得文章詳細內容
                if(model != null)
                {
                    return View(model);
                }

                return Redirect("/");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet("CreateArticle")] //新增文章頁Get/Post
        public async Task<IActionResult> CreateArticle(UpdateArticleViewModel model)
        {
            try
            {
                await _articleService.CreateArticle(model); //上傳新增的文章內容

                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpGet("GetArticleList")] //取得文章列表
        public async Task<IActionResult> GetArticleList()
        {
            try
            {
                var model = await _articleService.GetUpdateArticleList(); //取得想要編輯的文章列表
                return View(model);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet("UpdateArticle/{id}")] //取得編輯文章
        public async Task<IActionResult> UpdateArticle(long id)
        {
            try
            {
                var model = await _articleService.GetUpdateArticle(id); //查詢想要編輯的文章內容
                if (model is not null)
                {
                    return View(model);
                }

                return Redirect("/");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(UpdateArticleViewModel model) //上傳文章內容
        {
            await _articleService.UpdateArticle(model);
            return RedirectToAction($"GetArticleList");
        }

        public async Task<IActionResult> Uploads(IFormFile upload) //上傳圖片
        {
            var obj = await _articleService.UploadImage(upload);

            return Json(new
            {
                uploaded = obj.Uploaded,
                fileName = obj.FileName,
                url = obj.Url,
                error = new
                {
                    message = obj.Msg
                }
            });
        }

    }
}
