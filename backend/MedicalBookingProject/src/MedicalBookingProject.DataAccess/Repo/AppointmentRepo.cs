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
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine("Appointment");
            Debug.WriteLine(id);
            Debug.WriteLine(bookingId);
            Debug.WriteLine(doctorId);
            Debug.WriteLine(patientId);
            Debug.WriteLine(timeslotId);
            Debug.WriteLine("");
            Debug.WriteLine("");
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
    }
}
