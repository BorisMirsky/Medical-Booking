using MedicalBookingProject.Domain.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Models.Shedules;



namespace MedicalBookingProject.Application.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepo;
        public AppointmentService(IAppointmentRepo appointmentRepo)
        {
            _appointmentRepo = appointmentRepo;
        }


        public async Task<Guid> CreateAppointment(Guid bookingId)
        {
            return await _appointmentRepo.Create(bookingId);
        }       

         public async Task<Appointment> GetAppointment(Guid id)
        {
            return await _appointmentRepo.Get(id);
        }
        
        public async Task<Guid> UpdateAppointment(Guid Id, Boolean? PatientCame, 
                                     Boolean? PatientIsLate,
                                     string? PatientUnacceptableBehavior,
                                     Boolean? Treatment, Boolean? MakingDiagnosis,
                                     Boolean? ReferralTests, Boolean? VisualExaminationPatient,
                                     int FinalCost)
        {
            await _appointmentRepo.Update(Id, PatientCame, PatientIsLate,
                                     PatientUnacceptableBehavior,
                                     Treatment, MakingDiagnosis,
                                     ReferralTests, VisualExaminationPatient,
                                     FinalCost);
            return Id;
        }
    }
}
