using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.Domain.Models.Appointments;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MedicalBookingProject.Domain.Models.Bookings;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {

        private readonly MedicalBookingDbContext _context;
        //public TimeslotRepo slotRepo;
        //public BookingRepo bookingRepo;

        public AppointmentRepo(MedicalBookingDbContext context)
        {
            _context = context;
            //slotRepo = new TimeslotRepo(_context);
            //bookingRepo = new BookingRepo(_context);
        }


        public async Task<Guid> Create(Guid doctorId, Guid patientId,
                                    Guid timeslotId, Guid bookingId,
                                     string? patientCame, string? patientIsLate,
                                     string? patientUnacceptableBehavior)
        {
            Guid id = Guid.NewGuid();            
            Appointment app = new Appointment();
            app.Id = id;
            app.PatientId = patientId;
            app.DoctorId = doctorId;
            app.TimeslotId = timeslotId;
            app.BookingId = bookingId;
            app.PatientCame = patientCame;
            app.PatientIsLate = patientIsLate;
            app.PatientUnacceptableBehavior = patientUnacceptableBehavior;
            await _context.Appointments.AddAsync(app);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
