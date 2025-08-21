using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointment(Guid doctorId, Guid patientId,
                                    Guid timeslotId, Guid bookingId,
                                     string? patientCame, string? patientIsLate,
                                     string? patientUnacceptableBehavior);
        
        Task<Guid> GetByBookingId(Guid id);

        Task<List<AppointmentDTO>> GetByPatient(Guid id);

        Task<List<AppointmentDTO>> GetByDoctor(Guid id);

        Task<List<AppointmentDTO>> GetAll();
    }
}
