using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MedicalBookingProject.Application.Scripts;



namespace MedicalBookingProject.DataAccess.Repo
{

    using BCrypt.Net;


    public class AdminRepo : IAdminRepo
    {

        private readonly MedicalBookingDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AdminRepo(MedicalBookingDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Admin?> Register(string email, string password)
        {
            if (_dbContext.Admins.Count() == 0)       
            {
                var hashedPassword = BCrypt.HashPassword(password);
                Admin admin = new();
                admin.Id = Guid.NewGuid();
                admin.Email = email;
                admin.Password = hashedPassword;
                _dbContext.Admins.Add(admin!);
                await _dbContext.SaveChangesAsync();
                return admin;
            }           
            return null;
        }


        public async Task<Admin?> Login(string email, string password)
        {
            Admin? userEntity = await _dbContext.Admins.FirstOrDefaultAsync(u => u.Email == email);
                                                                                 
            if (userEntity == null)
            {
                return null;
            }

            if (userEntity == null || BCrypt.Verify(password, userEntity.Password) == false)
            {
                return null;
            }

            JwtGenerator tokenInstance = new(_configuration);
            string token = tokenInstance.CreateTokenDescriptor(email,
                                                userEntity.UserName!,
                                                userEntity.Role!);
            userEntity.Token = token;
            return userEntity;
        }
    }
}
