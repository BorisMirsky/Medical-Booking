using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Shedules;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Role)
                .WithMany(r => r.Doctors)
                .HasForeignKey(d => d.RoleId)
                .IsRequired();
            builder
                .HasMany(d => d.Timeslots)
                .WithOne(t => t.Doctor);
            builder
               .HasMany(d => d.Bookings)
               .WithOne(b => b.Doctor);
            builder.Property(d => d.Email)
                .IsRequired();
            builder.Property(d => d.Password)
                .IsRequired();
            builder.Property(d => d.Speciality)
                .IsRequired();
            builder.Property(d => d.UserName)
                .IsRequired();
            builder.Property(d => d.IsActive);
            builder.Property(d => d.Token);
            builder.Property(d => d.Gender);
            builder.Property(d => d.Speciality);
            builder.Property(d => d.Price);
            builder.Property(d => d.Salary);
        }
    }
}
