using MedicalBookingProject.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.DataAccess.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.DataAccess;
using MedicalBookingProject.DataAccess.Scripts;
using MedicalBookingProject.DataAccess.Repo;



namespace MedicalBookingProject.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public async Task<Guid> CreateBooking(Guid id, Guid id1) //Booking booking)
        {
            return await _bookingRepo.Create(id, id1);
        }

        public async Task<Booking> GetOneBooking(Guid id)
        {
            return await _bookingRepo.GetOneBooking(id);
        }

        public async Task<Booking> CancelBooking(Guid id)
        {
            return await _bookingRepo.Cancel(id);
        }

    }
}
