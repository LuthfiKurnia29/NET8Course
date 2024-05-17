using Restaurants.Domain.Exceptions;

namespace Restaurants.API.Middlewares;


public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
    /// <summary>
    /// HandlingExceptionMiddleware
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (NotFoundException notFound)
        {
            context.Response.StatusCode = 404;
            Console.WriteLine("Tes");
            await context.Response.WriteAsync(notFound.Message);
            logger.LogWarning(notFound.Message);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(e.Message);
            Console.WriteLine("Tes500");
        }
    }
}