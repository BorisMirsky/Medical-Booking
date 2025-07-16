using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.Domain.Models.Shedules;





namespace MedicalBookingProject.DataAccess.Configuration
{
    public class MedicalRecordConfiguration : IEntityTypeConfiguration<MedicalRecord>
    {
        public void Configure(EntityTypeBuilder<MedicalRecord> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasOne(b => b.Doctor)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(b => b.DoctorId)
                .IsRequired();

            builder.HasOne(b => b.Patient)
                .WithMany(d => d.MedicalRecords)
                .HasForeignKey(b => b.PatientId)
                .IsRequired();

            builder.HasOne(b => b.Booking)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>("BookingId")
                .IsRequired();

            builder.HasOne(b => b.Timeslot)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>("TimeslotId")
                .IsRequired();

            builder.HasOne(b => b.Appointment)
                .WithOne(d => d.MedicalRecord)
                .HasForeignKey<MedicalRecord>("AppointmentId");
               // .IsRequired();

            builder.Property(b => b.DoctorId)
                .IsRequired();
            builder.Property(b => b.PatientId)
                .IsRequired();
            builder.Property(b => b.TimeslotId)
                .IsRequired();
            builder.Property(b => b.BookingId);
            builder.Property(b => b.AppointmentId);
            builder.Property(b => b.ReferralTests);
            builder.Property(b => b.PrescribedTreatment);
            builder.Property(b => b.FinalCost);
            builder.Property(b => b.Diagnosis);
            builder.Property(b => b.Symptoms);
            builder.Property(b => b.VisualExamination);
        }
    }
}
