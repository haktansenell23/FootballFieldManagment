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
    public class SessionService : GenericService<Session>, ISessionService
    {
        public SessionService(IUnitOfWork unitOfWork, IGenericRepository<Session> repository) : base(unitOfWork, repository)
        {
        }
    }
}
