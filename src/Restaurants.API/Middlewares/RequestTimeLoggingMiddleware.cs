using System.Diagnostics;

namespace Restaurants.API.Middlewares;

public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // Start Timer
        var stopWatch = Stopwatch.StartNew();
        await next.Invoke(context);
        
        // Stop Timer
        stopWatch.Stop();
        if (stopWatch.ElapsedMilliseconds / 1000 > 4)
        {
            logger.LogInformation("Request [{Verb}] at {Path} took {Time} ms", 
                context.Request.Method,
                context.Request.Path,
                stopWatch.ElapsedMilliseconds);
        }
    }
}