namespace MedicalBookingProject.Web.Contracts
{
    public class AppointmentRequest
    {
        public Guid Id { get; set; }
        public Guid BookingId { get; set; }
        public String? PatientUnacceptableBehavior { get; set; }
        public Boolean? PatientCame { get; set; }
        public Boolean? PatientIsLate { get; set; }
        public Boolean? VisualExaminationPatient { get; set; }
        public Boolean? ReferralTests { get; set; }
        public Boolean? MakingDiagnosis { get; set; }
        public Boolean? Treatment { get; set; }
        public int FinalCost { get; set; }
    }
}
