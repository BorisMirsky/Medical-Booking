using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.Domain.Models.Shedules;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne(b => b.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(b => b.DoctorId)
                .IsRequired();

            builder.HasOne(b => b.Patient)
                .WithMany(d => d.Appointments)
                .HasForeignKey(b => b.PatientId)
                .IsRequired();

            builder.HasOne(b => b.Booking)
                .WithOne(d => d.Appointment);
            //.HasForeignKey<Booking>(b => b.Appointment.Id);      // ?

            builder.HasOne(b => b.Timeslot)
                .WithOne(d => d.Appointment)
                .HasForeignKey<Timeslot>(b => b.AppointmentId);

            builder.HasOne(b => b.MedicalRecord)
                .WithOne(d => d.Appointment)
                .HasForeignKey<MedicalRecord>(b => b.AppointmentId);
                //.IsRequired();

            builder.Property(a => a.DoctorId)
                .IsRequired();
            builder.Property(a => a.PatientId)
                .IsRequired();
            builder.Property(a => a.TimeslotId)
                .IsRequired();
            builder.Property(a => a.MedicalRecordId);
            builder.Property(a => a.PatientCame);
            builder.Property(a => a.PatientIsLate);
            builder.Property(a => a.PatientUnacceptableBehavior);
        }
    }
}
