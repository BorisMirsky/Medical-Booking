using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.DataAccess.Scripts;
using Microsoft.AspNetCore.Mvc;




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
            int timeStart, int timeStop, int timeChunk)   //Shedule shedule)
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


        public async Task<Guid> BookingSlot(Guid slotid, Guid patientid, Boolean isbooked)
        {
            return await _sheduleRepo.Booking(slotid, patientid, isbooked); 
        }
    }
}
