
using MedicalBookingProject.Application.Scripts;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Application.Services
{
    public class TimeslotService : ITimeslotService
    {

        private readonly ITimeslotRepo _timeslotRepo;

        public TimeslotService(ITimeslotRepo timeslotRepo)
        {
            _timeslotRepo = timeslotRepo;
        }

        public async Task<int> CreateTimeslot(Guid doctorId,
                                                DateTime startDay, int days,
                                                int timeStart, int timeStop, int timeChunk)
        {
            CreateSlots slots = new(startDay.Year, startDay.Month, startDay.Day,
                                timeStart, timeStop, timeChunk, days);
            List<List<String>> splittedSlots = slots.Run();
            return await _timeslotRepo.Create(splittedSlots, doctorId);
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


        public async Task UpdateTimeslot(Guid slotid, Guid patientid, Boolean isbooked)
        {
            Guid patientIdToUse = isbooked ? patientid : Guid.Empty;
            await _timeslotRepo.Update(slotid, patientIdToUse, isbooked);
        }
    }
}
