using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Shedules;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.Application.Services;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Application.Scripts;



namespace MedicalBookingProject.Application.Services
{
    public class TimeslotService : ITimeslotService
    {

        private readonly ITimeslotRepo _timeslotRepo;

        public TimeslotService(ITimeslotRepo timeslotRepo)
        {
            _timeslotRepo = timeslotRepo;
        }

        public async Task<Guid> CreateTimeslot(Guid id,
                                                DateTime startDay, int days,
                                                int timeStart, int timeStop, int timeChunk)
        {
            CreateSlots slots = new(startDay.Year, startDay.Month, startDay.Day,
                                timeStart, timeStop, timeChunk, days);
            List<List<String>> splittedSlots = slots.Run();
            return await _timeslotRepo.Create(splittedSlots, id);
        }


        public async Task<Timeslot> GetTimeslot(Guid id)
        {
            return await _timeslotRepo.Get(id);
        }


        public async Task<List<Timeslot>> GetTimeslotsByDoctor(Guid id)
        {
            return await _timeslotRepo.GetByDoctor(id);
        }


        public async Task<List<Timeslot>> GetByDoctorIdAndDay(Guid id, DateTime day)
        {
            return await _timeslotRepo.GetByDoctorAndDay(id, day); 
        }


        public async Task<Guid> UpdateTimeslot(Guid slotid, Guid patientid, Boolean isbooked)
        {
            Guid? _patientid = (isbooked == true) ? patientid : null;
            return await _timeslotRepo.Update(slotid, _patientid, isbooked);
        }
    }
}
