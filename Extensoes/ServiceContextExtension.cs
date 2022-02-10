using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data.Repository.Entities;

namespace WebApi.Extensoes
{
    public static class ServiceContextExtension
    {
        const string VersionMysql = "5.7.26-mysql";
        public static IServiceCollection AddDbContextMysql(this IServiceCollection services, IConfiguration Configuration)
          =>  services.AddDbContext<RepositoryContext>
                (options => options.UseMySql(Configuration.GetConnectionString("EcomerceConnection"),ServerVersion.Parse(VersionMysql)));

    }

}
