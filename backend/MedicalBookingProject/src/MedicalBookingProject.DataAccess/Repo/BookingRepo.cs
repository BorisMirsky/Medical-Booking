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


        public async Task<Guid> Create(Guid slotId, Guid? patientId, Guid doctorId,
                                       Boolean? isBooked, Guid? cancelledBy, 
                                       DateTime? bookingOrCancelDatetime)
        {
            var bookingId = Guid.NewGuid();
            var entity = new Booking(doctorId, patientId, slotId);
            entity.IsBooked = isBooked;
            entity.CancelledBy = cancelledBy;
            entity.BookingOrCancelDatetime = bookingOrCancelDatetime;
            await _context.Bookings.AddAsync(entity);
            await _context.SaveChangesAsync();
            return bookingId;
        }



        public async Task<Booking> GetOneBooking(Guid id)
        {
            Booking? entity = await _context.Bookings
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(s => s.SlotId == id);
            return entity!;
        }
    }
}
