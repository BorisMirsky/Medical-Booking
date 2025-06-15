using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MedicalBookingProject.Domain.Models.Appointments;


namespace MedicalBookingProject.Domain.Models.Users
{

    [Table("users_doctor")]
    public class Doctor
    {
        public Doctor()
        {
        }

        public Doctor(string email, string password, string rolename,
                  string speciality, string username, string gender)
        {
            Email = email;
            Password = password;
            Rolename = rolename;
            Speciality = speciality;
            UserName = username;
            Gender = gender;
        }
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("username")]
        public string UserName { get; set; } = String.Empty;

        [Column("email")]
        public string Email { get; set; } = String.Empty;

        [Column("password")]
        public string Password { get; set; } = String.Empty;   // PasswordHash

        [Column("rolename")]
        public string Rolename { get; set; } = String.Empty;

        [Column("roleid")]
        public int RoleId { get; set; } = 2;

        [Column("isactive")]
        public bool IsActive { get; set; } = false;

        [Column("token")]
        public string Token { get; set; } = String.Empty;

        [Column("gender")]
        public string Gender { get; set; } = String.Empty;

        [Column("speciality")]
        public string Speciality { get; set; } = String.Empty;

        [Column("price")]
        public int Price { get; set; } = 0;

        [Column("salary")]
        public int Salary { get; set; } = 0;

        public Role Role { get; set; }

        public List<Timeslot?> Timeslots { get; set; } 
       
        public List<Booking?> Bookings { get; set; } 

        public List<MedicalRecord?> MedicalRecords { get; set; }

        public List<Appointment?> Appointments { get; set; }

    }
}
