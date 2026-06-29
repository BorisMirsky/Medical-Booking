using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IPatientRepo
    {
        Task<Patient> Register(string email, string password, string username, string role, string gender);
        
        Task<Patient?> Login(string email, string password);
        
        Task<Patient> Get(Guid id);
        
        Task<List<Patient>> GetAll();
    }
}
