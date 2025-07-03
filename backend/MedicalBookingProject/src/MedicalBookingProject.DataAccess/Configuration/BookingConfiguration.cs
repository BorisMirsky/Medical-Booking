using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;



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
                .WithOne(d => d.Booking)
                //.HasForeignKey(static b => b.)
                .IsRequired();

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
