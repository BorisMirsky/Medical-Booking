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
            builder.HasOne(d => d.Role)
                .WithMany(c => c.Patients)
                .HasForeignKey(x => x.RoleId)
                .IsRequired();
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
