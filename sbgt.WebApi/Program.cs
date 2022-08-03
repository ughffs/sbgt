using sbgt.Repository;
using sbgt.Repository.Configuration;
using sbgt.Repository.Context;
using sbgt.Repository.Extensions;
using sbgt.ServiceLogic.Extensions;
using sbgt.WebApi.Extensions;

namespace sbgt.WebApi;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var dbConfig = builder.Configuration.GetSection("DatabaseConfiguration").Get<DatabaseConfiguration>();

        builder.Services.AddRepositoryDependencies(dbConfig);
        builder.Services.AddServiceDependencies();
        
        var app = builder.Build();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.EnsureDbExists<DataContext>(
                context => Seeder.SeedData(context)
                );
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
        
    }
}
