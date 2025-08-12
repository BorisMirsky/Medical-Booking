using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using MedicalBookingProject.Application.Scripts;
using MedicalBookingProject.DataAccess;


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
            if (_dbContext.Admins.Count() == 0)              // or !_dbContext.Admins.Any() 
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
            // if login is wrong                                                                                   
            if (userEntity == null)
            {
                return null;
            }
            // if password is wrong
            if (userEntity == null || BCrypt.Verify(password, userEntity.Password) == false)
            {
                return null;
            }
            JwtGenerator tokenInstance = new(_configuration);
            string token = tokenInstance.CreateTokenDescriptor(email,
                                                userEntity.UserName!,
                                                userEntity.Role!);
            userEntity.Token = token;
            //userEntity.IsActive = true;
            return userEntity;
        }
    }
}
