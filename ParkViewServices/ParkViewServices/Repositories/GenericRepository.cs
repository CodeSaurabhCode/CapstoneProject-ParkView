using Microsoft.EntityFrameworkCore;
using ParkViewServices.Data;
using ParkViewServices.Models;
using ParkViewServices.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ParkViewServices.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        public GenericRepository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet =  _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet; ;
            return query.ToList();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
