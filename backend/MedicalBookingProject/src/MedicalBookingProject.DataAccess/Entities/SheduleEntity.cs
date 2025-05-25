using MedicalBookingProject.Domain.Models.Shedules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.DataAccess.Entities
{
    [Table("shedules")]
    public class SheduleEntity
    {
        [Column("id")]
        public int? Id { get; set; }

        [Column("slotid")]
        public Guid SlotId { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("slotdatetimestart")]
        public string SlotDatetimeStart { get; set; } = "";

        [Column("slotdatetimestop")]
        public string SlotDatetimeStop { get; set; } = "";

        [Column("isbooked")]
        public Boolean? IsBooked { get; set; }

        [Column("patientid")]
        public Guid? PatientId { get; set; }

        [Column("startday")]
        public string StartDay { get; set; } = "";

        [Column("days")]
        public int Days { get; set; }

        [Column("timestart")]
        public int TimeStart { get; set; }

        [Column("timestop")]
        public int TimeStop { get; set; }

        [Column("timechunk")]
        public int TimeChunk { get; set; }
    }
}
