using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Shedules;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(d => d.Id);

            //builder.HasOne(d => d.Role)
            //    .WithMany(r => r.Admins)
            //    .HasForeignKey(d => d.RoleId)
            //    .IsRequired();

            builder.Property(d => d.Email)
                .IsRequired();
            builder.Property(d => d.Password)
                .IsRequired();
            builder.Property(d => d.UserName)
                .IsRequired();
            //builder.Property(d => d.IsActive);
            builder.Property(d => d.Token);
        }
    }
}
