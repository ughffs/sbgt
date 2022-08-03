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
            var databaseCreated = requiredService.Database.EnsureCreated();

            if (databaseCreated && postCreationAction != null) postCreationAction(requiredService);
        }
    }
}