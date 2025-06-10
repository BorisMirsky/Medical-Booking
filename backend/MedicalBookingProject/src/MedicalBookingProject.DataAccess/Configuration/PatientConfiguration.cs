using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.DataAccess.Configuration
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email)
                .IsRequired();
            builder.Property(p => p.Password)
                .IsRequired();
            builder.Property(p => p.Role)
                .IsRequired();
            builder.Property(p => p.Gender)
                .IsRequired();
            builder.Property(p => p.UserName)
                .IsRequired();
            builder.Property(p => p.RoleId);
            builder.Property(p => p.IsActive);
            builder.Property(p => p.Token);
        }
    }
}
