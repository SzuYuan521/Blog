using Blog.Applications.ArticleService;
using Blog.Applications.Auth;
using Blog.Middlewares;
using Blog.DbAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

//此網站服務(Service)，註冊(添加)MVC這個功能
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

 //註冊客製化介面
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index/id?}"); //啟動MVC路由功能, 傳入的網址=pattern

app.Run();
