using core.Services;

namespace core
{
    public class HtmlFormatterMiddleware
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;

        public HtmlFormatterMiddleware(RequestDelegate next, IResponseFormatter formatter)
        {
            _next = next;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/formatter_1")
            {
                await _formatter.Format(context, "Formatter_1 from Formatter Middleware");
            }
            else
            {
                await _next(context);
            }
        }


    }
}
