namespace WebApi.Data.Repository.Interfaces
{
    public interface IRepositorysOfTheUnitOfWork
    {
        IProdutoRepository Produto { get; }

        IDepartamentoRepository Departamento { get; }
        void save();
    }
}
