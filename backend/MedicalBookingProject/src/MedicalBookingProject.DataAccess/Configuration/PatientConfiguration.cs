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
            builder.HasOne(p => p.Role)
                .WithMany(r => r.Patients)
                .HasForeignKey(p => p.RoleId)
                .IsRequired();
            builder
                .HasMany(p => p.Timeslots)
                .WithOne(t => t.Patient);
            builder
               .HasMany(p => p.Bookings)
               .WithOne(b => b.Patient);
            builder.Property(p => p.Email)
                .IsRequired();
            builder.Property(p => p.Password)
                .IsRequired();
            builder.Property(p => p.Gender)
                .IsRequired();
            builder.Property(p => p.UserName)
                .IsRequired();
            builder.Property(p => p.IsActive);
            builder.Property(p => p.Token);
        }
    }
}
