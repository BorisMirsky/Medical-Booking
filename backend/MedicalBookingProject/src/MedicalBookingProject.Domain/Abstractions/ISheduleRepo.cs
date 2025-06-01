using MedicalBookingProject.Domain.Models.Shedules;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ISheduleRepo
    {
        Task<Guid> Create(List<List<string>> someList, Guid id); 
        Task<Shedule> Get(Guid id);   
        Task<Guid> Update(Guid slotid, Guid? patientid, Boolean isbooked);  
    }
}
