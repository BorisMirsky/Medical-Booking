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


        public async Task<Guid> Create(List<List<String>> slotsList, Guid doctorId)
        {
            Guid sheduleIdGuid = Guid.NewGuid();     
            foreach (var slot in slotsList)
            {
                var entity = new Timeslot(); 
                entity.Id = Guid.NewGuid();
                entity.DoctorId = doctorId;
                entity.DatetimeStart = slot[0];
                entity.DatetimeStop = slot[1];
                await _context.Timeslots.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            return sheduleIdGuid;
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



        public async Task<Guid> Update(Guid slotId, 
                                        Guid patientId, 
                                        Boolean isBooked)
        {
            await _context.Timeslots
                .Where(item => item.Id == slotId)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.IsBooked, s => isBooked)
                );
            return slotId;
        }
    }
}
