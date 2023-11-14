﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUserDetail AppUserDetail { get; set; }
        public Guid AppUserDetailID { get; set; }
        public List<Player> Player { get; set; }
        public bool isDeleted { get; set; }
    }
}
