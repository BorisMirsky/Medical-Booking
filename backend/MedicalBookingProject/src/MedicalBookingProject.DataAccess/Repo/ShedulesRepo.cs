
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.Domain.Models.Shedules;
       
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


        // POST
        public async Task<Guid> Create(List<List<String>> slotsList, Guid doctorId )   
        {
            Guid sheduleIdGuid = Guid.NewGuid();      // только чтобы вернуть
            foreach (var slot in slotsList)
            {
                var entity = new Shedule(doctorId, slot[0], slot[1]);
                entity.SlotId = Guid.NewGuid();
                await _context.Shedules.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            return sheduleIdGuid;
        }


        // GET one
        public async Task<Shedule> Get(Guid id)
        {
            Shedule? entity = await _context.Shedules
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(s => s.SlotId == id);
            return entity!;
        }


        // Patch
        public async Task<Guid> Update(Guid slotId, Guid? patientId, Boolean isBooked)
        {
            await _context.Shedules
                .Where(item => item.SlotId == slotId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.PatientId, s => patientId)
                .SetProperty(s => s.IsBooked, s => isBooked)                 
                );
            return slotId;
        }
    }
}
