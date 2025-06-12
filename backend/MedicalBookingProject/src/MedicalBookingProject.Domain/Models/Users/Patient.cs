using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalBookingProject.Domain.Models.Users
{

    [Table("users_patient")]
    public class Patient
    {
        public Patient()
        {
        }

        public Patient(string email, string password, 
                       string rolename, string gender, 
                       string username)
        {
            Email = email;
            Password = password;
            Rolename = rolename;
            Gender = gender;
            UserName = username;
        }

        [Key]
        [Column("id")]
        public Guid? Id { get; set; }

        [Column("username")]
        public string UserName { get; set; }

        [Column("email")]
        public string Email { get; set; } 

        [Column("password")]
        public string Password { get; set; }   // PasswordHash

        [Column("rolename")]
        public string Rolename { get; set; }

        [Column("gender")]
        public string Gender { get; set; } 

        [Column("roleid")]
        public int? RoleId { get; set; }

        [Column("isactive")]
        public bool? IsActive { get; set; } 

        [Column("token")]
        public string? Token { get; set; }

        public Role? Role { get; set; }

        public List<Timeslot> Timeslots { get; set; } 

        public List<Booking> Bookings { get; set; } 
    }
}
