using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Shedules;
using Microsoft.EntityFrameworkCore;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class TimeslotRepo : ITimeslotRepo
    {

        private readonly MedicalBookingDbContext _context;

        public TimeslotRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }


        public async Task<int> Create(List<List<string>> slotsList, Guid doctorId)
        {
            int count = 0;
            foreach (var slot in slotsList)
            {
                var entity = new Timeslot
                {
                    Id = Guid.NewGuid(),
                    DoctorId = doctorId,
                    DatetimeStart = slot[0],
                    DatetimeStop = slot[1]
                };
                await _context.Timeslots.AddAsync(entity);
                count++;
            }
            await _context.SaveChangesAsync(); 
            return count;
        }




        public async Task<Timeslot> Get(Guid id)
        {
            Timeslot? entity = await _context.Timeslots
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(s => s.Id == id);
            return entity!;
        }


        public async Task<List<Timeslot>> GetByDoctor(Guid id)
        {
            var entities = await _context.Timeslots
                                     .Where(item => item.DoctorId == id)
                                     .ToListAsync();
            return entities;
        }


        public async Task<List<Timeslot>> GetByDoctorAndDay(Guid id, DateTime day)
        {
            var entities = await _context.Timeslots
                                                 .Where(item => item.DoctorId == id) 
                                                 .ToListAsync();
            return entities!;
        }



        public async Task Update(Guid slotId, Guid patientId, Boolean isBooked)
        {
            var slot = await _context.Timeslots.FirstOrDefaultAsync(s => s.Id == slotId);
            if (slot != null)
            {
                slot.IsBooked = isBooked;
                slot.PatientId = patientId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
