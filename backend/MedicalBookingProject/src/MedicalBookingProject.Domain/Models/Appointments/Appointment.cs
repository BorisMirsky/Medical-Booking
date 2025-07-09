using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Models.MedicalRecords;




namespace MedicalBookingProject.Domain.Models.Appointments
{
    [Table("appointments")]
    public class Appointment
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("bookingid")]
        public Guid BookingId { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }   

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("slotid")]
        public Guid TimeslotId { get; set; }

        [Column("medicalcardid")]
        public Guid MedicalCardId { get; set; }

        // behavior of patient
        [Column("patientcame")]
        public Boolean PatientCame { get; set; } = false;

        [Column("patientislate")]
        public Boolean PatientIsLate { get; set; } = false;

        [Column("patientunacceptablebehavior")]
        public String PatientUnacceptableBehavior { get; set; } = String.Empty;

        // binded enities
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Timeslot? Timeslot { get; set; }

        public Booking? Booking { get; set; }

        public MedicalRecord? MedicalRecord { get; set; }
    }
}
