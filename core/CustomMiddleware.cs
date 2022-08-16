namespace core
{

    /**
     * This is one of custom middleware just created.
     * This is a class based middleware.
     */

    public class CustomMiddleware
    {
        private RequestDelegate _next;

        public CustomMiddleware()
        {
        }

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /**
         * This Invoke() method calls by ASP .NET when a request is received, and it receives a httpContext object 
         * that provides access of request and response.
         */
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }

                await context.Response.WriteAsync("Class based custom Middleware \n");
            }

            if (_next != null)
            {
                await _next(context);
            }
        }
    }

    // Here I wrote the details version the custom middleware class to use it directly from program.cs file. 
    // This is an extension middleware class
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
