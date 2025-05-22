using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.Web.Contracts
{
    public record SheduleResponse
    {
        public Guid DoctorId { get; set; }
        public DateTime StartDay { get; set; }   //DateTime
        public int Days { get; set; }
        //public IEnumerable<Timeslot>? Timeslots { get; set; }
    }
}