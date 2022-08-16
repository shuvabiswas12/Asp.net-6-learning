using core;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<FruitOptions>(options =>
{
    options.Name = "Watermelon";
});


var app = builder.Build();

// Terminal middleware
/** Terminal middleware never forwards the request to another components.
 */
// ((IApplicationBuilder)app).Map("/branch", branch =>
// {
//branch.Use(async (HttpContext context, Func<Task> next) =>
//{
//    await context.Response.WriteAsync("Branch Middleware");
//    // In terminal middleware does not have next() calls, that is why it does not forward to next component.
//});

/** 
 * Here we registering the terminal middleware from the class based middleware
 * for writing this terminal middleware we had to declare a empty construtor inside the CustomMiddleware class
 * file.
*/

//    branch.Run(new CustomMiddleware().Invoke);
// });

/**
object value = app.MapGet("/fruit", async (HttpContext context, IOptions<FruitOptions> FruitOptions) =>
{
    FruitOptions options = FruitOptions.Value;
    await context.Response.WriteAsync($"{options.Name}, {options.color}");
});
*/


app.Use(async (context, next) =>
{
    await next();
    await context.Response.WriteAsync($"\nResponse status code: {context.Response.StatusCode}");
});

app.UseMiddleware<FruitMiddleware>();


// registerring a custom middleware
// app.UseMiddleware<CustomMiddleware>();

// here I write the custom middleware directly as I declared the details extension version in CustomMiddlewareExtension class
app.UseCustomMiddleware();

app.MapGet("/", () => "Hello Shuva! This is your first dotnet application in using dotnet 6.0. Learn carefully and get job ready programmer within one month.");

app.Run();
