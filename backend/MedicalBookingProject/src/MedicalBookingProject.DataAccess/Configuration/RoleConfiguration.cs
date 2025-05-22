using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Entities;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
            new IdentityRole("Admin")
            {
                NormalizedName = "ADMIN"
            },
            new IdentityRole("Doctor")
            {
                NormalizedName = "DOCTOR"
            },
            new IdentityRole("Patient")
            {
                NormalizedName = "PATIENT"
            }
            );
        }
    }
}
