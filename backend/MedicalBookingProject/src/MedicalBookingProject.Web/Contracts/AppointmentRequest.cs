namespace MedicalBookingProject.Web.Contracts
{
    public record AppointmentRequest
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid TimeslotId { get; set; }
        public String? PatientUnacceptableBehavior { get; set; }
        public String? PatientCame { get; set; }
        public String? PatientIsLate { get; set; }
        //public Boolean? VisualExaminationPatient { get; set; }
        //public Boolean? ReferralTests { get; set; }
        //public Boolean? MakingDiagnosis { get; set; }
        //public Boolean? Treatment { get; set; }
        //public int FinalCost { get; set; }
    }
}
