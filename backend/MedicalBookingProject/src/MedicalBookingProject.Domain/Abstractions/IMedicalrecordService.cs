
using MedicalBookingProject.Domain.Models.MedicalRecords;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalRecordService
    {
        Task<Guid> CreateMedicalRecord(Guid BookingId, 
                                       Guid DoctorId,
                                       Guid PatientId,
                                       Guid TimeslotId,
                                       Guid AppointmentId,
                                       string? Diagnosis,
                                       string? Symptoms,
                                       string? PrescribedTreatment,
                                       string? ReferralTests,
                                       string? VisualExamination,
                                       uint? FinalCost);

        Task<MedicalRecord> GetMedicalRecord(Guid id);

        Task<Guid> UpdateMedicalRecord(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);
    }
}
