using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Users;




namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingService
    {
        Task<Guid> CreateBooking(Guid slotid,
                                 Guid patientId,
                                 Guid doctorId,
                                 Boolean isBooked);

        //Task<Booking> GetOneBooking(Guid id); 
        Task<List<BookingDTO>> GetByPatient(Guid id);
        Task<List<BookingDTO>> GetByDoctor(Guid id);
    }
}
