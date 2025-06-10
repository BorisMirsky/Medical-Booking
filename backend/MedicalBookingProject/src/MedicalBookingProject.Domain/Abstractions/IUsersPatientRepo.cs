using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IUsersPatientRepo
    {
        Task<Patient> Register(string email, string password, string username, string role, string gender);
        Task<Patient> Get(Guid id);
    }
}
