using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class Player
    {
        public Guid PlayerID { get; set; }
        public AppUser AppUser { get; set; }
         public Team Team { get; set; }
        public List<PlayerDetail> PlayerDetails { get; set; }
        public Guid TeamID { get; set; }
        public string Position { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
