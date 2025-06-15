using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;





namespace MedicalBookingProject.Domain.Models.Shedules
{
    [Table("timeslots")]
    public class Timeslot
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("datetimestart")]
        public string DatetimeStart { get; set; } = String.Empty;

        [Column("datetimestop")]
        public string DatetimeStop { get; set; } = String.Empty;

        [Column("doctorid")]
        public Guid DoctorId { get; set; } = Guid.Empty;

        [Column("isbooked")]
        public Boolean IsBooked { get; set; } = false;

        [Column("patientid")]
        public Guid PatientId { get; set; } = Guid.Empty;
        
        public Booking? Booking { get; set; }

        public Patient? Patient { get; set; }

        public Doctor? Doctor { get; set; }
    }
}


//public Shedule(Guid doctorId, string slotDatetimeStart,
//                string slotDatetimeStop)
//{
//    DoctorId = doctorId;
//    SlotDatetimeStart = slotDatetimeStart;
//    SlotDatetimeStop = slotDatetimeStop;
//}