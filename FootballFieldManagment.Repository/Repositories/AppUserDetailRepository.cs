using FootballFieldManagment.Core.Entities;
using FootballFieldManagment.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Repository.Repositories
{
    public class AppUserDetailRepository : GenericRepository<AppUserDetail>, IAppUserDetailRepository
    {
        public AppUserDetailRepository(AppDbContext _appDbContext) : base(_appDbContext)
        {
        }
    }
}
