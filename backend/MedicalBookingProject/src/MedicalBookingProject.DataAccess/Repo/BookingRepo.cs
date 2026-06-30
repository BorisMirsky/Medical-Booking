using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class BookingRepo : IBookingRepo
    {
        private readonly MedicalBookingDbContext _context;

        public BookingRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Create(Guid slotId, Guid patientId, 
                                       Guid doctorId, Boolean isBooked)
        {
            var bookingId = Guid.NewGuid();
            var booking = new Booking();
            booking.TimeslotId = slotId;
            booking.DoctorId = doctorId; 
            booking.PatientId = patientId;  
            booking.IsBooked = isBooked; 
            DateTime created = DateTime.Now;
            booking.CreatedAt = created;
            booking.Id = bookingId;
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return bookingId;
        }


        // группировка – это чисто запросная логика, которую можно оставить в репозитории
        public async Task<List<BookingDTO>> GetByPatient(Guid patientId)
        {
            var entities = await _context.Bookings
                .Include(b => b.Doctor)
                .Include(b => b.Timeslot)
                .Include(b => b.Patient)
                .Where(b => b.PatientId == patientId)
                .GroupBy(b => b.TimeslotId)
                .Select(g => g.OrderByDescending(b => b.CreatedAt).FirstOrDefault())
                .ToListAsync();

            if (!entities.Any())
            {
                Console.WriteLine($"No bookings found for patient {patientId} at {DateTime.Now}");
            }

            return entities
                .Select(b => new BookingDTO(
                    b.Id,
                    b.DoctorId,
                    b.PatientId,
                    b.TimeslotId,
                    b.IsBooked,
                    b.IsClosed,
                    b.CreatedAt,
                    b.Doctor?.UserName,
                    b.Doctor?.Speciality,
                    b.Patient?.UserName,
                    b.Timeslot?.DatetimeStart,
                    b.Timeslot?.DatetimeStop))
                .ToList();
        }



        public async Task<List<BookingDTO>> GetByDoctor(Guid doctorId)
        {
            var entities = await _context.Bookings
                .Include(b => b.Doctor)
                .Include(b => b.Timeslot)
                .Include(b => b.Patient)
                .Where(b => b.DoctorId == doctorId && b.IsClosed == false)
                .GroupBy(b => b.TimeslotId)
                .Select(g => g.OrderByDescending(b => b.CreatedAt).FirstOrDefault())
                .ToListAsync();

            if (!entities.Any())
            {
                Console.WriteLine($"No active bookings for doctor {doctorId} at {DateTime.Now}");
            }

            return entities
                .Select(b => new BookingDTO(
                    b.Id,
                    b.DoctorId,
                    b.PatientId,
                    b.TimeslotId,
                    b.IsBooked,
                    b.IsClosed,
                    b.CreatedAt,
                    b.Doctor?.UserName,
                    b.Doctor?.Speciality,
                    b.Patient?.UserName,
                    b.Timeslot?.DatetimeStart,
                    b.Timeslot?.DatetimeStop))
                .ToList();
        }



        public async Task SetBookingClosed(Guid id)
        {
            var booking = await _context.Bookings.FirstOrDefaultAsync(b => b.Id == id);
            if (booking != null)
            {
                booking.IsClosed = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}

