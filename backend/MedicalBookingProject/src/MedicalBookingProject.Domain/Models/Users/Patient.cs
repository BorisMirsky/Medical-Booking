﻿using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.Domain.Models.Shedules;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalBookingProject.Domain.Models.Users
{

    [Table("users_patient")]
    public class Patient
    {
        public Patient()
        { }

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
        public string UserName { get; set; } = String.Empty;

        [Column("email")]
        public string Email { get; set; } = String.Empty;

        [Column("password")]
        public string Password { get; set; } = String.Empty; // PasswordHash

        [Column("rolename")]
        public string Rolename { get; set; } = String.Empty;

        [Column("gender")]
        public string Gender { get; set; } = String.Empty;

        [Column("roleid")]
        public int RoleId { get; set; } = 3;

        [Column("isactive")]
        public bool IsActive { get; set; } = false;

        [Column("token")]
        public string Token { get; set; } = string.Empty;

        public Role? Role { get; set; } 

        public List<Timeslot>? Timeslots { get; set; } 

        public List<Booking>? Bookings { get; set; }

        public List<MedicalRecord>? MedicalRecords { get; set; }

        public List<Appointment>? Appointments { get; set; }
    }
}
