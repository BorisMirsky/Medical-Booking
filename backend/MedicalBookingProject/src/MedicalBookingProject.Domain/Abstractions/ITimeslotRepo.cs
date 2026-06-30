using MedicalBookingProject.Domain.Models.Shedules;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ITimeslotRepo
    {
        Task<int> Create(List<List<string>> someList, Guid Id);
        Task<Timeslot> Get(Guid id);
        Task<List<Timeslot>> GetByDoctor(Guid id);
        Task<List<Timeslot>> GetByDoctorAndDay(Guid id, DateTime day);
        Task Update(Guid slotid, Guid patientid, Boolean isbooked);
    }
}
