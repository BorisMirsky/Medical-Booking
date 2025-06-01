using MedicalBookingProject.Domain.Models.Appointments;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentRepo
    {
        Task<Guid> Create(Appointment app);
        Task<Appointment> Get(Guid id);
        Task<Guid> UpdateUnacceptableBehavior(Guid id, String description);
    }
}
