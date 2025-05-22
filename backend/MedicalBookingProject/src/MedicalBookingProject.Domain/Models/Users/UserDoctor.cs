using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Users
{
    public class UserDoctor
    {
        public UserDoctor(string email, string password, string role,
                  string speciality, string username)
        {
            Email = email;
            Password = password;
            Role = role;
            Speciality = speciality;
            UserName = username;
        }
        [Key]
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Password { get; set; } = "";   // PasswordHash
        public string? Role { get; set; } = "";
        public int? RoleId { get; set; }                 // ?
        public bool? IsActive { get; set; } = false;
        public string? Token { get; set; } = "";
        public string? Gender { get; set; } = "";
        public string? Speciality { get; set; } = "";
        public int? Price { get; set; }
        public int? Salary { get; set; }

    }
}
