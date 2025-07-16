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

        public AppointmentRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Create(Guid bookingId, Guid doctorId,
                                    Guid patientId, Guid timeslotId, 
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
            //Debug.WriteLine("");
            //Debug.WriteLine("");
            //Debug.WriteLine(app.Id);
            //Debug.WriteLine(app.BookingId);
            //Debug.WriteLine(app.DoctorId);
            //Debug.WriteLine(app.PatientId);
            //Debug.WriteLine(app.TimeslotId);
            //Debug.WriteLine(app.PatientCame);
            //Debug.WriteLine(app.PatientIsLate);
            //Debug.WriteLine(app.PatientUnacceptableBehavior);
            //Debug.WriteLine("");
            //Debug.WriteLine("");
            await _context.Appointments.AddAsync(app);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
