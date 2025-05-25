using MedicalBookingProject.DataAccess.Entities;
using MedicalBookingProject.DataAccess.Scripts;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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


        public async Task<Guid> Create(Guid id, Guid id1)  //Booking booking)
        {
            var sheduleEntities = await _context.SheduleEntities
                .AsNoTracking()
                .ToListAsync();
            var sheduleEntitie = sheduleEntities
               .Where(item => item.SlotId == id)
               .ToList()
               .FirstOrDefault();
            //
            var bookingId = Guid.NewGuid();
            var bookingEntity = new BookingEntity
            {
                Id = bookingId,
                SlotId = sheduleEntitie!.SlotId,
                DoctorId = sheduleEntitie.DoctorId,
                PatientId = id1,
                WasCancelled = false,
                CancelledBy = id1,
                CancelledAt = DateTime.Now
            };
            await _context.BookingEntities.AddAsync(bookingEntity);
            await _context.SaveChangesAsync();
            return bookingId;
        }
    }
}
