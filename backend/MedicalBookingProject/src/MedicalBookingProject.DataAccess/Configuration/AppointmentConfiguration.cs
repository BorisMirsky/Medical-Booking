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

            // ?
            builder.HasOne(b => b.Booking)
                .WithOne(d => d.Appointment)
                .HasForeignKey<Appointment>("BookingId")
                .IsRequired();

            // ?
            builder.HasOne(b => b.Timeslot)
                .WithOne(d => d.Appointment)
                .HasForeignKey<Appointment>("TimeslotId")
                .IsRequired();

            //builder.HasOne(b => b.MedicalRecord)
            //    .WithOne(d => d.Appointment)
            //    .HasForeignKey<MedicalRecord>("AppointmentId");

            builder.Property(b => b.DoctorId)
                .IsRequired();
            builder.Property(b => b.PatientId)
                .IsRequired();
            builder.Property(b => b.TimeslotId)
                .IsRequired();
            builder.Property(b => b.PatientCame);
            builder.Property(b => b.PatientIsLate);
            builder.Property(b => b.PatientUnacceptableBehavior);
        }
    }
}
