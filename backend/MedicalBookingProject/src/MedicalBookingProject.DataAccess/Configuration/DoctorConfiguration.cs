using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Shedules;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Email)
                .IsRequired();
            builder.Property(d => d.Password)
                .IsRequired();
            builder.Property(d => d.Role)
                .IsRequired();
            builder.Property(d => d.Speciality)
                .IsRequired();
            builder.Property(d => d.UserName)
                .IsRequired();
            builder.Property(d => d.RoleId);
            builder.Property(d => d.IsActive);
            builder.Property(d => d.Token);
            builder.Property(d => d.Gender);
            builder.Property(d => d.Speciality);
            builder.Property(d => d.Price);
            builder.Property(d => d.Salary);
        }
    }
}
