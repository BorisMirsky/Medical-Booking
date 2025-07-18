using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.DataAccess.Repo;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MedicalBookingProject.Domain.Models.Users;




namespace MedicalBookingProject.DataAccess.Repo
{


    public class MedicalRecordRepo : IMedicalRecordRepo
    {

        public AppointmentRepo appointmentRepo;

        private readonly MedicalBookingDbContext _context;

        public MedicalRecordRepo(MedicalBookingDbContext context)
        {
            _context = context;
            appointmentRepo = new AppointmentRepo(context);
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
            Guid AppointmentId = await appointmentRepo.GetByBookingId(bookingId); 
            MedicalRecord medRec = new()
            {
                Id = id,
                BookingId = bookingId,
                DoctorId = doctorId,
                PatientId = patientId,
                TimeslotId = timeslotId,
                AppointmentId = AppointmentId,
                Diagnosis = diagnosis,
                Symptoms = symptoms,
                PrescribedTreatment = prescribedTreatment,
                ReferralTests = referralTests,
                VisualExamination = visualExamination,
                FinalCost = finalCost
            };
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("MedicalRecord");
            Debug.WriteLine(id);
            Debug.WriteLine(AppointmentId);
            Debug.WriteLine(bookingId);
            Debug.WriteLine(doctorId);
            Debug.WriteLine(patientId);
            Debug.WriteLine(timeslotId);
            Debug.WriteLine("");
            Debug.WriteLine("");
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
