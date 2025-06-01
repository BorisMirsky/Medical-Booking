using MedicalBookingProject.Domain.Models.Messages;
using MedicalBookingProject.Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalBookingProject.Domain.Models.Shedules
{
    [Table("shedules")]
    public class Shedule
    {
        public Shedule(Guid doctorId, string slotDatetimeStart, 
                        string slotDatetimeStop) 
        {
            DoctorId = doctorId;
            SlotDatetimeStart = slotDatetimeStart;
            SlotDatetimeStop = slotDatetimeStop;
        }
        [Key]
        [Column("slotid")]
        public Guid SlotId { get; set; }

        [Column("slotdatetimestart")]
        public string SlotDatetimeStart { get; set; }

        [Column("slotdatetimestop")]
        public string SlotDatetimeStop { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("isbooked")]
        public Boolean? IsBooked { get; set; } = false;

        [Column("patientid")]
        public Guid? PatientId { get; set; } = null;

    }
}






//public Shedule(Guid doctorId, DateTime startDay, int days,
//               int timeStart, int timeStop, int timeChunk)   
//{
//    DoctorId = doctorId;
//    StartDay = startDay;
//    Days = days;
//    TimeStart = timeStart;
//    TimeStop = timeStop;
//    TimeChunk = timeChunk;
//}
//public Guid DoctorId { get; set; }
//public DateTime StartDay { get; set; }         
//public int Days { get; set; }
//public int TimeStart { get; set; }
//public int TimeStop { get; set; }
//public int TimeChunk { get; set; }
//public Boolean? IsBooked { get; set; }
//public Guid? UserPatientId { get; set; }
