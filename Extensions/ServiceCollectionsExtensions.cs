

using empService.Services;

namespace empService.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>()
                .AddSingleton<IUserCacheService, UserCacheService>();
            return services;
        }
    }
}