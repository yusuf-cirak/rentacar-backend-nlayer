using Microsoft.AspNetCore.Builder;

namespace Core.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            // Bu kod WEBApi>Startup'taki IApplicationBuilder'da çalışan app. metodlarına bir yenisini ekler.
        }
    }
}
