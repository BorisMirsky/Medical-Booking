using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.DataAccess;
//using MedicalBookingProject.DataAccess.Scripts;
using MedicalBookingProject.Application.Services; 
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Application.Scripts;




namespace MedicalBookingProject.Application.Services
{
    public class SheduleService : ISheduleService
    {

        private readonly ISheduleRepo _sheduleRepo;

        public SheduleService(ISheduleRepo sheduleRepo)
        {
            _sheduleRepo = sheduleRepo;
        }


        public async Task<Guid> CreateShedule(Guid doctorId, DateTime startDay, int days,
            int timeStart, int timeStop, int timeChunk)   
        {
            CreateSlots slots = new(startDay.Year, startDay.Month, startDay.Day,
                                timeStart, timeStop, timeChunk, days);
            List<List<String>> splittedSlots = slots.Run();
            return await _sheduleRepo.Create(splittedSlots, doctorId);
        }


        public async Task<Shedule> GetSlot(Guid id)
        {
            return await _sheduleRepo.Get(id);
        }


        public async Task<Guid> UpdateSlot(Guid slotid, Guid patientid, Boolean isbooked)
        {
            Guid? _patientid = (isbooked == true) ? patientid : null;
            return await _sheduleRepo.Update(slotid, _patientid, isbooked); 
        }
    }
}
