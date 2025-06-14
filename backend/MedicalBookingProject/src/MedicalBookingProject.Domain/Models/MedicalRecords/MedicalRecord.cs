using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MedicalBookingProject.Domain.Models.MedicalRecords
{

    [Table("medicalrecords")]
    public class MedicalRecord
    {

        public MedicalRecord()
        { }


        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("slotstart")]
        public string SlotStart { get; set; }

        [Column("slotstop")]
        public string SlotStop { get; set; }

        [Column("symptoms")]
        public string? Symptoms { get; set; }

        [Column("diagnosis")]
        public string? Diagnosis { get; set; }

        [Column("prescribedtreatment")]
        public string? PrescribedTreatment { get; set; }

        public Doctor Doctor { get; set; }

        public Patient Patient { get; set; }

        public Appointment Appointment { get; set; }

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("appointmentid")]
        public Guid AppointmentId { get; set; }
    }
}
