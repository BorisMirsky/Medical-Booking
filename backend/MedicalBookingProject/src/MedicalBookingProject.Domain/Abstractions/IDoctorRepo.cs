using MedicalBookingProject.Domain.Models.Users;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IDoctorRepo
    {
        Task<Doctor?> GetByIdAsync(Guid id);
        Task<Doctor?> GetByEmailAsync(string email);
        Task<List<Doctor>> GetAllAsync();
        Task<List<Doctor>> GetBySpecialityAsync(string speciality);
        Task<Doctor?> GetBySpecialityAndNameAsync(string speciality, string username);
        Task AddAsync(Doctor doctor);
        Task SaveChangesAsync();
    }
}
