using FootballFieldManagment.Core.Repositories;
using FootballFieldManagment.Core.Services;
using FootballFieldManagment.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Service.Services
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<T> _repository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<List<T>> AddAllItem(List<T> items)
        {
            await _repository.AddAllItem(items);
           await _unitOfWork.CommitAsync();

            return items;
        }

        public async Task<T> AddItem(T item)
        {
               await _repository.AddItem(item);
             await _unitOfWork.CommitAsync();
            return item;
        }

        public async Task DeleteItem(T item)
        {
               _repository.DeleteItem(item);
               await _unitOfWork.CommitAsync(); 
        }

        public async Task<List<T>> GetAllItems()
        {
          var item =await _repository.GetAllItems();

            await _unitOfWork.CommitAsync();    

            return item;
           
        }

        public Task<T> GetItem(Guid id)
        {
            _repository.GetItem(id);    

           return _repository.GetItem(id);  

        }

        public async Task UpdateItem(T item)
        {
            _repository.UpdateItem(item);

            await _unitOfWork.CommitAsync();    
        }
    }
}
