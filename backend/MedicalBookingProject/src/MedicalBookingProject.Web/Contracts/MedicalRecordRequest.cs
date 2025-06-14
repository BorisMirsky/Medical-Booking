using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalBookingProject.Web.Contracts
{
    public record MedicalRecordRequest
    {
        public Guid Id { get; set; }

        public string? Symptoms { get; set; }

        public string? Diagnosis { get; set; }

        public string? PrescribedTreatment { get; set; }

        public Guid AppointmentId { get; set; }
    }
}
