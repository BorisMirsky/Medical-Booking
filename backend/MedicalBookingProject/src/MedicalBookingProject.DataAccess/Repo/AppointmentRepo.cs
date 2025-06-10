using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
//using MedicalBookingProject.DataAccess.Entities;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.Domain.Models.Appointments;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.MedicalCards;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class AppointmentRepo : IAppointmentRepo
    {

        private readonly MedicalBookingDbContext _context;

        public AppointmentRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(Appointment app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            Guid id = Guid.NewGuid();
            app.Id = id;
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
