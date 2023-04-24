using CarRentalApi.WebApi.Endpoints;
using CarRentalApi.WebApi.Extensions;
using TatBlog.WebApi.Mapsters;

var builder = WebApplication.CreateBuilder(args); 
{
    builder
        .ConfigureCors()
        .ConfigureServices()
        .ConfigureSwaggerOpenApi()
        .ConfigureMapster();
}

var app = builder.Build(); 
{
    app.SetupRequestPipeLine();
    app.UseDataSeeder();

    // Configure API Endpoint
    app.MapCarEndpoints();
    app.Run();
}
