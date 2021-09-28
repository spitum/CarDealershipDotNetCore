using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Data.Data
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string Admin = "2301D884-221A-4E7D-B509-0113DCC043E1";
        private const string Sales = "78A7570F-3CE5-48BA-9461-80283ED1D94D";
        private const string Disabled = "01B168FE-810B-432D-9010-233BA0B380E9";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(
                    new IdentityRole
                    {
                        Id = Admin,
                        Name = "Admin",
                        NormalizedName = "Admin"
                    },
                    new IdentityRole
                    {
                        Id = Sales,
                        Name = "Sales",
                        NormalizedName = "Sales"
                    },
                    new IdentityRole
                    {
                        Id = Disabled,
                        Name = "Disabled",
                        NormalizedName = "Disabled"
                    }
                );
        }
    }
}
