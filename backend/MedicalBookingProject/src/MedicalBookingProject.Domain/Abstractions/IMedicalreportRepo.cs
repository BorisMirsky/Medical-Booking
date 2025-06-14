using MedicalBookingProject.Domain.Models.MedicalRecords;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalreportRepo
    {
        Task<Guid> Create(string Diagnosis,
                            string Symptoms,
                            string PrescribedTreatment,
                            Guid AppointmentId);
                            //Guid DoctorId,
                            //Guid PatientId);

        Task<MedicalRecord> Get(Guid id);

        Task<Guid> Update(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment);
    }
}
