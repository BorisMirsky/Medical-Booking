using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAdminRepo
    {
        Task<Admin?> Register(string email, string password);

        Task<Admin?> Login(string email, string password);
    }
}
