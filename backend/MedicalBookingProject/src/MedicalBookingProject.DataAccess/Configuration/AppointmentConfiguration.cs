using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.DataAccess.Configuration
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasKey(a => a.Id);
            //builder.HasOne(d => d.Book)
            //    .WithMany(c => c.Doctors)
            //    .HasForeignKey(x => x.RoleId)
            //    .IsRequired();
            builder.Property(a => a.DoctorId)
                .IsRequired();
            builder.Property(a => a.PatientId)
                .IsRequired();
            builder.Property(a => a.SlotId)
                .IsRequired();
            builder.Property(a => a.MedicalCardId);
            builder.Property(a => a.PatientCame);
            builder.Property(a => a.PatientIsLate);
            builder.Property(a => a.PatientUnacceptableBehavior);
            builder.Property(a => a.VisualExamination);
            builder.Property(a => a.ReferralTests);
            builder.Property(a => a.MakingDiagnosis);
            builder.Property(a => a.Treatment);
            builder.Property(a => a.FinalCost);
        }
    }
}
