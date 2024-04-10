using Blog.Applications.ArticleService;
using Blog.Applications.Auth;

var builder = WebApplication.CreateBuilder(args);

//�������A��(Service)�A���U(�K�[)MVC�o�ӥ\��
builder.Services.AddControllersWithViews();

 //���U�Ȼs�Ƥ���
builder.Services.AddTransient<IArticleService, ArticleService>();
builder.Services.AddTransient<IAuthService, AuthService>();

var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index/id?}"); //�Ұ�MVC���ѥ\��, �ǤJ�����}=pattern

app.Run();
