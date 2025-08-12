using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Users
{
    [Table("users_admin")]
    public class Admin
    {
        [Key]
        public Guid? Id { get; set; }
        public string? UserName { get; set; } = "ADMIN";
        public string? Email { get; set; } = "";
        public string? Password { get; set; } = "";   // PasswordHash
        public string? Role { get; set; } = "Admin";
        public int? RoleId { get; set; } = 1;              
        //public bool? IsActive { get; set; } = false;
        public string? Token { get; set; } = "";
    }
}
