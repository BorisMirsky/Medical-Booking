using MedicalBookingProject.DataAccess.Entities;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.DataAccess.Repo
{
    using BCrypt.Net;
    using MedicalBookingProject.DataAccess;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;

    public class UsersPatientRepo : IUsersPatientRepo
    {
        private readonly MedicalBookingDbContext _dbContext;
        public UsersPatientRepo(MedicalBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<UserPatient> Register(string email, string password,
                                               string username, string role, string gender)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            UserPatientEntity userEntity = new UserPatientEntity
            {
                Id = new Guid(),
                UserName = username,
                Password = hashedPassword,
                Email = email,
                Role = role,
                Gender = gender

            };
            _dbContext.UsersPatients.Add(userEntity!);
            await _dbContext.SaveChangesAsync();

            UserPatient user = new UserPatient(email, hashedPassword, role, username, gender);
            user.Id = userEntity.Id;
            user.UserName = userEntity.UserName;
            user.Role = userEntity.Role;
            user.Email = userEntity.Email;
            return user;
        }

        public async Task<UserPatient> Get(Guid id)
        {
            var entities = await _dbContext.UsersPatients
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
            UserPatient patient = new (entity.UserName, entity.Password,
                                       entity.Gender, entity.Email, entity.Role);
            return patient!;
        }

    }
}
