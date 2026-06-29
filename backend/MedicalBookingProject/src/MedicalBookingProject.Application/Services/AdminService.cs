

using BCrypt_Alias = BCrypt.Net.BCrypt;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Scripts;
using Microsoft.Extensions.Configuration;


namespace MedicalBookingProject.Application.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepo _adminRepo;
        private readonly IConfiguration _configuration;

        public AdminService(IAdminRepo adminRepo, IConfiguration configuration)
        {
            _adminRepo = adminRepo;
            _configuration = configuration;
        }

        public async Task<Admin?> Register(string email, string password)
        {
            var existingAdmin = await _adminRepo.GetAdminAsync();
            if (existingAdmin != null)
                return null; // админ уже существует

            var hashedPassword = BCrypt_Alias.HashPassword(password);
            var admin = new Admin
            {
                Id = Guid.NewGuid(),
                Email = email,
                Password = hashedPassword,
                UserName = "ADMIN",
                Role = "Admin",
                RoleId = 1
            };

            await _adminRepo.AddAsync(admin);
            await _adminRepo.SaveChangesAsync();
            return admin;
        }

        public async Task<Admin?> LoginAccount(string email, string password)
        {
            var admin = await _adminRepo.GetAdminAsync();
            if (admin == null)
                return null;

            if (admin.Email != email || !BCrypt_Alias.Verify(password, admin.Password))
                return null;

            var tokenGenerator = new JwtGenerator(_configuration);
            var token = tokenGenerator.CreateTokenDescriptor(email, admin.UserName!, admin.Role!);

            admin.Token = token;
            await _adminRepo.SaveChangesAsync();

            return admin;
        }
    }
}
