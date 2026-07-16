using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Appointments;
using Microsoft.EntityFrameworkCore;


namespace MedicalBookingProject.DataAccess.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {

        private readonly MedicalBookingDbContext _context;

        public AppointmentRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Guid doctorId, Guid patientId,
                               Guid timeslotId, Guid bookingId,
                               string? patientCame, string? patientIsLate,
                               string? patientUnacceptableBehavior)
        {
            Guid id = Guid.NewGuid();
            Appointment app = new()
            {
                Id = id,
                DoctorId = doctorId,
                PatientId = patientId,
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

        public async Task<Guid?> GetByBookingId(Guid id)
        {

            Appointment? entity = await _context.Appointments
                .FirstOrDefaultAsync(a => a.BookingId == id);

            if (entity != null)
            {
                Guid appId = entity!.Id;
                return appId;
            }
            //Guid appId = entity!.Id;
            //return appId;
            return id;
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

            var Dtos = entities
                .Select(b => new AppointmentDTO(
                    b.Id,
                    b.BookingId,
                    b.DoctorId,
                    b.PatientId,
                    b.TimeslotId,
                    b.Doctor?.Speciality ?? string.Empty,     
                    b.Doctor?.UserName ?? string.Empty,        
                    b.Patient?.UserName ?? string.Empty,      
                    b.Timeslot?.DatetimeStart ?? string.Empty,
                    b.Timeslot?.DatetimeStop ?? string.Empty,
                    b.PatientCame ?? string.Empty,
                    b.PatientIsLate ?? string.Empty,
                    b.PatientUnacceptableBehavior ?? string.Empty
                ))
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
               .Where(item => item.DoctorId == doctorId) 
               .GroupBy(item => item.TimeslotId)
               .Select(g => g.OrderByDescending(item => item.Booking!.CreatedAt).FirstOrDefault())
               .ToListAsync();

            var Dtos = entities
                .Select(b => new AppointmentDTO(
                    b.Id,
                    b.BookingId,
                    b.DoctorId,
                    b.PatientId,
                    b.TimeslotId,
                    b.Doctor?.Speciality ?? string.Empty,     
                    b.Doctor?.UserName ?? string.Empty,        
                    b.Patient?.UserName ?? string.Empty,      
                    b.Timeslot?.DatetimeStart ?? string.Empty,
                    b.Timeslot?.DatetimeStop ?? string.Empty,
                    b.PatientCame ?? string.Empty,
                    b.PatientIsLate ?? string.Empty,
                    b.PatientUnacceptableBehavior ?? string.Empty
                ))
                .ToList();

            return Dtos;
        }

        public async Task<List<AppointmentDTO>> GetAll()
        {
            var entities = await _context.Appointments
                .Include(item => item.Doctor)
                .Include(item => item.Timeslot)
                .Include(item => item.Patient)
                .Include(item => item.Booking)
                .GroupBy(item => item.TimeslotId)
                .Select(g => g.OrderByDescending(item => item.Booking!.CreatedAt).FirstOrDefault())
                .ToListAsync();

            var Dtos = entities
                .Select(b => new AppointmentDTO(
                    b.Id,
                    b.BookingId,
                    b.DoctorId,
                    b.PatientId,
                    b.TimeslotId,
                    b.Patient?.UserName ?? string.Empty,     
                    b.Doctor?.UserName ?? string.Empty,
                    b.Doctor?.Speciality ?? string.Empty,
                    b.Timeslot?.DatetimeStart ?? string.Empty,
                    b.Timeslot?.DatetimeStop ?? string.Empty,
                    b.PatientCame ?? string.Empty,
                    b.PatientIsLate ?? string.Empty,
                    b.PatientUnacceptableBehavior ?? string.Empty
                ))
                .ToList();

            return Dtos;
        }
    }
}
