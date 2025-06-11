using MedicalBookingProject.Domain.Models.Bookings;




namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingService
    {
        Task<Guid> CreateBooking(Guid slotid, 
                                 Guid? cancelledby, 
                                 DateTime? cancelledat,
                                 Guid patientId, 
                                 //Guid doctorId, 
                                 Boolean? isBooked);

        Task<Booking> GetOneBooking(Guid id); 
    }
}
