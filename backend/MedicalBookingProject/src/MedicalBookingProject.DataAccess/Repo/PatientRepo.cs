using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.DataAccess.Repo
{
    using BCrypt.Net;
    using MedicalBookingProject.DataAccess;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.EntityFrameworkCore;
    using System.Diagnostics;

    public class PatientRepo : IPatientRepo
    {
        private readonly MedicalBookingDbContext _dbContext;
        public PatientRepo(MedicalBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public async Task<Patient> Register(string email, string password,
                                               string username, string role, 
                                               string gender)
        {
            var hashedPassword = BCrypt.HashPassword(password);
            Patient patient = new Patient(email, hashedPassword, role, gender, username);
            patient.Id = Guid.NewGuid();
            _dbContext.Patients.Add(patient!);
            await _dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> Get(Guid id)
        {
            Patient? entity = await _dbContext.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == id);
            return entity!;
        }


        public async Task<List<Patient>> GetAll()
        {
            var entities = await _dbContext.Patients
               .ToListAsync();
            return entities;
        }

    }
}
