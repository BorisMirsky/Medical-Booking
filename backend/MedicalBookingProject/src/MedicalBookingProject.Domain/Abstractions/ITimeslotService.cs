using MedicalBookingProject.Domain.Models.Shedules;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ITimeslotService
    {
        Task<Guid> CreateTimeslot(Guid doctorId,
                DateTime startDay, int days,
               int timeStart, int timeStop, int timeChunk);
        Task<Timeslot> GetTimeslot(Guid id);
        Task<List<Timeslot>> GetTimeslotsByDoctor(Guid id);
        Task<List<Timeslot>> GetByDoctorIdAndDay(Guid id, DateTime day);
        Task<Guid> UpdateTimeslot(Guid slotid, Guid patientid, Boolean isbooked);
    }
}
