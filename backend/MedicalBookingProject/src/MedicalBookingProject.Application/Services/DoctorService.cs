using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using BCrypt_Alias = BCrypt.Net.BCrypt;
using MedicalBookingProject.Application.Scripts; // для JwtGenerator
using Microsoft.Extensions.Configuration;



namespace MedicalBookingProject.Application.Services
{
    public class DoctorService : IDoctorService
    {

        private readonly IDoctorRepo _doctorRepo;
        private readonly IConfiguration _configuration;

        public DoctorService(IDoctorRepo doctorRepo, IConfiguration configuration)
        {
            _doctorRepo = doctorRepo;
            _configuration = configuration;
        }

        public async Task<Doctor> Register(string email, string password, string username,
                                            string role, string speciality, string gender)
        {
            var hashedPassword = BCrypt_Alias.HashPassword(password);
            var doctor = new Doctor(email, hashedPassword, role, speciality, username, gender);
            doctor.Id = Guid.NewGuid();

            await _doctorRepo.AddAsync(doctor);
            await _doctorRepo.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor?> LoginAccount(string email, string password)
        {
            var userEntity = await _doctorRepo.GetByEmailAsync(email);
            if (userEntity == null)
                return null;

            if (!BCrypt_Alias.Verify(password, userEntity.Password))
                return null;

            var tokenGenerator = new JwtGenerator(_configuration);
            var token = tokenGenerator.CreateTokenDescriptor(email, userEntity.UserName!, userEntity.Rolename!);

            userEntity.Token = token;
            userEntity.IsActive = true;

            await _doctorRepo.SaveChangesAsync(); 
            return userEntity;
        }

        public async Task<Doctor> Get(Guid id)
        {
            return await _doctorRepo.GetByIdAsync(id);
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _doctorRepo.GetAllAsync();
        }

        public async Task<List<Doctor>> GetDoctorsBySpeciality(string speciality)
        {
            return await _doctorRepo.GetBySpecialityAsync(speciality);
        }

        public async Task<Doctor> GetDoctorBySpecialityAndName(string speciality, string username)
        {
            return await _doctorRepo.GetBySpecialityAndNameAsync(speciality, username);
        }
    }
}
