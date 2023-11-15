using FootballFieldManagment.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext appDbContext;

        private readonly DbSet<T> _dbSet;

        public GenericRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
            _dbSet=appDbContext.Set<T>();   
        }

        public async Task<List<T>> AddAllItem(List<T> items)
        {
            await _dbSet.AddRangeAsync(items);
            return items;
        }

        public async Task<T> AddItem(T item)
        {
              await _dbSet.AddAsync(item); 
              return item;
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<List<T>> GetAllItems()
        {

            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetItem(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void UpdateItem(T item)
        {
              _dbSet.Update(item);  
        }

        public IQueryable Where(Expression<Func<T, bool>> expression)
        {
          return  _dbSet.Where(expression);

        }
    }
}
