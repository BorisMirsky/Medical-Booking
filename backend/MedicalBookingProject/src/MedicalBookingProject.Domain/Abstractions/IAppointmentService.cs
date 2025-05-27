using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Models.Appointments;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAppointmentService
    {
        Task<Guid> CreateAppointment(Appointment app);
        Task<Appointment> GetAppointment(Guid id);
        Task<Guid> UpdateUnacceptableBehavior(Guid id, String description);
    }
}
