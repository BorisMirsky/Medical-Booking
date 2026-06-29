using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class DoctorRepo : IDoctorRepo
    {

        private readonly MedicalBookingDbContext _dbContext;

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
        