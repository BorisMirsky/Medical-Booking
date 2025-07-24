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
//using MedicalBookingProject.DataAccess.Scripts;
//using MedicalBookingProject.Application.Scripts;


namespace MedicalBookingProject.DataAccess.Repo
{
    using BCrypt.Net;
    using MedicalBookingProject.Application.Scripts;
    using MedicalBookingProject.DataAccess;
    using MedicalBookingProject.Domain.Models.Shedules;
    using Microsoft.AspNetCore.Authorization;
    using System.Diagnostics;

    public class DoctorRepo : IDoctorRepo
    {

        private readonly MedicalBookingDbContext _dbContext;

        private readonly IConfiguration _configuration;

        public DoctorRepo(MedicalBookingDbContext dbContext, IConfiguration configuration) {
            _dbContext = dbContext;
            _configuration = configuration;
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
            Doctor? entity = await _dbContext.Doctors
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            return entity!; 
        }


        public async Task<List<Doctor>> GetAll()
        {
            var entities = await _dbContext.Doctors
               .ToListAsync();
            return entities;
        }


        public async Task<List<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            //string speciality = "surgeon";
            var entities = await _dbContext.Doctors
               .Where(item => item.Speciality == speciality)
               .ToListAsync();
            if (entities.Count() == 0)
            {
                Debug.WriteLine("Doctors with speciality {speciality} not found");
                //throw new Exception($"Doctors with speciality {speciality} not found");
            }

            return entities;
        }


        public async Task<Doctor> GetDoctorBySpecialityAndName(string speciality, string username)
        {
            var entity = await _dbContext.Doctors
               .Where(item => item.Speciality == speciality && item.UserName == username)
               .FirstOrDefaultAsync();
            if (entity == null)
            {
                Debug.WriteLine("Doctor not found");
                //throw new Exception($"Doctor not found");
            }

            return entity!;
        }


        public async Task<Doctor?> Login(string email, string password)
        {
            Doctor? userEntity = await _dbContext.Doctors.FirstOrDefaultAsync(u => u.Email == email);
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
                                                userEntity.Rolename!);
            userEntity.Token = token;
            userEntity.IsActive = true;
            return userEntity;
        }
    }
}
