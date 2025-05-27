using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.Web.Contracts
{
    public record SheduleResponse
    {
        public Guid DoctorId { get; set; }
        public DateTime StartDay { get; set; }  
        public int Days { get; set; }
    }
}