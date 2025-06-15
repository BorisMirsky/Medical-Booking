using MedicalBookingProject.Domain.Models.Appointments;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Domain.Models.Bookings
{
    [Table("bookings")]
    public class Booking
    {
        //public Booking(Guid slotId)  
        //{
        //    TimeslotId = slotId;
        //}

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("slotid")]
        public Guid TimeslotId { get; set; }

        [Column("isbooked")]
        public Boolean IsBooked { get; set; }

        [Column("cancelledby")]
        public Guid CancelledBy { get; set; } = Guid.Empty;

        [Column("bookingorcanceldatetime")]
        public DateTime? BookingOrCancelDatetime { get; set; }

        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }

        public Appointment? Appointment { get; set; }

        public Timeslot? Timeslot { get; set; }
    }
}
