using MedicalBookingProject.DataAccess.Repo;
using MedicalBookingProject.Domain.Abstractions;


namespace MedicalBookingProject.Application.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {

        private readonly IMedicalRecordRepo _medicalReportRepo;
        private readonly IAppointmentService _appointmentService;
        public MedicalRecordService(IMedicalRecordRepo medicalreportRepo, IAppointmentService appointmentService)
        {
            _medicalReportRepo = medicalreportRepo;
            _appointmentService = appointmentService;
        }

        public async Task<Guid> CreateMedicalRecord(Guid bookingId, Guid doctorId, Guid patientId,
                                                Guid timeslotId,
                                                string? diagnosis, string? symptoms,
                                                string? prescribedTreatment, string? referralTests,
                                                string? visualExamination, uint? finalCost)
        {
            // Получаем AppointmentId по BookingId
            var appointmentId = await _appointmentService.GetByBookingId(bookingId);
            if (appointmentId == null)
            {
                throw new InvalidOperationException($"Appointment not found for BookingId {bookingId}");
            }

            // Передаём полученный AppointmentId в репозиторий
            return await _medicalReportRepo.Create(bookingId, doctorId, patientId, timeslotId,
                                                   appointmentId.Value,
                                                   diagnosis, symptoms,
                                                   prescribedTreatment, referralTests,
                                                   visualExamination, finalCost);
        }

        public async Task<List<MedicalRecordDTO>> GetByPatient(Guid id)
        {
            return await _medicalReportRepo.GetByPatient(id);
        }
    }
}
