using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Models;
//using MedicalBookingProject.
//using MedicalBookingProject.Domain.Models;
//using MedicalBookingProject.Domain.Models;
//using Versta.DataAccess;
//using Versta.DataAccess.Repo;
//using Versta.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using BCrypt.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Application.Services
{
    public class UsersDoctorService : IUsersDoctorService
    {

        private readonly IUsersDoctorRepo _doctorRepo;

        public UsersDoctorService(IUsersDoctorRepo doctorRepo)
        {
            _doctorRepo = doctorRepo;
        }

        public async Task<Doctor> Register(string email, string password, string username, string role, string speciality)
        {
            return await _doctorRepo.Register(email, password, username, role, speciality);
        }

        public async Task<Doctor> Get(Guid id)
        {
            return await _doctorRepo.Get(id);
        }

    }
}
