using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SpendTracker.Application.Contracts;
using SpendTracker.Application.Users;
using SpendTracker.Domain.Users;
using SpendTracker.Infrastructure.Persistence;
using SpendTracker.Infrastructure.Persistence.Repositories;

namespace SpendTracker
{

    public static class DependencyInjection
    {
        public static void AddSpendTrackerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCarter();
            var assembly = typeof(DependencyInjection).Assembly;
            services.AddAutoMapper(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddScoped<IUserRepository, UserSqlRepository>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddDbContext<UserContext>(options =>
            {
                
                    options.UseSqlServer(configuration.GetConnectionString("SpendTracker"));
                
            });
        }


    }
}
