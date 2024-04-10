using Blog.Applications.ArticleService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); //�������A��(Service)�A���U(�K�[)MVC�o�ӥ\��
builder.Services.AddTransient<IArticleService, ArticleService>(); //���U�Ȼs�Ƥ���

var app = builder.Build();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index/id?}"); //�Ұ�MVC���ѥ\��, �ǤJ�����}=pattern

app.Run();
