namespace MedicalBookingProject.Web.Contracts
{
    public record TimeslotUpdateRequest
    {
        public Guid SlotId { get; set; } = Guid.Empty;
        public Guid PatientId { get; set; } = Guid.Empty;
        public Boolean IsBooked { get; set; } = false;
    }
}
