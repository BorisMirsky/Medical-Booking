using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalBookingProject.Domain.Models.Users
{

    [Table("users_doctor")]
    public class Doctor
    {
        public Doctor(string email, string password, string rolename,
                  string speciality, string username)
        {
            Email = email;
            Password = password;
            Rolename = rolename;
            Speciality = speciality;
            UserName = username;
        }
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string UserName { get; set; } 

        [Column("email")]
        public string Email { get; set; } 

        [Column("password")]
        public string Password { get; set; }    // PasswordHash

        [Column("rolename")]
        public string Rolename { get; set; } 

        public Role Role { get; set; } 

        [Column("roleid")]
        public int? RoleId { get; set; }                 // ?

        [Column("isactive")]
        public bool? IsActive { get; set; } = false;

        [Column("token")]
        public string? Token { get; set; } = "";

        [Column("gender")]
        public string? Gender { get; set; } = "";

        [Column("speciality")]
        public string Speciality { get; set; }

        [Column("price")]
        public int? Price { get; set; }

        [Column("salary")]
        public int? Salary { get; set; }

    }
}
