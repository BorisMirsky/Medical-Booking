using MedicalBookingProject.Domain.Models.Shedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ISheduleService
    {
        Task<Guid> CreateShedule(Shedule shedule);
        Task<Shedule> GetSlot(Guid id);   // + by day, by patient, by doctor
        Task<Guid> BookingSlot(Guid slotid, Guid patientid, Boolean isbooked);   
    }
}



