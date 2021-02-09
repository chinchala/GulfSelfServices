using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace SelfServices.Api.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger, IConfiguration config)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var request = await FormatRequest(context.Request);
            var originalBodyStream = context.Response.Body;
            using (var responseBody = new MemoryStream())
            {
                context.Response.Body = responseBody;

                await _next(context);
                var a = context.Request.Method == "POST";
                context.Request.Headers.TryGetValue(HeaderNames.Authorization, out var authorization);
                var response = await FormatResponse(context.Response);
                _logger.LogInformation("AuthHeader:{authorization}, QueryString: {QueryString}, Request: {Request}, Response: {Response}", authorization, context.Request.QueryString, request, response);
                await responseBody.CopyToAsync(originalBodyStream);
            }
        }


        private async Task<string> FormatRequest(HttpRequest request)
        {

            request.EnableBuffering();
            var body = request.Body;

            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyAsText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;

            return bodyAsText;
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return text;
        }
    }
}