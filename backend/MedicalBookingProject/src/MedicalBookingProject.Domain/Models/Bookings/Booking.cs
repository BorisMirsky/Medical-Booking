using MedicalBookingProject.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MedicalBookingProject.Domain.Models.Bookings
{

    [Table("bookings")]
    public class Booking
    {
        public Booking(Guid doctorId, Guid? patientId, Guid slotId)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            SlotId = slotId;
        }

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("patientid")]
        public Guid? PatientId { get; set; }

        [Key]
        [Column("slotid")]
        public Guid SlotId { get; set; }

        [Column("isbooked")]
        public Boolean? IsBooked { get; set; }

        [Column("cancelledby")]
        public Guid? CancelledBy { get; set; } = null;

        [Column("bookingorcanceldatetime")]
        public DateTime? BookingOrCancelDatetime { get; set; } = null;

    }
}
