using MedicalBookingProject.Domain.Models.Appointments;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentRepo
    {
        Task<Guid> Create(Guid bookingId);
        Task<Appointment> Get(Guid id);
        Task<Guid> Update(Guid Id, Boolean? PatientCame, Boolean? PatientIsLate,
                                     string? PatientUnacceptableBehavior,
                                     Boolean? Treatment, Boolean? MakingDiagnosis,
                                     Boolean? ReferralTests, Boolean? VisualExaminationPatient,
                                     int FinalCost);
    }
}
