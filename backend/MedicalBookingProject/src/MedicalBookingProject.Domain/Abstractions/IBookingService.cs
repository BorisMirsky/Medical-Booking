using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Models.Bookings;




namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingService
    {
        Task<Guid> CreateBooking(Guid slotid, Guid? patientid, 
                                  Guid doctorid, Boolean? isbooked, 
                                  Guid? cancelledby, DateTime? cancelledat);
        Task<Booking> GetOneBooking(Guid id); 
    }
}
