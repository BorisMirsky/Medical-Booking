using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.DataAccess.Entities;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.DataAccess.Scripts;             // get slots
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class ShedulesRepo : ISheduleRepo
    {
        private readonly MedicalBookingDbContext _context;

        public ShedulesRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Create(Shedule shedule)
        {
            Guid sheduleIdGuid = Guid.NewGuid();      // только чтобы вернуть
            int sheduleId = 0;
            CreateSlots slots = new (shedule.StartDay.Year,
                                            shedule.StartDay.Month,
                                            shedule.StartDay.Day,
                                            shedule.TimeStart, shedule.TimeStop,
                                            shedule.TimeChunk, shedule.Days);
            foreach (var slot in slots.Run())
            {
                Guid slotid = Guid.NewGuid();
                sheduleId++;
                DateTime startDay = new (shedule.StartDay.Year, shedule.StartDay.Month, shedule.StartDay.Day);
                var day = startDay.Date.ToShortDateString();
                var sheduleEntity = new SheduleEntity
                {
                    Id = sheduleId,
                    SlotId = slotid,
                    DoctorId = shedule.DoctorId, 
                    SlotDatetimeStart = slot[0],
                    SlotDatetimeStop = slot[1],
                    StartDay = day.ToString(),
                    Days = shedule.Days,
                    TimeStart = shedule.TimeStart,
                    TimeStop = shedule.TimeStop,
                    TimeChunk = shedule.TimeChunk
                };
                await _context.SheduleEntities.AddAsync(sheduleEntity);
                await _context.SaveChangesAsync();
            }
            return sheduleIdGuid;
        }


        public async Task<Shedule> Get(Guid id)
        {
            var entities = await _context.SheduleEntities
                .AsNoTracking()
                .ToListAsync();
            var entitie = entities
               .Where(item => item.SlotId == id)
               .ToList()
               .FirstOrDefault();
            DateTime myDate = DateTime.ParseExact(entitie!.StartDay, "M/d/yyyy",
                                       CultureInfo.InvariantCulture);
            var shedule = new Shedule(entitie.DoctorId, myDate, 
                                        entitie.Days, entitie.TimeStart, 
                                        entitie.TimeStop, entitie.TimeChunk);
            return shedule;
        }


        // Patch
        public async Task<Guid> Booking(Guid slotid, Guid patientid, Boolean isbooked)
        {
            await _context.SheduleEntities
                .Where(item => item.SlotId == slotid)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.PatientId, s => patientid)
                .SetProperty(s => s.IsBooked, s => isbooked)     // invertes bool value     
                );
            return slotid;
        }
    }
}
