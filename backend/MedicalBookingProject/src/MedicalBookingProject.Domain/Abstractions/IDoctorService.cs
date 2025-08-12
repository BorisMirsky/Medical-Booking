using MedicalBookingProject.Domain.Models.Users;






namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IDoctorService
    {

        Task<Doctor> Register(string email, string password, 
                                  string username, string role,
                                  string speciality, string gender);
        Task<List<Doctor>> GetAllDoctors();
        Task<Doctor> Get(Guid id);

        Task<List<Doctor>> GetDoctorsBySpeciality(string speciality);
        Task<Doctor> GetDoctorBySpecialityAndName(string speciality, string username);
        Task<Doctor?> LoginAccount(string username, string password);

    }
}


