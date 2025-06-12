using MedicalBookingProject.Domain.Models.MedicalRecords;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalreportRepo
    {
        Task<Guid> Create(string Symptoms,
                               string Diagnosis,
                               string PrescribedTreatment);

        Task<MedicalRecord> Get(Guid id);

        Task<Guid> Update(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);
    }
}
