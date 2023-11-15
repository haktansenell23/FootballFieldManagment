using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class AppUserDetail
    {
        public Guid AppUserDetailID { get; set; }
        public AppUser AppUser { get; set; }
        public bool isDeleted { get; set; } = false;
        public int CreatedSessionCount { get; set; } = 0;
        public double PerGoalMatchCount { get; set; }
        public double PerGoalAssistCount { get; set; }
        public int MatchCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
