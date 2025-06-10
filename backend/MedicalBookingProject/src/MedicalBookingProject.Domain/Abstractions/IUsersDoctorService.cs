using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.Domain.Models.Users;






namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IUsersDoctorService
    {
        //Task<UserDoctor> Login(string username, string password);
        Task<Doctor> Register(string email, string password, 
                                  string username, string role,
                                  string speciality);
        Task<Doctor> Get(Guid id);
    }
}


