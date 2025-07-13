using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointment(Guid doctorId, Guid patientId,
                                    Guid timeslotId, Guid bookingId,
                                     string? patientCame, string? patientIsLate,
                                     string? patientUnacceptableBehavior);
        
        //Task<Appointment> GetAppointment(Guid id);
        
        //Task<Guid> UpdateAppointment(Guid Id);


        //                             //Boolean? Treatment, Boolean? MakingDiagnosis,
        //                             //Boolean? ReferralTests, Boolean? VisualExaminationPatient,
        //                             //int FinalCost);
    }
}
