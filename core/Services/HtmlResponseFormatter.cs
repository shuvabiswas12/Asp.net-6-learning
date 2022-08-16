﻿namespace core.Services
{
    public class HtmlResponseFormatter : IResponseFormatter
    {
        private int _responseCounter = 0;
        public async Task Format(HttpContext context, string content)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync($"Formatted response {++_responseCounter} \n <h2>{content}</h2>");
        }
    }
}
