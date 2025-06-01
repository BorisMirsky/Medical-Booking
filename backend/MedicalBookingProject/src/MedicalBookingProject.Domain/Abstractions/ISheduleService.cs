using MedicalBookingProject.Domain.Models.Shedules;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ISheduleService
    {
        Task<Guid> CreateShedule(Guid doctorId, DateTime startDay, int days,
                       int timeStart, int timeStop, int timeChunk);  
        Task<Shedule> GetSlot(Guid id); 
        Task<Guid> UpdateSlot(Guid slotid, Guid patientid, Boolean isbooked);   
    }
}



