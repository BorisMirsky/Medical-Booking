using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalBookingProject.DataAccess.Entities
{
    [Table("users_doctor")]
    public class UserDoctorEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string UserName { get; set; } = "";

        [Column("email")]
        public string Email { get; set; } = "";

        [Column("role")]
        public string Role { get; set; } = "";   //Everyone

        [Column("roleid")]
        public int? RoleId { get; set; } = null;   //Everyone

        [Column("isactive")]
        public bool? IsActive { get; set; } = false;

        [Column("token")]
        public string? Token { get; set; } = "";

        [Column("password")]
        public string Password { get; set; } = "";

        [Column("gender")]
        public string? Gender { get; set; } = "";

        [Column("speciality")]
        public string Speciality { get; set; } = "";

        [Column("price")]
        public int? Price { get; set; } = 0;

        [Column("salary")]
        public int? Salary { get; set; } = 0;
    }
}
