using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.DataAccess.Entities;
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
            var appointmentEntity = new AppointmentEntity
            {
                Id = id,
                DoctorId = app.DoctorId,
                PatientId = app.PatientId,
                SlotId = app.SlotId,
                MedicalCardId = app.MedicalCardId,
                PatientCame = app.PatientCame,
                PatientIsLate = app.PatientIsLate,
                FinalCost = app.FinalCost
            };
            await _context.AppointmentEntities.AddAsync(appointmentEntity);
            await _context.SaveChangesAsync();
            return id;
        }


        public async Task<Appointment> Get(Guid id)
        {
            var entities = await _context.AppointmentEntities
                .AsNoTracking()
                .ToListAsync();
            var entity = entities
               .Where(item => item.Id == id)
               .ToList()
               .FirstOrDefault();
            Appointment app = new(entity.DoctorId,
                                   entity.PatientId, entity.SlotId,
                                   entity.MedicalCardId, entity.PatientCame,
                                   entity.PatientIsLate, entity.FinalCost);
            app.Id = entity.Id;
            return app;
        }


        // Patch
        public async Task<Guid> UpdateUnacceptableBehavior(Guid id, String description)
        {
            await _context.AppointmentEntities
                .Where(item => item.Id == id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(s => s.PatientUnacceptableBehavior, s => description)
                );
            return id;

        }
    }
}
