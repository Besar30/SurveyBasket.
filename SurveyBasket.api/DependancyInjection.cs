using Mapster;
using MapsterMapper;
using SurveyBasket.api.Services;
using System.Reflection;
namespace SurveyBasket.api
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependecies(this IServiceCollection services)
        {

           services.AddControllers();
            services.AddSwaggerservices()
            .AddMaperster()
            .AddFluentValidation();

            services.AddScoped<Ipollservices, pollservices>();
            return services;
        }
        public static IServiceCollection AddSwaggerservices(this IServiceCollection services)
        {

           
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
        public static IServiceCollection AddMaperster(this IServiceCollection services)
        {


            var mapingconfing1 = TypeAdapterConfig.GlobalSettings;
            mapingconfing1.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(mapingconfing1));
            return services;
        }
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {


            services
               .AddFluentValidationAutoValidation()
               .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}