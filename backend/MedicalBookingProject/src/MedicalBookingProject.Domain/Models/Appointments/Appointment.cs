using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Appointments
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        [Column("id")]
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

        [Column("doctorid")]
        public Guid DoctorId { get; set; }

        [Column("patientid")]
        public Guid PatientId { get; set; }

        [Column("slotid")]
        public Guid SlotId { get; set; }

        [Column("medicalcardid")]
        public Guid MedicalCardId { get; set; }

        // behavior of patient
        [Column("patientcame")]
        public Boolean PatientCame { get; set; }

        [Column("patientislate")]
        public Boolean PatientIsLate { get; set; }

        [Column("patientunacceptablebehavior")]
        public String PatientUnacceptableBehavior { get; set; } = String.Empty;

        // services rendered
        [Column("visualexamination")]
        public Boolean VisualExamination { get; set; }

        [Column("listeningheart")]
        public Boolean ListeningHeart { get; set; }

        [Column("procedure")]
        public Boolean Procedure { get; set; }

        [Column("referraltests")]
        public Boolean ReferralTests { get; set; }

        [Column("medecins")]
        public Boolean Medecins { get; set; }

        [Column("makingdiagnosis")]
        public Boolean MakingDiagnosis { get; set; }

        [Column("treatment")]
        public Boolean Treatment { get; set; }


        //
        [Column("finalcost")]
        public int FinalCost { get; set; }
    }
}
