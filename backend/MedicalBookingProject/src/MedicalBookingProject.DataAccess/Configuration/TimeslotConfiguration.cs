using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Shedules;
using Microsoft.EntityFrameworkCore;




namespace MedicalBookingProject.DataAccess.Configuration
{
    public class TimeslotConfiguration : IEntityTypeConfiguration<Timeslot>
    {
        public void Configure(EntityTypeBuilder<Timeslot> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.DatetimeStart)
                .IsRequired();
            builder.Property(s => s.DatetimeStop)
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
