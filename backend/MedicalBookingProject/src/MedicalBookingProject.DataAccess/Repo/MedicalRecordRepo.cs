using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using Microsoft.EntityFrameworkCore;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class MedicalRecordRepo : IMedicalRecordRepo
    {

        private readonly MedicalBookingDbContext _context;

        public MedicalRecordRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Create(Guid bookingId,
                                        Guid doctorId,
                                        Guid patientId,
                                        Guid timeslotId,
                                        Guid appointmentId,   
                                        string? diagnosis,
                                        string? symptoms,
                                        string? prescribedTreatment,
                                        string? referralTests,
                                        string? visualExamination,
                                        uint? finalCost)
        {
            Guid id = Guid.NewGuid();
            MedicalRecord medRec = new()
            {
                Id = id,
                BookingId = bookingId,
                DoctorId = doctorId,
                PatientId = patientId,
                TimeslotId = timeslotId,
                AppointmentId = appointmentId,  
                Diagnosis = diagnosis,
                Symptoms = symptoms,
                PrescribedTreatment = prescribedTreatment,
                ReferralTests = referralTests,
                VisualExamination = visualExamination,
                FinalCost = finalCost
            };
            await _context.MedicalRecords.AddAsync(medRec);
            await _context.SaveChangesAsync();
            return id;
        }


        public async Task<List<MedicalRecordDTO>> GetByPatient(Guid patientId)
        {
            var entities = await _context.MedicalRecords
               .Include(item => item.Doctor)
               .Include(item => item.Timeslot)
               .Include(item => item.Patient)
               .Include(item => item.Booking)
               .Include(item => item.Appointment)
               .Where(item => item.PatientId == patientId) 
               .ToListAsync();

            var Dtos = entities
                .Select(b => new MedicalRecordDTO(b.Id,
                                            b.PatientId,
                                            b.Doctor?.Speciality ?? string.Empty,
                                            b.Doctor?.UserName ?? string.Empty,
                                            b.Patient?.UserName ?? string.Empty,
                                            b.Timeslot?.DatetimeStart ?? string.Empty,
                                            b.Timeslot?.DatetimeStop ?? string.Empty,
                                            b.Appointment?.PatientCame ?? string.Empty,
                                            b.Appointment?.PatientIsLate ?? string.Empty,
                                            b.Appointment?.PatientUnacceptableBehavior ?? string.Empty,
                                            b.Symptoms ?? string.Empty, 
                                            b.Diagnosis ?? string.Empty,
                                            b.PrescribedTreatment ?? string.Empty,
                                            b.VisualExamination ?? string.Empty, 
                                            b.ReferralTests ?? string.Empty, 
                                            b.FinalCost))

                .ToList();

            return Dtos;
        }
    }
}
