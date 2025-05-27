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
        public Guid? Id { get; set; } = null;
        public Shedule(Guid doctorId, DateTime startDay, int days,
                       int timeStart, int timeStop, int timeChunk)   
        {
            DoctorId = doctorId;
            StartDay = startDay;
            Days = days;
            TimeStart = timeStart;
            TimeStop = timeStop;
            TimeChunk = timeChunk;
        }
        public Guid DoctorId { get; set; }
        public DateTime StartDay { get; set; }         
        public int Days { get; set; }
        public int TimeStart { get; set; }
        public int TimeStop { get; set; }
        public int TimeChunk { get; set; }
        public Boolean? IsBooked { get; set; }
        public Guid? UserPatientId { get; set; }
    }
}
