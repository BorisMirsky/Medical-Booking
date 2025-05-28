using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Shedules
{
    public class Timeslot
    {
        public Timeslot(Guid doctorid, string slotdatetimestart, string slotdatetimestop)
        {
            DoctorId = doctorid;
            slotDatetimeStart = slotdatetimestart;
            slotDatetimeStop = slotdatetimestop;
        }
        public Guid? Id { get; set; }
        public Shedule? Shedule { get; set; }
        public Guid? SheduleId { get; set; }
        public string slotDatetimeStart { get; set; }
        public string slotDatetimeStop { get; set; }
        public Guid DoctorId { get; set; }
        public Boolean? IsBooked { get; set; } = false;
        public Guid? PatientId { get; set; } = null;                               
    }
}
