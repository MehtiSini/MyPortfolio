using Microsoft.EntityFrameworkCore;
using MyFramework.Domain;
using System.Linq;
using System.Linq.Expressions;

namespace MyFramework.Infrastructure
{
    public class RepositoryBase<Tkey, T> : IRepository<Tkey, T> where T : class
    {
        private readonly DbContext _Context;

        public RepositoryBase(DbContext context)
        {
            _Context = context;
        }

        public void Create(T entity)
        {
            _Context.Add(entity);
        }

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Any(expression);
        }

        public List<T> GetAll()
        {
            return _Context.Set<T>().ToList();
        }

        public T GetById(Tkey Id)
        {
            return _Context.Set<T>().Find(Id);
        }

        public void Save()
        {
            _Context.SaveChanges();
        }
    }
}
