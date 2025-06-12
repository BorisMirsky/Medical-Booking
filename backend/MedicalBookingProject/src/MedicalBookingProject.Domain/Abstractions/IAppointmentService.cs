using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointment(Guid bookingId);
        Task<Appointment> GetAppointment(Guid id);
        Task<Guid>UpdateAppointment(Guid Id, Boolean? PatientCame, Boolean? PatientIsLate,
                                     string? PatientUnacceptableBehavior,
                                     Boolean? Treatment, Boolean? MakingDiagnosis,
                                     Boolean? ReferralTests, Boolean? VisualExaminationPatient,
                                     int FinalCost);
    }
}
