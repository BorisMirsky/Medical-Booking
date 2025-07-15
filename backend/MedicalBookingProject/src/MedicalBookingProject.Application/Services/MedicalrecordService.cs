using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.MedicalRecords;




namespace MedicalBookingProject.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {

        private readonly IMedicalReportRepo _medicalReportRepo;
        public MedicalRecordService(IMedicalReportRepo medicalreportRepo)
        {
            _medicalReportRepo = medicalreportRepo;
        }

        public async Task<Guid> CreateMedicalRecord(Guid PatientId,
                                                   Guid TimeslotId,
                                                   Guid DoctorId,
                                                   Guid BookingId,
                                                   Guid? AppointmentId,
                                                   string Diagnosis,
                                                   string Symptoms,
                                                   string PrescribedTreatment,
                                                   string ReferralTests,
                                                   string VisualExamination,
                                                   int FinalCost)
        {
            return await _medicalReportRepo.Create(PatientId,
                                       TimeslotId,
                                       DoctorId,
                                       BookingId,
                                       AppointmentId,
                                       Diagnosis,
                                       Symptoms,
                                       PrescribedTreatment,
                                       ReferralTests,
                                       VisualExamination,
                                       FinalCost); 
        }

        public async Task<MedicalRecord> GetMedicalRecord(Guid id)
        {
            return await _medicalReportRepo.Get(id);
        }

        public async Task<Guid> UpdateMedicalRecord(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment)
        {
            await _medicalReportRepo.Update(Id, Symptoms,
                                            Diagnosis, PrescribedTreatment);
            return Id;
        }
    }
}
