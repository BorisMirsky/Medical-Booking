using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IBookingRepo
    {
        Task<Guid> Create(Guid slotid, Guid patientid, Guid doctorid, Boolean isbooked);
        //Boolean isbooked, Guid? cancelledby, DateTime? cancelledat);

        Task<Guid> PatchIsCLosed(Guid id);
        Task<List<BookingDTO>> GetByPatient(Guid id);
        Task<List<BookingDTO>> GetByDoctor(Guid id);
    }
}
