using Univan.Api;
using Univan.Api.Extensions;
using Univan.Api.Middleware;
using Univan.Application;
using Univan.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApi()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddMassTransitDependency(builder.Configuration);

var ionicFrontend = "IonicFrontend";
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: ionicFrontend,
        policyBuilder => policyBuilder
            .WithOrigins("http://localhost:8080")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
        );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(ionicFrontend);

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
