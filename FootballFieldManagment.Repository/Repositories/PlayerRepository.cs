using FootballFieldManagment.Core.Entities;
using FootballFieldManagment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Repository.Repositories
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {
        }
    }
}
