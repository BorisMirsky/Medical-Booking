

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingRepo
    {
        Task<Guid> Create(Guid slotid, Guid patientid, Guid doctorid, Boolean isbooked);
        Task SetBookingClosed(Guid id);
        Task<List<BookingDTO>> GetByPatient(Guid id);
        Task<List<BookingDTO>> GetByDoctor(Guid id);
    }
}
