namespace MedicalBookingProject.Web.Contracts
{
    public record AppointmentResponse
    {
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Guid MedicalCardId { get; set; }
        public int FinalCost { get; set; }
    }
}
