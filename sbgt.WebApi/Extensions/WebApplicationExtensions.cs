using Microsoft.EntityFrameworkCore;

namespace sbgt.WebApi.Extensions;

public static class WebApplicationExtensions
{
    public static void EnsureDbExists<TDbContext>(
        this WebApplication app,
        Action<TDbContext>? postCreationAction = null
    ) where TDbContext : DbContext
    {
        using (IServiceScope scope = app.Services.CreateScope())
        {
            var requiredService = scope.ServiceProvider.GetRequiredService<TDbContext>();
            requiredService.Database.EnsureCreated();

            if (postCreationAction != null) postCreationAction(requiredService);
        }
    }
}