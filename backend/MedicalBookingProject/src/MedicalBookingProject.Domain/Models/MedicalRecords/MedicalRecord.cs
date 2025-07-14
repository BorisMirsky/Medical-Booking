using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MedicalBookingProject.Domain.Models.MedicalRecords
{

    [Table("medicalrecords")]
    public class MedicalRecord
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("appointmentid")]
        public Guid? AppointmentId { get; set; }

        [Column("bookingid")]
        public Guid BookingId { get; set; }

        [Column("slotid")]
        public Guid TimeslotId { get; set; } //= Guid.Empty;

        // to fill form of med. cart
        [Column("symptoms")]
        public string? Symptoms { get; set; }

        [Column("diagnosis")]
        public string? Diagnosis { get; set; }

        [Column("prescribedtreatment")]
        public string? PrescribedTreatment { get; set; }

        [Column("visualexamination")]
        public string? VisualExamination { get; set; }

        [Column("referraltests")]
        public string? ReferralTests { get; set; }

        [Column("finalcost")]
        public int FinalCost { get; set; } = 0;

        // binded enities
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Timeslot? Timeslot { get; set; }

        public Appointment? Appointment { get; set; }

        public Booking? Booking { get; set; }
    }
}
