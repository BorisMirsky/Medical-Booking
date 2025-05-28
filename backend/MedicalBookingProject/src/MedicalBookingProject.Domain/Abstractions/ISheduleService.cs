using MedicalBookingProject.Domain.Models.Shedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Abstractions;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ISheduleService
    {
        Task<Guid> CreateShedule(Guid doctorId, DateTime startDay, int days,
                       int timeStart, int timeStop, int timeChunk);  
        Task<Shedule> GetSlot(Guid id);   
        Task<Guid> BookingSlot(Guid slotid, Guid patientid, Boolean isbooked);   
    }
}



