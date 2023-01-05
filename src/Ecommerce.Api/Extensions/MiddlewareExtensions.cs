using Ecommerce.Api.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Ecommerce.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
