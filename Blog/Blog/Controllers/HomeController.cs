using Microsoft.AspNetCore.Mvc;
 
//繼承了Controller就可以接收來自表單的輸入或是Url輸入
namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            try
            {
                // 模擬異步操作，例如從數據庫中讀取數據
                await Task.Delay(100); // 假設這裡是一個耗時的操作

                // 返回一個視圖
                return View();
            }
            catch (Exception ex)
            {
                // 在發生錯誤時處理異常
                // 這裡可以記錄錯誤、顯示錯誤信息給用戶，或者重定向到錯誤頁面
                return RedirectToAction("Error", "Home");
            }
        }
    }
}
