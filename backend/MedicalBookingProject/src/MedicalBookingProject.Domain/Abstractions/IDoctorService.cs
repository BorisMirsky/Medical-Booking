using MedicalBookingProject.Domain.Models.Users;






namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IDoctorService
    {
        //Task<UserDoctor> Login(string username, string password);
        Task<Doctor> Register(string email, string password, 
                                  string username, string role,
                                  string speciality, string gender);

        Task<Doctor> Get(Guid id);

        Task<List<Doctor>> GetDoctorsBySpeciality(string speciality);
        Task<Doctor> GetDoctorBySpecialityAndName(string speciality, string username);
    }
}


