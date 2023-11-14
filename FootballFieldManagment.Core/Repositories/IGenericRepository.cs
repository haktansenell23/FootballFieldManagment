using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<List<T>> GetAllItems();

        public Task<T> GetItem(Guid id);

        public Task<T> AddItem(T item);

        public Task<List<T>>AddAllItem(List<T> items);

        public void DeleteItem(Guid id);   
        
        public void UpdateItem(T item); 

    }
}
