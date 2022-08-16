using Microsoft.Extensions.Options;

namespace core
{
    public class FruitMiddleware
    {
        private RequestDelegate _next;
        private FruitOptions _fruitOptions;

        public FruitMiddleware(RequestDelegate next, IOptions<FruitOptions> fruitOptions)
        {
            _next = next;
            _fruitOptions = fruitOptions.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/fruit")
            {
                await context.Response.WriteAsync($"{_fruitOptions.Name}, {_fruitOptions.color}");
            }

            else
            {
                await _next(context);
            }
        }
    }
}
