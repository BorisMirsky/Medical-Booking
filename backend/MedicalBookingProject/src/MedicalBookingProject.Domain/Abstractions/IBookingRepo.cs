using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingRepo
    {
        Task<Guid> Create(Guid slotid, Guid? cancelledby, DateTime? cancelledat);
        //Guid patientid, Guid doctorid, Boolean? isbooked,

        Task<Booking> GetOneBooking(Guid id);
    }
}
