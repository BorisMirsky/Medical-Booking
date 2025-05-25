using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.DataAccess.Entities
{
    [Table("bookings")]
    public class BookingEntity
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("slotid")]
        public Guid SlotId { get; set; }

        [Column("wascancelled")]
        public Boolean? WasCancelled { get; set; } = false;

        [Column("cancelledby")]
        public Guid? CancelledBy { get; set; }

        [Column("cancelledat")]
        public DateTime? CancelledAt { get; set; }
    }
}
