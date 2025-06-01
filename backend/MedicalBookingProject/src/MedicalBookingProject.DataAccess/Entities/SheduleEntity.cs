using MedicalBookingProject.Domain.Models.Shedules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MedicalBookingProject.DataAccess.Entities
{
    [Table("shedules")]
    public class SheduleEntity
    {
        //[Column("id")]
        //public Guid? Id { get; set; }

        [Key]
        [Column("slotid")]
        public Guid SlotId { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("slotdatetimestart")]
        public string? SlotDatetimeStart { get; set; } 

        [Column("slotdatetimestop")]
        public string? SlotDatetimeStop { get; set; } 

        [Column("isbooked")]
        public Boolean IsBooked { get; set; } = false;

        [Column("patientid")]
        public Guid? PatientId { get; set; }

        //[Column("wascancelled")]
        //public int WasCancelled { get; set; }
    }
}
