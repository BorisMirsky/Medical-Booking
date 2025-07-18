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
            //var booking = await _context.Bookings
            //                       .Where(item => item.Id == bookingId)
            //                       .FirstOrDefaultAsync();
            //booking!.IsClosed = true;
            //await _context.Bookings.AddAsync(booking);
            //
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
            //
            await _context.SaveChangesAsync();
            //await bookingRepo.PatchIsCLosed(bookingId);      //
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
    }
}
