using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IAdminRepo
    {
        Task<Admin?> Register(string email, string password);

        Task<Admin?> Login(string email, string password);
    }
}
