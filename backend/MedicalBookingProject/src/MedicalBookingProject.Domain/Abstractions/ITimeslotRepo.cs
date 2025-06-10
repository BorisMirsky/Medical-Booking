using MedicalBookingProject.Domain.Models.Shedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface ITimeslotRepo
    {
        Task<Guid> Create(List<List<string>> someList, Guid id);
        Task<Timeslot> Get(Guid id);
        Task<Guid> Update(Guid slotid, Guid? patientid, Boolean isbooked);
    }
}
