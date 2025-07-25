﻿using MedicalBookingProject.Domain.Models.Appointments;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Models.MedicalRecords;



namespace MedicalBookingProject.Domain.Models.Bookings
{
    [Table("bookings")]
    public class Booking
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("timeslotid")]
        public Guid TimeslotId { get; set; }

        [Column("isbooked")]
        public Boolean IsBooked { get; set; }

        [Column("createdat")]
        public DateTime CreatedAt { get; set; }

        [Column("isclosed")]
        public Boolean IsClosed { get; set; } = false;

        public Patient? Patient { get; set; } 

        public Doctor? Doctor { get; set; }

        public Appointment? Appointment { get; set; }

        public MedicalRecord? MedicalRecord { get; set; }

        public Timeslot? Timeslot { get; set; } 

    }
}
