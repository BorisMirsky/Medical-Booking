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
            await _context.MedicalRecords.AddAsync(medRec);
            await _context.SaveChangesAsync();
            return id;
        }


        // getByPatient
        public async Task<List<MedicalRecordDTO>> GetByPatient(Guid patientId)
        {
            var entities = await _context.MedicalRecords
               .Include(item => item.Doctor)
               .Include(item => item.Timeslot)
               .Include(item => item.Patient)
               .Include(item => item.Booking)
               .Include(item => item.Appointment)
               .Where(item => item.PatientId == patientId) // && item.IsBooked == true)
               .ToListAsync();

            if (entities.Equals(0))
            {
                Debug.WriteLine("there are not shit bookings for that patient");
                //throw new Exception($"Doctors with speciality {speciality} not found");
            }

            var Dtos = entities
                .Select(b => new MedicalRecordDTO(b.Id,
                                            b.Doctor?.Speciality,
                                            b.Doctor?.UserName,
                                            b.Patient?.UserName,
                                            b.Timeslot?.DatetimeStart,
                                            b.Timeslot?.DatetimeStop,
                                            b.Appointment?.PatientCame,
                                            b.Appointment?.PatientIsLate,
                                            b.Appointment?.PatientUnacceptableBehavior,
                                            b.Symptoms, b.Diagnosis, b.PrescribedTreatment,
                                            b.VisualExamination, b.ReferralTests, b.FinalCost))

                .ToList();

            return Dtos;
        }
    }
}
