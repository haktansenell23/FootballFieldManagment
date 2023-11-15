using FootballFieldManagment.Core.Entities;
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
    public class PlayerService : GenericService<Player>, IPlayerService
    {
        public PlayerService(IUnitOfWork unitOfWork, IGenericRepository<Player> repository) : base(unitOfWork, repository)
        {
        }
    }
}
