using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.Domain.Models.Appointments;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {

        public BookingRepo bookingRepo;

        private readonly MedicalBookingDbContext _context;

        public AppointmentRepo(MedicalBookingDbContext context)
        {
            _context = context;
            bookingRepo = new BookingRepo(context);
        }


        public async Task<Guid> Create(Guid bookingId, Guid doctorId,
                                     Guid patientId, Guid timeslotId, 
                                     string? patientCame, string? patientIsLate,
                                     string? patientUnacceptableBehavior)
        {
            Guid id = Guid.NewGuid();
            Appointment app = new()
            {
                Id = id,
                PatientId = patientId,
                DoctorId = doctorId,
                TimeslotId = timeslotId,
                BookingId = bookingId,
                PatientCame = patientCame,
                PatientIsLate = patientIsLate,
                PatientUnacceptableBehavior = patientUnacceptableBehavior
            };
            await _context.Appointments.AddAsync(app);
            await _context.SaveChangesAsync();
            return id;
        }


        public async Task<Guid> GetByBookingId(Guid id)
        {

            Appointment? entity = await _context.Appointments
                .FirstOrDefaultAsync(a => a.BookingId == id);

            if (entity == null)
            {
                Debug.WriteLine("there are not such shit Appointments");
            }

            Guid appId = entity!.Id;
            return appId;
        }



        public async Task<List<AppointmentDTO>> GetByPatient(Guid patientId)
        {
            var entities = await _context.Appointments
               .Include(item => item.Doctor)
               .Include(item => item.Timeslot)
               .Include(item => item.Patient)
               .Include(item => item.Booking)
               .Where(item => item.PatientId == patientId) 
               .GroupBy(item => item.TimeslotId)
               .Select(g => g.OrderByDescending(item => item.Booking!.CreatedAt).FirstOrDefault())
               .ToListAsync();

            if (entities.Equals(0))
            {
                Debug.WriteLine("there are not shit bookings for that patient");
            }

            var Dtos = entities
                .Select(b => new AppointmentDTO(b.Id, b.BookingId, b.DoctorId, 
                                            b.PatientId, b.TimeslotId, 
                                            b.Doctor.Speciality, b.Doctor.UserName,
                                            b.Patient?.UserName,
                                            b.Timeslot?.DatetimeStart,
                                            b.Timeslot?.DatetimeStop))
                                            //b.PatientCame, b.PatientIsLate,
                                            //b.PatientUnacceptableBehavior))
                .ToList();

            return Dtos;
        }


        public async Task<List<AppointmentDTO>> GetByDoctor(Guid doctorId)
        {
            var entities = await _context.Appointments
               .Include(item => item.Doctor)
               .Include(item => item.Timeslot)
               .Include(item => item.Patient)
               .Include(item => item.Booking)
               .Where(item => item.DoctorId == doctorId) // && item.IsClosed == false)
               .GroupBy(item => item.TimeslotId)
               .Select(g => g.OrderByDescending(item => item.Booking!.CreatedAt).FirstOrDefault())
               .ToListAsync();

            if (entities.Equals(0))
            {
                Debug.WriteLine("there are not any bookings for that patient");
                //throw new Exception($"Doctors with speciality {speciality} not found");
            }

            var Dtos = entities
                .Select(b => new AppointmentDTO(b.Id, b.BookingId, b.DoctorId,
                                            b.PatientId, b.TimeslotId,
                                            b.Doctor.Speciality, b.Doctor.UserName,
                                            b.Patient?.UserName,
                                            b.Timeslot?.DatetimeStart,
                                            b.Timeslot?.DatetimeStop))
                .ToList();

            return Dtos;
        }
    }
}
