using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalBookingProject.Web.Contracts
{
    public record MedicalRecordRequest
    {
        public Guid Id { get; set; }

        public Guid? AppointmentId { get; set; }

        public Guid DoctorId { get; set; }

        public Guid PatientId { get; set; }

        public Guid TimeslotId { get; set; }

        public Guid BookingId { get; set; }

        public string Symptoms { get; set; } = String.Empty;

        public string Diagnosis { get; set; } = String.Empty;

        public string PrescribedTreatment { get; set; } = String.Empty;

        public string VisualExamination { get; set; } = String.Empty;

        public string ReferralTests { get; set; } = String.Empty;

        public int FinalCost { get; set; } = 0;
    }
}
