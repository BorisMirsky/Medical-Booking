using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Users
{
    public class UserAdmin
    {
        [Key]
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = "";
        public string? Email { get; set; } = "";
        public string? Password { get; set; } = "";   // PasswordHash
        public string? Role { get; set; } = "";
        public int? RoleId { get; set; }                 // ?
        public bool? IsActive { get; set; } = false;
        public string? Token { get; set; } = "";
    }
}
