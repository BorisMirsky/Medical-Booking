using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Scripts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BCrypt_Alias = BCrypt.Net.BCrypt;




namespace MedicalBookingProject.DataAccess.Repo
{

    public class PatientRepo : IPatientRepo
    {
        private readonly MedicalBookingDbContext _dbContext;
        private readonly IConfiguration _configuration;
        public PatientRepo(MedicalBookingDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        
        public async Task<Patient> Register(string email, string password,
                                               string username, string role, 
                                               string gender)
        {
            var hashedPassword = BCrypt_Alias.HashPassword(password);
            Patient patient = new Patient(email, hashedPassword, role, gender, username);
            patient.Id = Guid.NewGuid();
            _dbContext.Patients.Add(patient!);
            await _dbContext.SaveChangesAsync();
            return patient;
        }


        public async Task<Patient?> Login(string email, string password)
        {
            Patient? userEntity = await _dbContext.Patients.FirstOrDefaultAsync(u => u.Email == email);                                                                                 
            if (userEntity == null)
            {
                return null;
            }

            if (userEntity == null || BCrypt_Alias.Verify(password, userEntity.Password) == false)
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
