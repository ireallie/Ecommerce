using AutoMapper;
using Ecommerce.Api.Mappings;
using Ecommerce.BusinessLogic.Interfaces;
using Ecommerce.BusinessLogic.Services;
using Ecommerce.DataAccess;
using Ecommerce.DataAccess.Interceptors;
using Ecommerce.DataAccess.Interfaces;
using Ecommerce.DataAccess.UOW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<UpdateAuditableEntitiesInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var interceptor = sp.GetService<UpdateAuditableEntitiesInterceptor>(); 

                options.UseSqlServer(configuration.GetConnectionString("MainDatabase"))
                    .AddInterceptors(interceptor);
            });

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            return services;
        }

        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProductMapProfile());
            });

            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
