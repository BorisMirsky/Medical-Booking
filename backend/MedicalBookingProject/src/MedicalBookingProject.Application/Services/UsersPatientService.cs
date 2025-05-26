using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Application.Services
{
    public class UsersPatientService : IUsersPatientService
    {
        private readonly IUsersPatientRepo _patientRepo;

        public UsersPatientService(IUsersPatientRepo patientRepo)
        {
            _patientRepo = patientRepo;
        }

        public async Task<UserPatient> Register(string email, string password, string username, string role, string gender)
        {
            return await _patientRepo.Register(email, password, username, role, gender);
        }

        public async Task<UserPatient> Get(Guid id)
        {
            return await _patientRepo.Get(id);
        }
    }
}
