using MedicalBookingProject.Domain.Models.MedicalRecords;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalReportRepo
    {
        Task<Guid> Create(Guid PatientId,
                                       Guid TimeslotId,
                                       Guid DoctorId,
                                       Guid? AppointmentId,
                                       string Diagnosis,
                                       string Symptoms,
                                       string PrescribedTreatment,
                                       string ReferralTests,
                                       string VisualExamination,
                                       int FinalCost);

        Task<MedicalRecord> Get(Guid id);

        Task<Guid> Update(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);
    }
}
