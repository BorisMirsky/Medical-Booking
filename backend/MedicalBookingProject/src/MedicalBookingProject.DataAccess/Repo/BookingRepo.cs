using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.DataAccess.Repo;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;




namespace MedicalBookingProject.DataAccess.Repo
{
    public class BookingRepo : IBookingRepo
    {
        private readonly MedicalBookingDbContext _context;
        public TimeslotRepo slotRepo;

        public BookingRepo(MedicalBookingDbContext context)
        {
            _context = context;
            slotRepo = new TimeslotRepo(_context);
        }


        public async Task<Guid> Create(Guid slotId, Guid patientId, 
                                       Guid doctorId, Boolean isBooked)
        {
            var bookingId = Guid.NewGuid();
            var booking = new Booking();
            //Timeslot slot = await slotRepo.Get(slotId);
            booking.TimeslotId = slotId;
            booking.DoctorId = doctorId; // slot.DoctorId;
            booking.PatientId = patientId;  // slot.PatientId;
            booking.IsBooked = isBooked; // slot.IsBooked;

            booking.Id = bookingId;
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return bookingId;
        }


        public async Task<List<Booking>> GetByPatient(Guid patientId)
        {
            var entities = await _context.Bookings
               .Where(item => item.PatientId == patientId && item.IsBooked == true)
               .ToListAsync();
            if (entities.Count() == 0)
            {
                Debug.WriteLine("there'are not bookings for that patient");
                //throw new Exception($"Doctors with speciality {speciality} not found");
            }
            return entities;
        }



        public async Task<List<Booking>> GetByDoctor(Guid doctortId)
        {
            var entities = await _context.Bookings
               .Where(item => item.DoctorId == doctortId && item.IsBooked == true)
               .ToListAsync();
            if (entities.Count() == 0)
            {
                Debug.WriteLine("there'are not bookings for that doctor");
                //throw new Exception($"Doctors with speciality {speciality} not found");
            }
            return entities;
        }
    }
}







//public async Task<Booking> GetOneBooking(Guid id)
//{
//    Booking? booking = await _context.Bookings
//                            .AsNoTracking()
//                            .FirstOrDefaultAsync(s => s.Id == id);
//    return booking!;
//}