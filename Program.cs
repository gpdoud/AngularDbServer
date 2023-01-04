using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AngularDbServer.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AngularDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AngularDbContext") 
        ?? throw new InvalidOperationException("Connection string 'AngularDbContext' not found.")));

builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
scope.ServiceProvider.GetService<AngularDbContext>()!.Database.Migrate();

SeedDatabase();

app.Run();

void SeedDatabase() {

    using (var scope = app.Services.CreateScope()) {
        try {
            var scopedContext = scope.ServiceProvider.GetService<AngularDbContext>();
            Seeder.Initialize(scopedContext!);
        } catch {
            throw;
        }
    }
}