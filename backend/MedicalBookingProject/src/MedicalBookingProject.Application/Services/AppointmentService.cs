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


        public async Task<Guid> CreateAppointment(Guid doctorId, Guid patientId,
                                    Guid timeslotId, Guid bookingId,
                                     string? patientCame, string? patientIsLate,
                                     string? patientUnacceptableBehavior)
        {
            return await _appointmentRepo.Create(doctorId, patientId,
                                    timeslotId, bookingId,
                                     patientCame, patientIsLate,
                                      patientUnacceptableBehavior);
        }       

        // public async Task<Appointment> GetAppointment(Guid id)
        //{
        //    return await _appointmentRepo.Get(id);
        //}
        
        //public async Task<Guid> UpdateAppointment(Guid Id)
        //{
        //    await _appointmentRepo.Update(Id);
        //    return Id;
        //}
    }
}
