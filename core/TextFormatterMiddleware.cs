using core.Services;

namespace core
{
    public class TextFormatterMiddleware
    {
        private RequestDelegate _next;
        private IResponseFormatter _formatter;

        public TextFormatterMiddleware(RequestDelegate next, IResponseFormatter formatter)
        {
            _next = next;
            _formatter = formatter;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/formatter_2")
            {
                await _formatter.Format(context, "Formatter Middleware in text version.");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
