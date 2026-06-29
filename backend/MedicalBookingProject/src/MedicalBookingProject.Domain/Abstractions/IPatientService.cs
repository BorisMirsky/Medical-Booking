using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IPatientService
    {
        Task<Patient?> Login(string username, string password);
        Task<Patient> Register(string email, string password,
                                  string username, string role, string gender);
        Task<Patient> Get(Guid id);
        Task<List<Patient>> GetAll();
    }
}
