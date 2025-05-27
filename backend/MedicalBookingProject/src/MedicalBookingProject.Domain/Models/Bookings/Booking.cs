using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MedicalBookingProject.Domain.Models.Bookings
{
    public class Booking
    {
        public Booking(Guid doctorId, Guid patientId, Guid slotId)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            SlotId = slotId;
        }
        public Guid Id { get; set; }                
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Boolean? IsBooked { get; set; } 
        public Boolean? WasCancelled { get; set; } 
        public Guid? CancelledBy { get; set; } = null;            // doctorId or PatientId
        public DateTime? CancelledAt { get; set; } = null;

    }
}
