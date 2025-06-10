namespace MedicalBookingProject.Web.Contracts
{
    public record TimeslotRequest
    {
        public Guid DoctorId { get; set; }
        public DateTime StartDay { get; set; }
        public int Days { get; set; }
        public int TimeStart { get; set; }
        public int TimeStop { get; set; }
        public int TimeChunk { get; set; }
    }
}
