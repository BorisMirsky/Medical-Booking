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
    using MedicalBookingProject.Domain.Models.Shedules;
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
            Doctor? entity = await _dbContext.Doctors
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            return entity!; 
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

    }
}
