namespace MedicalBookingProject.Web.Contracts
{
    public class BookingRequest
    {
        //public Guid Id { get; set; }                // лишнее ?
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Boolean WasCancelled { get; set; } = false;
        public Guid? CancelledBy { get; set; } = null;              // doctorId or PatientId
        public DateTime? CancelledAt { get; set; } = null;
    }
}
