using Microsoft.Extensions.DependencyInjection;
using Project.Dal;
using ProjectManager.Abstractions.Infrastructure;
using ProjectManager.Abstractions.Repositories;
using ProjectManager.Dal;
using ProjectManager.Dal.Repositories;
namespace ProjectManager.Bll.DI
{
    public class IoC
    {

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddDbContext<SqlContext>();
            services.AddScoped<IRepositoryCollection, SqlRepositoryCollection>();

        }
    }
}
