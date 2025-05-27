using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Appointments
{
    public class Appointment
    {
        public Guid Id { get; set; }
        public Appointment(Guid doctorId, Guid patientId, 
                           Guid slotId, Guid medicalCardId, 
                           bool patientCame, bool patientIsLate,
                           int finalCost)
        {
            DoctorId = doctorId;
            PatientId = patientId;
            SlotId = slotId;
            MedicalCardId = medicalCardId;
            PatientCame = patientCame;
            PatientIsLate = patientIsLate;
            FinalCost = finalCost;
        }

        public Guid DoctorId { get; set; }
        public Guid PatientId { get; set; }
        public Guid SlotId { get; set; }
        public Guid MedicalCardId { get; set; }

        // behavior of patient
        public Boolean PatientCame { get; set; } 
        public Boolean PatientIsLate {  get; set; }
        public String? PatientUnacceptableBehavior { get; set; } = String.Empty;

        // services rendered
        public Boolean? VisualExaminationPatient { get; set; }
        public Boolean? ListeningHeart { get; set; }
        public Boolean? Procedure { get; set; }
        public Boolean? ReferralTests { get; set; }
        public Boolean? Medecins { get; set; }
        public Boolean? MakingDiagnosis { get; set; }
        public Boolean? Treatment { get; set; }

        //
        public int FinalCost { get; set; } = 0;
    }
}
