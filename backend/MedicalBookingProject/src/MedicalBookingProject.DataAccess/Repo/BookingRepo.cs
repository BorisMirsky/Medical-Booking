using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.DataAccess.Repo;
using Microsoft.EntityFrameworkCore;




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


        public async Task<Guid> Create(Guid slotId, Guid patientId, Guid doctorId,
                                        Boolean isBooked, Guid? cancelledBy, 
                                        DateTime? bookingOrCancelDatetime)
        {
            var bookingId = Guid.NewGuid();
            var booking = new Booking();
            Timeslot slot = await slotRepo.Get(slotId);
            booking.TimeslotId = slotId;
            booking.DoctorId = slot.DoctorId;

            if (slot.IsBooked == false)
            {
                booking.IsBooked = false;
            }
            else
            {
                booking.IsBooked = (Boolean)slot.IsBooked;
            }

            if (slot.PatientId == Guid.Empty)
            {
                booking.PatientId = Guid.Empty;
            }
            else
            {
                booking.PatientId = (Guid)slot.PatientId;
            }

            booking.Id = bookingId;
            booking.CancelledBy = (Guid)cancelledBy;
            booking.BookingOrCancelDatetime = bookingOrCancelDatetime;
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
            return bookingId;
        }



        public async Task<Booking> GetOneBooking(Guid id)
        {
            Booking? booking = await _context.Bookings
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(s => s.Id == id);
            return booking!;
        }
    }
}
