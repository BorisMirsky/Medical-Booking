namespace MedicalBookingProject.Web.Contracts
{
    public class BookingRequest  
    {
        public Guid SlotId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Boolean IsBooked { get; set; }
        public Guid? CancelledBy { get; set; } 
        public DateTime BookingOrCancelDatetime { get; set; } = DateTime.MinValue;
    }
}
