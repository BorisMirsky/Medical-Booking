using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Doctor)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.DoctorId)
                .IsRequired();

            builder.HasOne(b => b.Patient)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.PatientId)
                .IsRequired();

            builder.HasOne(b => b.Timeslot)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b => b.TimeslotId)
                .IsRequired();

            builder.HasOne(b => b.Appointment)
                .WithOne(d => d.Booking)
                .HasForeignKey<Appointment>(b => b.BookingId);

            builder.HasOne(b => b.MedicalRecord)
                .WithOne(d => d.Booking)
                .HasForeignKey<MedicalRecord>(b => b.BookingId);

            builder.Property(b => b.DoctorId)
                .IsRequired();
            builder.Property(b => b.PatientId)
                .IsRequired();
            builder.Property(b => b.TimeslotId)
                .IsRequired();
            builder.Property(b => b.IsBooked);
        }
    }
}
