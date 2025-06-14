using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.MedicalRecords;




namespace MedicalBookingProject.Application.Services
{
    public class MedicalrecordService : IMedicalrecordService
    {

        private readonly IMedicalreportRepo _medicalreportRepo;
        public MedicalrecordService(IMedicalreportRepo medicalreportRepo)
        {
            _medicalreportRepo = medicalreportRepo;
        }

        public async Task<Guid> CreateMedicalRecord(string Diagnosis,
                                       string Symptoms,
                                       string PrescribedTreatment,
                                       Guid AppointmentId)
        {
            return await _medicalreportRepo.Create(Diagnosis, Symptoms,
                                                   PrescribedTreatment,
                                                   AppointmentId); 
        }

        public async Task<MedicalRecord> GetMedicalRecord(Guid id)
        {
            return await _medicalreportRepo.Get(id);
        }

        public async Task<Guid> UpdateMedicalRecord(Guid Id, string Symptoms,
                                       string Diagnosis,
                                       string PrescribedTreatment)
        {
            await _medicalreportRepo.Update(Id, Symptoms,
                                            Diagnosis, PrescribedTreatment);
            return Id;
        }
    }
}
