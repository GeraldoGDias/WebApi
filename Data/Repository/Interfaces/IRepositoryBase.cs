using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebApi.Data.Repository.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);

        void Update(T entity);

        Task<T> Find(int id);

        Task<T> Find(string id);

        void Delete(T entity);  

    }
}
