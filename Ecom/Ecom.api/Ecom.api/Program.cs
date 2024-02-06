using Ecom.api.Controllers;
using Ecom.api.Middleware;
using Ecom.SharedLibrary.Common;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    string[] domains = builder.Configuration.GetSection("CORSEndPoint").Value.Split(";").ToArray();
    options.AddPolicy("CORSPolicy", builder => builder.WithOrigins(domains).AllowAnyHeader().AllowCredentials().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Ecom",
        Description = "An ASP.NET Core Web API for managing the ecommerce application",
        Contact = new OpenApiContact
        {
            Name = "Ecom Application"
        }

    });
});
AppDependency.Map(builder.Services);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORSpolicy");
app.UseAuthorization();
app.UseMiddleware<EcomMiddleware>();
app.MapControllers();

app.Run();
