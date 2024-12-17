


namespace SurveyBasket.api
{
    public static class DependancyInjection
    {
        public static IServiceCollection AddDependecies(this IServiceCollection services,IConfiguration configuration)
        {

           services.AddControllers();
            services.AddSwaggerservices()
            .AddMaperster()
            .AddFluentValidation();
            services.AddAuthentication(configuration);

            services.AddScoped<Ipollservices, pollservices>();
            services.AddScoped<IAuthServices, AuthServices>();
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
        public static IServiceCollection AddAuthentication(this IServiceCollection services,IConfiguration configuration)
        {

            var JwtSetting=configuration.GetSection(JwtOptions.SectionName).Get<JwtOptions>();

            services.AddOptions<JwtOptions>()
                .BindConfiguration(JwtOptions.SectionName)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            services.AddSingleton<IJwtProvider, JwtProvider>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>();

            //services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(o =>
            {
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSetting?.Key!)),
                    ValidIssuer = JwtSetting?.Issuer,
                    ValidAudience = JwtSetting?.Audience
                };

            });
            return services;
        }
    }
}