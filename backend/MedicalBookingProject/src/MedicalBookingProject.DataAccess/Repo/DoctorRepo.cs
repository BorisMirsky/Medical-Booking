using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



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
            var entities = await _dbContext.Doctors
               .Where(item => item.Speciality == speciality)
               .ToListAsync();
            if (entities.Count() == 0)
            {
                Debug.WriteLine("Doctors with speciality {speciality} not found");
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
            }

            return entity!;
        }


        public async Task<Doctor?> Login(string email, string password)
        {
            Doctor? userEntity = await _dbContext.Doctors.FirstOrDefaultAsync(u => u.Email == email);                                                                                 
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
                                                userEntity.Rolename!);
            userEntity.Token = token;
            userEntity.IsActive = true;
            return userEntity;
        }
    }
}
