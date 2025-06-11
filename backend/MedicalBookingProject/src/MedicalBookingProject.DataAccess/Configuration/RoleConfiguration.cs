using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder
                .HasMany(r => r.Doctors)
                .WithOne(u => u.Role);
            builder
                .HasMany(r => r.Patients)
                .WithOne(u => u.Role);
            builder
                .Property(r => r.Name)
                .IsRequired();
        }
    }
}
