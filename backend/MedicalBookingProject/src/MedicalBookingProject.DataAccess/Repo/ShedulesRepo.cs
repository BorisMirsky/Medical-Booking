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


        public async Task<Guid> Create(List<List<String>> slotsList, Guid doctorId )   
        {
            Guid sheduleIdGuid = Guid.NewGuid();      // только чтобы вернуть
            int Id = 0;                               // порядковый номер
            foreach (var slot in slotsList)
            {
                Guid slotId = Guid.NewGuid();
                Id++;
                var entity = new SheduleEntity 
                {
                    Id = Id,
                    SlotId = slotId,
                    DoctorId = doctorId, 
                    SlotDatetimeStart = slot[0],
                    SlotDatetimeStop = slot[1],
                };
                await _context.SheduleEntities.AddAsync(entity);
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
            var shedule = new Shedule(entitie.DoctorId,
                                      entitie.SlotDatetimeStart,
                                      entitie.SlotDatetimeStop);
            shedule.Id = entitie.SlotId;
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
