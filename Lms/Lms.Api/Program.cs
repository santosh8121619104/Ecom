using Lms.Api;
using Lms.Api.GraphQLTypes.Mutations;
using Lms.Api.GraphQLTypes.Queries;
using Lms.Api.Repositories.Interfaces;
using Lms.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Lms.Api.Models;
using Microsoft.AspNetCore.Builder;
using Lms.Api.Schema.Mutation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LmsContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:8000")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


builder.Services.AddGraphQLServer()
      .AddQueryType<Query>()
          .AddType<CourseType>().AddType<EnrollmentType>().AddType<UserType>()

      .AddMutationType<Mutation>().AddTypeExtension<UserMutations>()
          .AddTypeExtension<CourseMutations>().AddType<CourseInputType>().AddType<EnrollmentInputType>()
          .AddType<UserInputType>()
        .AddProjections() 
        .AddFiltering().AddSorting();

builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IUserProgressRepository, UserProgressRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();





var app = builder.Build();
app.UseRouting();
// Use CORS policy
app.UseCors("AllowSpecificOrigin");
// Add redirection from root to /graphql
app.MapGet("/", context =>
{
    context.Response.Redirect("/graphql");
    return Task.CompletedTask;
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL(); // Use MapGraphQL here
    endpoints.MapGraphQLSchema();
});
app.Run();
