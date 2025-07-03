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
        //Guid? cancelledby, DateTime? cancelledat);

        //Task<Booking> GetOneBooking(Guid id); 
        Task<IEnumerable<BookingDTO>> GetByPatient(Guid patientId);
        Task<List<Booking>> GetByDoctor(Guid doctorId);
    }
}
