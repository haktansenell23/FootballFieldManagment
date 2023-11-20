using FootballFieldManagment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballFieldManagment.Repository.EntityConfigurations
{
    public  class AppUserDetailConfiguration : IEntityTypeConfiguration<AppUserDetail>
    {
        public void Configure(EntityTypeBuilder<AppUserDetail> builder)
        {
            

        }


    }
}
