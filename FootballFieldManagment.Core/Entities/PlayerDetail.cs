using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class PlayerDetail
    {
        public Guid PlayerDetailID { get; set; }
        public Player Player { get; set; }
        public Guid PlayerID { get; set; }

        public Team Team { get; set; }

        public int AssistsCount { get; set; }
        public int GoalsCount { get; set; }
        public int CleanSheetCount { get; set; }
    }
}
