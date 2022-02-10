using WebApi.Data.Repository.Interfaces;
using WebApi.Model;


namespace WebApi.Data.Repository.Entities
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public ProdutoRepository(RepositoryContext repositoryContex) : base(repositoryContex)
        {
        }
    }
}
