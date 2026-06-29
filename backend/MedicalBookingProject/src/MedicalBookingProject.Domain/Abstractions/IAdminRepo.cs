using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAdminRepo
    {
        Task<Admin?> GetAdminAsync();      
        Task AddAsync(Admin admin);
        Task SaveChangesAsync();
    }
}
