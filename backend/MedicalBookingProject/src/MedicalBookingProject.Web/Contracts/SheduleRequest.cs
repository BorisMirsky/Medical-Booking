using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.Web.Contracts
{
    public record SheduleRequest
    {
        public Guid DoctorId { get; set; }
        public DateTime StartDay { get; set; }    //DateTime
        public int Days { get; set; }
        public int TimeStart { get; set; }
        public int TimeStop { get; set; }
        public int TimeChunk { get; set; }
        //public IEnumerable<Timeslot>? Timeslots { get; set; } = null;
    }
}
