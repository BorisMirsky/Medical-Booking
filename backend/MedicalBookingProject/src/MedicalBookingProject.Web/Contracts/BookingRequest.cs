namespace MedicalBookingProject.Web.Contracts
{
    public class BookingRequest
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Boolean IsBooked { get; set; } 
        public Boolean? WasCancelled { get; set; }
        public Guid CancelledBy { get; set; } = Guid.Empty;   
        public DateTime CancelledAt { get; set; } = DateTime.MinValue;
    }
}
