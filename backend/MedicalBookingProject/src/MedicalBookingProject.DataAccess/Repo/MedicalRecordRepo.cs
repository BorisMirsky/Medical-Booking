using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.DataAccess.Configuration;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;




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
                AppointmentId = Guid.NewGuid(),
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


        // getByPatient
        public async Task<MedicalRecord> Get(Guid id)
        {
            MedicalRecord? entity = await _context.MedicalRecords
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(a => a.Id == id);
            return entity!;
        }


        public async Task<Guid> Update(Guid Id, string? Symptoms,
                                       string? Diagnosis,
                                       string? PrescribedTreatment)
        {
            await _context.MedicalRecords
                .Where(item => item.Id == Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.Symptoms, s => Symptoms)
                .SetProperty(s => s.Diagnosis, s => Diagnosis)
                .SetProperty(s => s.PrescribedTreatment, s => PrescribedTreatment)
                );
            return Id;
        }

    }
}
