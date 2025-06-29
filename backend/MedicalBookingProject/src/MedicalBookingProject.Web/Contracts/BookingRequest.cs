namespace MedicalBookingProject.Web.Contracts
{
    public record BookingRequest  
    {
        public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public Boolean IsBooked { get; set; } 
        public Guid? CancelledBy { get; set; } 
        public DateTime? BookingOrCancelDatetime { get; set; } 
    }
}
