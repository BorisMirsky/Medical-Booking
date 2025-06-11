using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.Domain.Models.Appointments;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.MedicalCards;
using MedicalBookingProject.Domain.Models.Bookings;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {

        private readonly MedicalBookingDbContext _context;
        public TimeslotRepo slotRepo;
        public BookingRepo bookingRepo;

        public AppointmentRepo(MedicalBookingDbContext context)
        {
            _context = context;
            slotRepo = new TimeslotRepo(_context);
            bookingRepo = new BookingRepo(_context);
        }

        public async Task<Guid> Create(Guid bookingId)
        {
            //ArgumentNullException.ThrowIfNull(bookingId);
            Guid id = Guid.NewGuid();
            Booking booking = await bookingRepo.GetOneBooking(bookingId);
            Appointment app = new Appointment();
            app.Booking = booking;
            app.BookingId = booking.Id;
            app.Id = id;
            app.PatientId = app.Booking.PatientId;
            app.DoctorId = app.Booking.DoctorId;
            app.SlotId = app.Booking.TimeslotId;
            await _context.Appointments.AddAsync(app);
            await _context.SaveChangesAsync();
            return id;
        }


        public async Task<Appointment> Get(Guid id)
        {
            Appointment? entity = await _context.Appointments
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(a => a.Id == id);
            return entity!;
        }


        // Patch
        public async Task<Guid> UpdateUnacceptableBehavior(Guid id, String description)
        {
            await _context.Appointments
                .Where(item => item.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.PatientUnacceptableBehavior, s => description)
                );
            return id;

        }
    }
}
