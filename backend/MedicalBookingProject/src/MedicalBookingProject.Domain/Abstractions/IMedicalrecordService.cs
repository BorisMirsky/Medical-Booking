
using MedicalBookingProject.Domain.Models.MedicalRecords;



namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalrecordService
    {
        Task<Guid> CreateMedicalRecord(string Diagnosis,
                                       string Symptoms,
                                       string PrescribedTreatment,
                                       Guid AppointmentId);
                                       //Guid PatientId,
                                       //Guid DoctorId);

        Task<MedicalRecord> GetMedicalRecord(Guid id);

        Task<Guid> UpdateMedicalRecord(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);
    }
}
