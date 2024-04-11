using Blog.Applications.ArticleService;
using Blog.Applications.Auth;
using Blog.Middlewares;
using Blog.DbAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var configurations = builder.Configuration;

//�������A��(Service)�A���U(�K�[)MVC�o�ӥ\��
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(configurations.GetConnectionString("DbString")));

 //���U�Ȼs�Ƥ���
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index/id?}"); //�Ұ�MVC���ѥ\��, �ǤJ�����}=pattern

app.Run();
