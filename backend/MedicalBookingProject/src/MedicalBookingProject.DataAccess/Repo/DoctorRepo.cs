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



namespace MedicalBookingProject.DataAccess.Repo
{
    using BCrypt.Net;
    using MedicalBookingProject.DataAccess;
    using Microsoft.AspNetCore.Authorization;
    using System.Diagnostics;

    public class DoctorRepo : IDoctorRepo
    {
        private readonly MedicalBookingDbContext _dbContext;
        public DoctorRepo(MedicalBookingDbContext dbContext) {
            _dbContext = dbContext;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<Doctor> Register(string email, string password,
                                               string username, string role,
                                               string speciality, string gender)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            Doctor doctor = new(email, hashedPassword,
                                        role, speciality,
                                        username, gender);
            doctor.Id = Guid.NewGuid();
            _dbContext.Doctors.Add(doctor!);
            await _dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> Get(Guid id)
        {
            var entities = await _dbContext.Doctors
                .AsNoTracking()
                .ToListAsync();
            var entity = entities
               .Where(item => item.Id == id)
               .ToList()
               .FirstOrDefault();
            if (entity == null)
            {
                Debug.WriteLine("Order with id {id} not found");
                throw new Exception($"Order with id {id} not found");
            }
            Doctor doctor = new(entity.UserName, entity.Password,
                                       entity.Speciality, 
                                       entity.Email, entity.Rolename, entity.Gender);
            return doctor!;
        }

    }
}
