using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Domain.Models.Appointments
{
    [Table("appointments")]
    public class Appointment
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        public Booking Booking { get; set; }          // ?

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
        public Boolean? PatientCame { get; set; }

        [Column("patientislate")]
        public Boolean? PatientIsLate { get; set; }

        [Column("patientunacceptablebehavior")]
        public String? PatientUnacceptableBehavior { get; set; } 

        // services rendered
        [Column("visualexamination")]
        public Boolean? VisualExamination { get; set; }

        [Column("referraltests")]
        public Boolean? ReferralTests { get; set; }

        [Column("makingdiagnosis")]
        public Boolean? MakingDiagnosis { get; set; }

        [Column("treatment")]
        public Boolean? Treatment { get; set; }

        [Column("finalcost")]
        public int? FinalCost { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

        public Timeslot Timeslot { get; set; }
    }
}
