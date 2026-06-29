using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Scripts;
using Microsoft.Extensions.Configuration;
using BCrypt_Alias = BCrypt.Net.BCrypt;


namespace MedicalBookingProject.Application.Services
{
    public class PatientService : IPatientService
    {

        private readonly IPatientRepo _patientRepo;
        private readonly IConfiguration _configuration;

        public PatientService(IPatientRepo patientRepo, IConfiguration configuration)
        {
            _patientRepo = patientRepo;
            _configuration = configuration;
        }


        public async Task<Patient> Register(string email, string password, string username,
                                             string role, string gender)
        {
            var hashedPassword = BCrypt_Alias.HashPassword(password);
            var patient = new Patient(email, hashedPassword, role, gender, username);
            patient.Id = Guid.NewGuid();

            await _patientRepo.AddAsync(patient);
            await _patientRepo.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient?> Login(string email, string password)
        {
            var userEntity = await _patientRepo.GetByEmailAsync(email);
            if (userEntity == null)
                return null;

            if (!BCrypt_Alias.Verify(password, userEntity.Password))
                return null;

            var tokenGenerator = new JwtGenerator(_configuration);
            var token = tokenGenerator.CreateTokenDescriptor(email, userEntity.UserName!, userEntity.Rolename!);

            userEntity.Token = token;
            userEntity.IsActive = true;

            await _patientRepo.SaveChangesAsync();
            return userEntity;
        }

        public async Task<Patient> Get(Guid id)
        {
            return await _patientRepo.GetByIdAsync(id);
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _patientRepo.GetAllAsync();
        }

    }
}
