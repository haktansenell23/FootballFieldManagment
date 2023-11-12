using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class Location
    {
        public Guid LocationID { get; set; }
        public string LocationCity { get; set; }
        public string LocationDistrict { get; set; }
        public string FieldName { get; set; }
        public bool isDeleted { get; set; }
    }
}
