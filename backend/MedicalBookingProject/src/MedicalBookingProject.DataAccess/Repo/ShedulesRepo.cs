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
using MedicalBookingProject.DataAccess.Scripts;
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
                    //IsBooked = false
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
            DateTime myDate = DateTime.ParseExact(entitie.StartDay, "M/d/yyyy",
                                       CultureInfo.InvariantCulture);
            var shedule = new Shedule(entitie.DoctorId, myDate, 
                                        entitie.Days, entitie.TimeStart, 
                                        entitie.TimeStop, entitie.TimeChunk);
            return shedule;
        }

        public async Task<Guid> Booking(Guid id, Guid id1)
        {
            //var entities = await _context.SheduleEntities
            //    .AsNoTracking()
            //    .ToListAsync();
            //var entitie = entities
            //   .Where(item => item.SlotId == id)
            //   .ToList()
            //   .FirstOrDefault();
            //entitie.IsBooked = true;
            //entitie.PatientId = new Guid("2AF9B351-3D1E-4634-B2CE-38913117B666"); 
            //await _context.SaveChangesAsync();
            await _context.SheduleEntities
                .Where(item => item.SlotId == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.IsBooked, s => true)
                .SetProperty(s => s.PatientId, s => id1) //new Guid("2AF9B351-3D1E-4634-B2CE-38913117B666"))
                );
            return id;
        }
    }
}
