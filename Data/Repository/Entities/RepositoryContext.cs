using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Data.Repository.Entities
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Departamento> Departamento { get; set; }
    }
}
