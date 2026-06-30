using empService.Repositories;

namespace empService.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddDepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}