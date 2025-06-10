using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MedicalBookingProject.Domain.Models.Shedules
{
    [Table("timeslots")]
    public class Timeslot
    {

        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Column("datetimestart")]
        public string DatetimeStart { get; set; } = String.Empty;

        [Column("datetimestop")]
        public string DatetimeStop { get; set; } = String.Empty;

        [Column("doctorid")]
        public Guid DoctorId { get; set; } = Guid.Empty;

        [Column("isbooked")]
        public Boolean? IsBooked { get; set; } 

        [Column("patientid")]
        public Guid? PatientId { get; set; }                              
    }
}
