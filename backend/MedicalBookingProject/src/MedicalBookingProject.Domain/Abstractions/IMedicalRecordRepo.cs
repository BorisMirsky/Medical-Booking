using MedicalBookingProject.Domain.Models.MedicalRecords;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMedicalRecordRepo
    {
        Task<Guid> Create(Guid BookingId,
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

        //Task<MedicalRecord> Get(Guid id);

        //Task<Guid> Update(Guid Id, string Symptoms,
        //                               string Diagnosis,
        //                               string PrescribedTreatment);

        Task<List<MedicalRecordDTO>> GetByPatient(Guid patientId);
        //Task<List<MedicalRecord>> GetByPatientId(Guid id);
    }
}
