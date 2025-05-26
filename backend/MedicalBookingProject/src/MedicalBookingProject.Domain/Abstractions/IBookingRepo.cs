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
        Task<Guid> Create(Guid id, Guid id1);
        Task<Booking> GetOneBooking(Guid id);
        Task<Booking> Cancel(Guid id);
        //Task<Shedule> Get(Guid id);   // + all, by day, by patient
        //Task<Guid> Booking(Guid id, Guid id1);
    }
}
