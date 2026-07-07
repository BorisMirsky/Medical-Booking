using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IPatientRepo
    {
        Task<Patient?> GetByIdAsync(Guid id);
        Task<Patient?> GetByEmailAsync(string email);
        Task<List<Patient>> GetAllAsync();
        Task AddAsync(Patient patient);
        Task SaveChangesAsync();
    }
}
