using Ecom.BusinessLayer.Interfaces;
using Ecom.BusinessLayer.Services;
using Ecom.DataAccess.DBConfig;
using Ecom.DataAccess.DBContext;
using Ecom.DataAccess.DBContext.Interface;
using Ecom.DataAccess.DBCredentials;
using Ecom.DataAccess.Interfaces;
using Ecom.DataAccess.Repositories;
using Ecom.SharedLibrary.Logging;
using Ecom.SharedLibrary.Logging.Interface;
using ELC.DataAccess.DBCredentials;
using System.Security.Cryptography;

namespace Ecom.api.Controllers
{
    public class AppDependency
    {
        public static void Map(IServiceCollection services)
        {

            services.AddSingleton<ILogProvider, LogProvider>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpClient();
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IClientDBConnection, ClientDBConnection>();
            services.AddScoped<IApplicationCredentials, ApplicationCredentials>();
            services.AddScoped<IEcomDbContext, EcomDBContext>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
      

            //Business layer
        
            services.AddScoped<IProductService, ProductService>();


            //DAL layer
            services.AddScoped<IProductRepository, ProductsRepository>();
      
        }
    }
}
