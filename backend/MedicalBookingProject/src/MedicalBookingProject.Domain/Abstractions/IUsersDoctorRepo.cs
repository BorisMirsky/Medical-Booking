using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IUsersDoctorRepo
    {
        Task<UserDoctor> Register(string email, string password, string username, string role, string speciality);
        Task<UserDoctor> Get(Guid id);
    }
}
