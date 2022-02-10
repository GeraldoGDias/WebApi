
using WebApi.Data.Repository.Interfaces;

namespace WebApi.Data.Repository.Entities
{
    public class RepositorysOfTheUnitOfWork : IRepositorysOfTheUnitOfWork
    {
        private readonly RepositoryContext _repositoryContext;

        private IProdutoRepository _produtoRepository;

        private IDepartamentoRepository _departamentoRepository;


        public RepositorysOfTheUnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public IProdutoRepository Produto {
            get
            {
                if (_produtoRepository == null)
                {
                    _produtoRepository = new ProdutoRepository(_repositoryContext);
                }

                return _produtoRepository;
            }
        }

        public IDepartamentoRepository Departamento
        {
            get
            {
                if( _departamentoRepository == null)
                {
                    _departamentoRepository = new DepartamentoRepository(_repositoryContext);
                }

               return _departamentoRepository;
            }
        }

        public void save()
        {
            try
            {
                _repositoryContext.SaveChanges();
            }
            catch
            {

                throw;
            }
            
        }
    }
}
