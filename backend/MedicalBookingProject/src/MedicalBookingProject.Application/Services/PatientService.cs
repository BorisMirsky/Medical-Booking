using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepo _patientRepo;

        public PatientService(IPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<Patient> Register(string email, string password, string username, string role, string gender)
        {
            return await _patientRepo.Register(email, password, username, role, gender);
        }

        public async Task<Patient?> Login(string email, string password)
        {
            return await _patientRepo.Login(email, password);
        }

        public async Task<Patient> Get(Guid id)
        {
            return await _patientRepo.Get(id);
        }

        public async Task<List<Patient>> GetAll()
        {
            return await _patientRepo.GetAll();
        }
    }
}
