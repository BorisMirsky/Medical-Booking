using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Bookings
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Boolean? WasCancelled { get; set; } = false;    // last cancel only?
        public Guid? WasCancelledBy { get; set; }              // by patient only  
        public DateTime? WasCancelledAt { get; set; }

    }
}
