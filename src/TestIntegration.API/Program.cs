using Microsoft.EntityFrameworkCore;
using NLog.Web;
using TestIntegration.API.DataAccess;
using TestIntegration.API.Services;

#region Main

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigurePipeline();

app.Run();

#endregion

#region Configure

void ConfigureServices()
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddDbContext<AppDbContext>(opt =>
    {
        opt.UseNpgsql("name=ConnectionStrings:AppDbConnection");
    });

    builder.Services.AddHttpClient<IUsersInformationIntegrationService, JsonPlaceholderUsersInformationIntegrationService>();
    builder.Services.AddScoped<IAuthorizationService, HeaderAuthorizationService>();
    builder.Services.AddScoped<IUsersInformationService, UsersInformationService>();
}

void ConfigurePipeline()
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    using (var scope = app.Services.CreateScope())
    {
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        appDbContext.Database.EnsureCreated();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
} 

#endregion