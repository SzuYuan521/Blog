var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //此網站服務(Service)，註冊(添加)MVC這個功能
var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index/id?}"); //啟動MVC路由功能, 傳入的網址=pattern

app.Run();
