using DSRPracticeProject.Api;
using DSRPracticeProject.Api.Configuration;
using DSRPracticeProject.Context;
using DSRPracticeProject.Context.Setup;
using DSRPracticeProject.Services.Settings;
using DSRPracticeProject.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

// Add services to the container
var mainSettings = Settings.Load<MainSettings>("Main");
var openApiSettings = Settings.Load<OpenApiSettings>("OpenApi");

var services = builder.Services;

services.AddHttpContextAccessor();
services.AddAppCors();

services.AddAppDbContext(builder.Configuration);

services.AddAppHealthChecks();
services.AddAppVersioning();
services.AddAppOpenApi(openApiSettings);
services.AddAppAutoMappers();

services.AddAppControllersAndViews();

services.AddAppServices();

var app = builder.Build();

// Configure the HTTP request pipeline

app.UseAppCors();

app.UseAppHealthChecks();

app.UseAppOpenApi();

DbInitializer.Execute(app.Services);
DbSeeder.Execute(app.Services, true);

app.UseAppControllersAndViews();
app.Run();
