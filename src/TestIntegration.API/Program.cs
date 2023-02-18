using NLog.Web;
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

void ConfigureServices()
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

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

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}