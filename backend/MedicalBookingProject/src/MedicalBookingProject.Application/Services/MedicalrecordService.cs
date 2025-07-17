using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.MedicalRecords;




namespace MedicalBookingProject.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {

        private readonly IMedicalRecordRepo _medicalReportRepo;
        public MedicalRecordService(IMedicalRecordRepo medicalreportRepo)
        {
            _medicalReportRepo = medicalreportRepo;
        }

        public async Task<Guid> CreateMedicalRecord(Guid BookingId,
                                                   Guid DoctorId,
                                                   Guid PatientId,
                                                   Guid TimeslotId,
                                                   Guid AppointmentId,
                                                   string? Diagnosis,
                                                   string? Symptoms,
                                                   string? PrescribedTreatment,
                                                   string? ReferralTests,
                                                   string? VisualExamination,
                                                   uint? FinalCost)
        {
            return await _medicalReportRepo.Create(BookingId,
                                                   DoctorId,
                                                   PatientId,
                                                   TimeslotId,
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
