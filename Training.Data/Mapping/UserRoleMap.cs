using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Entity.Entities;

namespace Training.Data.Mapping
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(
                // Category.Create
                new UserRole
                {
                    UserId = 1,
                    RoleId = 4

                },
                new UserRole
                {
                    UserId = 2,
                    RoleId = 2
                }
                );
        }
    }
}
