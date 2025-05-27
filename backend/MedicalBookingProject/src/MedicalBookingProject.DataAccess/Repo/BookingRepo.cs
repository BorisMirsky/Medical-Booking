using MedicalBookingProject.DataAccess.Entities;
using MedicalBookingProject.DataAccess.Scripts;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class BookingRepo : IBookingRepo
    {
        private readonly MedicalBookingDbContext _context;

        public BookingRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }


        public async Task<Guid> Create(Guid slotid, Guid patientid,
                          Boolean isbooked, Boolean? wascancelled, 
                          Guid cancelledby, DateTime cancelledat)
        {
            var sheduleEntities = await _context.SheduleEntities
                .AsNoTracking()
                .ToListAsync();
            var sheduleEntitie = sheduleEntities
               .Where(item => item.SlotId == slotid)
               .ToList()
               .LastOrDefault();   // no FirstOrDefault 
            //
            var bookingId = Guid.NewGuid();
            var bookingEntity = new BookingEntity
            {
                Id = bookingId,
                SlotId = sheduleEntitie!.SlotId,
                DoctorId = sheduleEntitie.DoctorId,
                PatientId = patientid,
                IsBooked = isbooked,
                WasCancelled = wascancelled,  
                CancelledBy = patientid,
                CancelledAt = DateTime.Now
            };
            await _context.BookingEntities.AddAsync(bookingEntity);
            await _context.SaveChangesAsync();
            return bookingId;
        }



        public async Task<Booking> GetOneBooking(Guid id)
        {
            var entities = await _context.BookingEntities
                .AsNoTracking()
                .ToListAsync();
            var entity = entities
               .Where(item => item.Id == id)
               .ToList()
               .FirstOrDefault();
            if (entity == null)
            {
                Debug.WriteLine("booking with id {id} not found");
                throw new Exception($"booking with id {id} not found");
            }
            Booking booking = new(entity.DoctorId, entity.PatientId,
                                  entity.SlotId);
            booking.WasCancelled = entity.WasCancelled;
            booking.CancelledBy = entity.CancelledBy;
            booking.CancelledAt = entity.CancelledAt;
            booking.Id = id;
            return booking!;
        }
    }
}
