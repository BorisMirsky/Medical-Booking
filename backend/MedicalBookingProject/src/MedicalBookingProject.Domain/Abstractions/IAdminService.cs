using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAdminService
    {
        Task<Admin?> Register(string email, string password);
        Task<Admin?> LoginAccount(string email, string password);
    }
}
