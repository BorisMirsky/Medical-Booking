using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using MedicalBookingProject.Application.Scripts;
//using System.Diagnostics;
//using BCrypt_Alias = BCrypt.Net.BCrypt;
////

//using MedicalBookingProject.DataAccess;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class DoctorRepo : IDoctorRepo
    {

        private readonly MedicalBookingDbContext _dbContext;

        //private readonly IConfiguration _configuration;

        public DoctorRepo(MedicalBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Doctor?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Doctors
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Doctor?> GetByEmailAsync(string email)
        {
            return await _dbContext.Doctors
                .FirstOrDefaultAsync(d => d.Email == email);
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _dbContext.Doctors.ToListAsync();
        }

        public async Task<List<Doctor>> GetBySpecialityAsync(string speciality)
        {
            return await _dbContext.Doctors
                .Where(d => d.Speciality == speciality)
                .ToListAsync();
        }

        public async Task<Doctor?> GetBySpecialityAndNameAsync(string speciality, string username)
        {
            return await _dbContext.Doctors
                .FirstOrDefaultAsync(d => d.Speciality == speciality && d.UserName == username);
        }

        public async Task AddAsync(Doctor doctor)
        {
            await _dbContext.Doctors.AddAsync(doctor);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
        //public async Task<Doctor> Register(string email, string password,
        //                                       string username, string role,
        //                                       string speciality, string gender)
        //{
        //    var hashedPassword = BCrypt_Alias.HashPassword(password);
        //    Doctor doctor = new(email, hashedPassword,
        //                                role, speciality,
        //                                username, gender);
        //    doctor.Id = Guid.NewGuid();
        //    _dbContext.Doctors.Add(doctor!);
        //    await _dbContext.SaveChangesAsync();
        //    return doctor;
        //}

//public async Task<Doctor> Get(Guid id)
//{
//    Doctor? entity = await _dbContext.Doctors
//        .AsNoTracking()
//        .FirstOrDefaultAsync(s => s.Id == id);
//    return entity!; 
//}


//public async Task<List<Doctor>> GetAll()
//{
//    var entities = await _dbContext.Doctors
//       .ToListAsync();
//    return entities;
//}


//public async Task<List<Doctor>> GetDoctorsBySpeciality(string speciality)
//{
//    var entities = await _dbContext.Doctors
//       .Where(item => item.Speciality == speciality)
//       .ToListAsync();
//    if (entities.Count() == 0)
//    {
//        Debug.WriteLine("Doctors with speciality {speciality} not found");
//    }

//    return entities;
//}


//public async Task<Doctor> GetDoctorBySpecialityAndName(string speciality, string username)
//{
//    var entity = await _dbContext.Doctors
//       .Where(item => item.Speciality == speciality && item.UserName == username)
//       .FirstOrDefaultAsync();
//    if (entity == null)
//    {
//        Debug.WriteLine("Doctor not found");
//    }

//    return entity!;
//}


//public async Task<Doctor?> Login(string email, string password)
//{
//    Doctor? userEntity = await _dbContext.Doctors.FirstOrDefaultAsync(u => u.Email == email);                                                                                 
//    if (userEntity == null)
//    {
//        return null;
//    }
//    if (userEntity == null || BCrypt_Alias.Verify(password, userEntity.Password) == false)
//    {
//        return null;
//    }
//    JwtGenerator tokenInstance = new(_configuration);
//    string token = tokenInstance.CreateTokenDescriptor(email,
//                                        userEntity.UserName!,
//                                        userEntity.Rolename!);
//    userEntity.Token = token;
//    userEntity.IsActive = true;
//    return userEntity;
//}
//    }
//}
