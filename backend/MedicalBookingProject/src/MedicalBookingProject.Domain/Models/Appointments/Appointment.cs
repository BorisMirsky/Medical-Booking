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

        [Column("timeslotid")]
        public Guid TimeslotId { get; set; }

        // behavior of patient
        [Column("patientcame")]
        public string? PatientCame { get; set; } 

        [Column("patientislate")]
        public string? PatientIsLate { get; set; } 

        [Column("patientunacceptablebehavior")]
        public string? PatientUnacceptableBehavior { get; set; } 

        // binded enities
        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Timeslot? Timeslot { get; set; }

        public Booking? Booking { get; set; }

        public MedicalRecord? MedicalRecord { get; set; }
    }
}
