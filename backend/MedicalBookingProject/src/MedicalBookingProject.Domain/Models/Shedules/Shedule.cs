using MedicalBookingProject.Domain.Models.Messages;
using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Shedules
{
    public class Shedule
    {
        public Shedule(Guid doctorid, string slotdatetimestart, string slotdatetimestop)
        {
            DoctorId = doctorid;
            SlotDatetimeStart = slotdatetimestart;
            SlotDatetimeStop = slotdatetimestop;
        }
        public Guid Id { get; set; }
        public string SlotDatetimeStart { get; set; }
        public string SlotDatetimeStop { get; set; }
        public Guid DoctorId { get; set; }
        public Boolean? IsBooked { get; set; } = false;
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
