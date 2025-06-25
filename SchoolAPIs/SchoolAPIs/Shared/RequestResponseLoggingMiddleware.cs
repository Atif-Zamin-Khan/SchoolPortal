using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Text;

namespace CollegeAPIs.Shared
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestResponseLoggingMiddleware> _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var requestId = Guid.NewGuid().ToString();
            var stopwatch = Stopwatch.StartNew();

            // Capture original response stream
            var originalBodyStream = context.Response.Body;
            using var responseBody = new MemoryStream();
            context.Response.Body = responseBody;

            await _next(context); // Process controller

            stopwatch.Stop();

            // Read the response body
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseText = await new StreamReader(context.Response.Body).ReadToEndAsync();
            context.Response.Body.Seek(0, SeekOrigin.Begin);

            string responseCode = "";
            string responseDescription = "";

            try
            {
                if (!string.IsNullOrWhiteSpace(responseText))
                {
                    var json = JObject.Parse(responseText);
                    responseCode = json["responseCode"]?.ToString() ?? "";
                    responseDescription = json["responseDescription"]?.ToString() ?? "";
                }
            }
            catch
            {
                // ignore if not JSON
            }

            // Build log
            var log = new StringBuilder();
            log.AppendLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} [INF] HTTP {context.Request.Method} {context.Request.Path}");
            log.AppendLine($"{DateTime.UtcNow:yyyy-MM-dd HH:mm:ss} | GUID: \"{requestId}\" | API Request: URL : \"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}\"");
            log.AppendLine($"API ResponseCode: \t{responseCode} \tAPI ResponseDescription: {responseDescription}");

            _logger.LogInformation(log.ToString());

            // Copy response back to original stream
            await responseBody.CopyToAsync(originalBodyStream);
        }
    }
}
