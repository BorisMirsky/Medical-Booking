using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingRepo
    {
        Task<Guid> Create(Guid slotid, Guid patientid, 
                          Boolean wascancelled, Guid? cancelledby, 
                          DateTime? CancelledAt);
        Task<Booking> GetOneBooking(Guid id);
    }
}
