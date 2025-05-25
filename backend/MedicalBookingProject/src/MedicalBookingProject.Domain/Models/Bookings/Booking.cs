using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MedicalBookingProject.Domain.Models.Bookings
{
    public class Booking
    {
        public Guid Id { get; set; }                // лишнее
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Boolean? WasCancelled { get; set; } = false;    
        public Guid? CancelledBy { get; set; }             
        public DateTime? CancelledAt { get; set; }

    }
}
