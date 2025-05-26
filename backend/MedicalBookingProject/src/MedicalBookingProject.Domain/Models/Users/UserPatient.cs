using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Users
{
    public class UserPatient
    {
        public UserPatient(string email, string password, string role,
          string gender, string username)
        {
            Email = email;
            Password = password;
            Role = role;
            Gender = gender;
            UserName = username;
        }
        [Key]
        public Guid? Id { get; set; }
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";   // PasswordHash
        public string Role { get; set; } = "";
        public string Gender { get; set; } = "";
        public int? RoleId { get; set; }                
        public bool? IsActive { get; set; } = false;
        public string? Token { get; set; } = "";
    }
}
