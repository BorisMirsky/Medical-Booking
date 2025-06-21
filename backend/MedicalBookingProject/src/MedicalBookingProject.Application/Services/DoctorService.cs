using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Application.Services
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepo _doctorRepo;

        public DoctorService(IDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task<Doctor> Register(string email, string password, 
                                           string username, string role, 
                                           string speciality, string gender)
        {
            return await _doctorRepo.Register(email, password, 
                                               username, role, 
                                               speciality, gender);
        }

        public async Task<Doctor> Get(Guid id)
        {
            return await _doctorRepo.Get(id);
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _doctorRepo.GetAll();
        }


        public async Task<List<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            return await _doctorRepo.GetDoctorsBySpeciality(speciality);
        }

        public async Task<Doctor> GetDoctorBySpecialityAndName(string speciality, string username)
        {
            return await _doctorRepo.GetDoctorBySpecialityAndName(speciality, username);
        }

    }
}
