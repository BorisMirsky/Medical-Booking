using MedicalBookingProject.DataAccess.Entities;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class UsersDoctorRepo : IUsersDoctorRepo
    {
        private readonly MedicalBookingDbContext _dbContext;
        public UsersDoctorRepo(MedicalBookingDbContext dbContext) {
            _dbContext = dbContext;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<UserDoctor> Register(string email, string password,
                                               string username, string role,
                                               string speciality)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            UserDoctorEntity userEntity = new UserDoctorEntity
            {
                Id = new Guid(),
                UserName = username,
                Password = hashedPassword,
                Email = email,
                Role = role,
                Speciality = speciality,

            };
            _dbContext.UsersDoctors.Add(userEntity!);
            await _dbContext.SaveChangesAsync();

            UserDoctor user = new UserDoctor(email, hashedPassword, role, username, speciality);
            user.Id = userEntity.Id;
            user.UserName = userEntity.UserName;
            user.Role = userEntity.Role;
            user.Email = userEntity.Email;
            user.Speciality = userEntity.Speciality;
            return user;
        }
    }
}
