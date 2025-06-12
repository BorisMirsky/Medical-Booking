
using MedicalBookingProject.Domain.Models.MedicalRecords;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalrecordService
    {
        Task<Guid> CreateMedicalRecord(string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);

        Task<MedicalRecord> GetMedicalRecord(Guid id);

        Task<Guid> UpdateMedicalRecord(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);
    }
}
