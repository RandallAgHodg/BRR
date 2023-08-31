using BRR.WebAPI;
using BRR.Infrastructure;
using BRR.Application;
using BRR.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

//servicios

var services = builder.Services;

services.AddControllers();

services
    .AddAplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
    app
        .UseSwagger()
        .UseSwaggerUI();

//cors


// midlewares

app
    .UseMiddleware<GlobalExceptionMiddleware>()
    .UseHttpsRedirection()
    .UseAuthentication()
    .UseAuthorization();

app.MapControllers();

app.Run();
