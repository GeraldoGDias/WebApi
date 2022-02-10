using Microsoft.Extensions.DependencyInjection;
using WebApi.Data.Repository.Entities;
using WebApi.Data.Repository.Interfaces;

namespace WebApi.Extensoes
{
    public static class ServiceRepositoryExtensions
    {
        public static void ConfigureRepositorysOfTheUnitOfWork(this IServiceCollection services)
        {
            services.AddTransient<IRepositorysOfTheUnitOfWork,RepositorysOfTheUnitOfWork > ();
        }
    }
}
