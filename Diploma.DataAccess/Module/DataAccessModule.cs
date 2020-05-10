using Diploma.DataAccess.Context;
using Diploma.Interfaces.Entities;
using Diploma.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Diploma.DataAccess.Module
{
    public static class DataAccessModule
    {
        public static IServiceCollection LoadDataAccessModuleModule(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
