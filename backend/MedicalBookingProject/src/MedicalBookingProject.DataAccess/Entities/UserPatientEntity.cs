using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.DataAccess.Entities
{
    [Table("users_patient")]
    public class UserPatientEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string UserName { get; set; } = "";

        [Column("email")]
        public string Email { get; set; } = "";

        [Column("role")]
        public string Role { get; set; } = "";   //Everyone

        [Column("password")]
        public string Password { get; set; } = "";

        [Column("roleid")]
        public int? RoleId { get; set; } = null;   //Everyone

        [Column("isactive")]
        public bool? IsActive { get; set; } = false;

        [Column("token")]
        public string? Token { get; set; } = "";

        [Column("gender")]
        public string Gender { get; set; } = "";
    }
}
