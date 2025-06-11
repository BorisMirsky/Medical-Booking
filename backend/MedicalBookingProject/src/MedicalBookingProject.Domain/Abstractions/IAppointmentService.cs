using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointment(Guid bookingId);
        Task<Appointment> GetAppointment(Guid id);
        Task<Guid> UpdateUnacceptableBehavior(Guid id, String description);
    }
}
