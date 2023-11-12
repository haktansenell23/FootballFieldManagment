using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class Team
    {
        public Guid TeamID { get; set; }
        public string  TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string TeamLogoPath { get; set; }
        public Session Session { get; set; }
        public List<Player> Players { get; set; }
        public Guid SessionID { get; set; }
        public Guid TeamCaptainID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
