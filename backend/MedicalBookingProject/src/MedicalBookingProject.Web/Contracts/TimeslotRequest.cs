namespace MedicalBookingProject.Web.Contracts
{
    public record TimeslotRequest
    {
        public Guid Id { get; set; }
        public string slotDatetimeStart { get; set; } = "";
        public string slotDatetimeStop { get; set; } = "";
        public Guid DoctorId { get; set; }
        public Boolean? IsBooked { get; set; } = false;
        public Guid? PatientId { get; set; } = null;
        public string? WasCancelledBy { get; set; } = null;
        public string? WasCancelledAt { get; set; } = null;
    }
}
