using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Application.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepo _adminRepo;

        public AdminService(IAdminRepo adminRepo)
        {
            _adminRepo = adminRepo;
        }

        public async Task<Admin> Register(string email, string password)
        {
            return await _adminRepo.Register(email, password);
        }

        public async Task<Admin> LoginAccount(string email, string password)
        {
            return await _adminRepo.Login(email, password);
        }
    }
}
