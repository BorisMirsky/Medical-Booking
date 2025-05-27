using MedicalBookingProject.Domain.Models.Shedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ISheduleRepo
    {
        Task<Guid> Create(Shedule shedule);
        Task<Shedule> Get(Guid id);   // + all, by day, by patient
        Task<Guid> Booking(Guid slotid, Guid patientid, Boolean isbooked);  
    }
}
