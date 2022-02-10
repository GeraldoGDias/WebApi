using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Data.Repository.Interfaces;

namespace WebApi.Data.Repository.Entities
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _repositoryContext;


        public RepositoryBase(RepositoryContext repositoryContex)
        {
            _repositoryContext = repositoryContex;
        }
        public void Create(T entity)
        {
            _repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _repositoryContext.Set<T>().Remove(entity);
        }

        public Task<T> Find(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> Find(string id)
        {
            throw new System.NotImplementedException();
        }

        public  IQueryable<T> FindAll()
        {
            return _repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindAllByCondition(Expression<Func<T, bool>> expression)
        {
            return _repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            _repositoryContext.Set<T>().Update(entity);
        }
    }
}
