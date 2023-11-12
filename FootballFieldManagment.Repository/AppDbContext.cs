using FootballFieldManagment.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Repository
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<AppUserDetail> AppUsersDetail { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerDetail> PlayerDetail { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){
        
    
        
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());   
           
            base.OnModelCreating(builder);
        }
    }
}
