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
    public class MedicalreportRepo : IMedicalreportRepo
    {
        private readonly MedicalBookingDbContext _context;
        public TimeslotRepo slotRepo;
        public BookingRepo bookingRepo;
        public AppointmentRepo appointmentRepo;

        public MedicalreportRepo(MedicalBookingDbContext context)
        {
            _context = context;
            slotRepo = new TimeslotRepo(_context);
            bookingRepo = new BookingRepo(_context);
            appointmentRepo = new AppointmentRepo(_context);
        }

        public async Task<Guid> Create(string? Diagnosis,
                                       string? Symptoms,
                                       string? PrescribedTreatment,
                                       Guid AppointmentId)
        {
            //ArgumentNullException.ThrowIfNull(bookingId);
            Guid id = Guid.NewGuid();
            //Booking booking = await bookingRepo.GetOneBooking(bookingId);
            MedicalRecord medRec = new();
            medRec.Id = id;
            medRec.PrescribedTreatment = PrescribedTreatment;
            medRec.Diagnosis = Diagnosis;
            medRec.Symptoms = Symptoms;
            medRec.AppointmentId = AppointmentId;
            Appointment app = await appointmentRepo.Get(AppointmentId);
            medRec.PatientId = app.PatientId;
            medRec.DoctorId = app.DoctorId; 
            Timeslot slot = await slotRepo.Get(app.TimeslotId);
            //medRec.  Treatment = "";
            //medRec.MakingDiagnosis = "";
            medRec.ReferralTests = "";
            medRec.VisualExamination = "";
            medRec.FinalCost = 0;
            //medRec.SlotStart = slot.Bookings.   DatetimeStart;
            //medRec.SlotStop = slot.DatetimeStop;
            await _context.MedicalRecords.AddAsync(medRec);
            await _context.SaveChangesAsync();
            return id;
        }


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
