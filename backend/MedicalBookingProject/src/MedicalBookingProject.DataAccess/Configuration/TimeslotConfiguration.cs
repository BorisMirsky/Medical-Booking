using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Shedules;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.MedicalRecords;




namespace MedicalBookingProject.DataAccess.Configuration
{
    public class TimeslotConfiguration : IEntityTypeConfiguration<Timeslot>
    {
        public void Configure(EntityTypeBuilder<Timeslot> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Doctor)
                .WithMany(d => d.Timeslots)
                .HasForeignKey(s => s.DoctorId)
                .IsRequired();

            builder.HasOne(s => s.Patient)
                .WithMany(d => d.Timeslots)
                .HasForeignKey(s => s.PatientId);

            builder
               .HasMany(d => d.Bookings)
               .WithOne(b => b.Timeslot);

            builder.HasOne(b => b.Appointment)
                .WithOne(d => d.Timeslot);
                //.HasForeignKey<Appointment>(b => b.TimeslotId);

            builder.HasOne(b => b.MedicalRecord)
                .WithOne(d => d.Timeslot);
                //.HasForeignKey<MedicalRecord>(b => b.TimeslotId);

            builder.Property(s => s.DatetimeStart)
                .IsRequired();
            builder.Property(s => s.DatetimeStop)
                .IsRequired();
            builder.Property(s => s.DoctorId)
                .IsRequired();
            builder.Property(s => s.PatientId);
            builder.Property(s => s.IsBooked);
        }
    }
}
