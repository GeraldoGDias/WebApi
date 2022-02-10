using WebApi.Data.Repository.Interfaces;
using WebApi.Model;

namespace WebApi.Data.Repository.Entities
{
    public class DepartamentoRepository:RepositoryBase<Departamento>,IDepartamentoRepository
    {
        public DepartamentoRepository(RepositoryContext repositoryContext):base(repositoryContext)  
        {

        }
    }
}
