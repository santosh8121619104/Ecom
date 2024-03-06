
using Lms.Api.GraphQLTypes.Mutations;
using Lms.Api.GraphQLTypes.Queries;
using Lms.Api.Repositories;
using Lms.Api.Repositories.Interfaces;

namespace Lms.Api
{
    public class Startup
    {
        private ConfigurationManager configuration;

        public Startup(ConfigurationManager configuration)
        {
            this.configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGraphQLServer()
        .AddQueryType(d => d.Name("Query"))
            .AddType<CourseQueries>()
            .AddType<EnrollmentQueries>()
            
        .AddMutationType(d => d.Name("Mutation"))
            .AddType<CourseMutations>();

            services.AddScoped<ICourseRepository,CourseRepository>();
            services.AddScoped<IUserProgressRepository,UserProgressRepository>();
        }
    }
}
