using FootballFieldManagment.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Service.Services
{
    public class GenericService<T>:IGenericService<T> where T : class
    {
    }
}
