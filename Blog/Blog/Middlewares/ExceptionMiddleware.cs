namespace Blog.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                //繼續將Reguest向Controller傳入
                await _next(context);
            }
            catch(Exception ex)
            {
                //將錯誤顯示在畫面上
                await context.Response.WriteAsync($"[{GetType().Name}] Error Message: {ex.Message}");
            }
        }
    }
}
