using FootballFieldManagment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public Task<List<T>> AddAllItem(List<T> items)
        {
            throw new NotImplementedException();
        }

        public Task<T> AddItem(T item)
        {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAllItems()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateItem(T item)
        {
            throw new NotImplementedException();
        }
    }
}
