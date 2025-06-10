using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Shedules;
using Microsoft.EntityFrameworkCore;




namespace MedicalBookingProject.DataAccess.Configuration
{
    public class SheduleConfiguration
    {
        public void Configure(EntityTypeBuilder<Shedule> builder)
        {
            builder.HasKey(s => s.SlotId);
            builder.Property(s => s.SlotDatetimeStart)
                .IsRequired();
            builder.Property(s => s.SlotDatetimeStop)
                .IsRequired();
            builder.Property(s => s.DoctorId)
                .IsRequired();
            builder.Property(s => s.PatientId)
                .IsRequired();
            builder.Property(s => s.IsBooked)
                .IsRequired();
        }
    }
}
