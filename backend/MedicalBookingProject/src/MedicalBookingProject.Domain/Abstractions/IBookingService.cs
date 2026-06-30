
namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingService
    {
        Task<Guid> CreateBooking(Guid slotid,
                                 Guid patientId,
                                 Guid doctorId,
                                 Boolean isBooked);

        Task<List<BookingDTO>> GetByPatient(Guid id);
        
        Task<List<BookingDTO>> GetByDoctor(Guid id);

        Task SetBookingClosed(Guid id);
    }
}
