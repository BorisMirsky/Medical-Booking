using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingRepo
    {
        Task<Guid> Create(Guid slotid, Guid? patientid, Guid doctorid,
                          Boolean? isbooked, Guid? cancelledby, 
                          DateTime? cancelledat);
        Task<Booking> GetOneBooking(Guid id);
    }
}
