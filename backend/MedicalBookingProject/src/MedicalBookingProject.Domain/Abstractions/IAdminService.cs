using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAdminService
    {
        Task<Admin?> Register(string email, string password);
        Task<Admin?> LoginAccount(string email, string password);
    }
}
