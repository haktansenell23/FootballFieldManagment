using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Services
{
    public interface IGenericService< T> where T : class
    {
        public Task<List<T>> GetAllItems();

        public Task<T> GetItem(Guid id);

        public Task<T> AddItem(T item);

        public Task<List<T>> AddAllItem(List<T> items);

        public Task  DeleteItem(T item);

        public Task UpdateItem(T item);
    }
}
