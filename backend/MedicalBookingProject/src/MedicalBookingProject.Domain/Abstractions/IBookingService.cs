using MedicalBookingProject.Domain.Models.Bookings;




namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingService
    {
        Task<Guid> CreateBooking(Guid slotid,
                                 Guid patientId,
                                 Guid doctorId,
                                 Boolean isBooked,
                                 Guid? cancelledby, 
                                 DateTime? cancelledat);

        Task<Booking> GetOneBooking(Guid id); 
    }
}
