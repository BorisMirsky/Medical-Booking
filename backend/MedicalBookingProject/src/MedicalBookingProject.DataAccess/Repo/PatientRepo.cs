using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;



namespace MedicalBookingProject.DataAccess.Repo
{

    public class PatientRepo : IPatientRepo
    {
        private readonly MedicalBookingDbContext _dbContext;
        public PatientRepo(MedicalBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Patient?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Patients
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient?> GetByEmailAsync(string email)
        {
            return await _dbContext.Patients
                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _dbContext.Patients.ToListAsync();
        }

        public async Task AddAsync(Patient patient)
        {
            await _dbContext.Patients.AddAsync(patient);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}

