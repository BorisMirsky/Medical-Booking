using MedicalBookingProject.Domain.Models.Appointments;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentRepo
    {
        Task<Guid> Create(Guid doctorId, Guid patientId,
                                    Guid timeslotId, Guid bookingId,
                                     string? patientCame, string? patientIsLate,
                                     string? patientUnacceptableBehavior);
        //Task<Appointment> Get(Guid id);
        //Task<Guid> Update(Guid Id);
    }
}
