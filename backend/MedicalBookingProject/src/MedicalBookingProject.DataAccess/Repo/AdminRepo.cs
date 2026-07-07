using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;


namespace MedicalBookingProject.DataAccess.Repo
{

    using BCrypt.Net;
    public class AdminRepo : IAdminRepo
    {

        private readonly MedicalBookingDbContext _dbContext;

        public AdminRepo(MedicalBookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Admin?> GetAdminAsync()
        {
            return await _dbContext.Admins.FirstOrDefaultAsync();
        }

        public async Task AddAsync(Admin admin)
        {
            await _dbContext.Admins.AddAsync(admin);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}

