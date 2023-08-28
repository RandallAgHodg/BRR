using BRR.WebAPI;
using BRR.Infrastructure;
using BRR.Application;
using BRR.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddControllers();

services
    .AddOpenAPISupport()
    .AddSwaggerGen()
    .AddJWTAuthentication()
    .AddFileStorage()
    .AddAplication()
    .AddInfrastructure();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app
        .UseSwagger()
        .UseSwaggerUI(options =>
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));

app.UseMiddleware<GlobalExceptionMiddleware>();

app
    .UseHttpsRedirection()
    .UseAuthorization()
    .UseAuthentication();

app.MapControllers();

app.Run();
