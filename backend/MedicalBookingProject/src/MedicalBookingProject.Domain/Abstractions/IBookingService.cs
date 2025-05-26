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
        Task<Guid> CreateBooking(Guid id, Guid id1); // Booking booking);
        Task<Booking> GetOneBooking(Guid id); 
        Task<Booking> CancelBooking(Guid id); 
        //Task<Shedule> GetSlot(Guid id);   // + by day, by patient, by doctor
        //Task<Guid> BookingSlot(Guid id, Guid id1);
    }
}
