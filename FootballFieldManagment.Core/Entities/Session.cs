using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class Session
    {
        public Guid SessionID { get; set; }
        public string SessionName { get; set; }
        public Guid LocationID { get; set; }
        public Guid  SessionAdminID { get; set; }
        public List<Team> Teams { get; set; }
        public int PerTeamPlayerCount { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        //false--> public   true --> private
        public bool SessionType { get; set; } = false;
    }
}
