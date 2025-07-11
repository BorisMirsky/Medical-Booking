﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using MedicalBookingProject.Application.Services;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;
using System.Diagnostics;




namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [Route("CreateBooking")]     
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "manager")]
        public async Task<ActionResult> CreateBooking([FromBody] BookingRequest request)
        {
            await _bookingService.CreateBooking(request.SlotId, request.PatientId,
                                                request.DoctorId, request.IsBooked);
            return Ok();
        }



        //[Route("GetOneBooking")]
        //[HttpGet]
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        //public async Task<IActionResult> GetOneBooking(Guid id)
        //{
        //    Booking booking = await _bookingService.GetOneBooking(id);

        //    if (booking != null)
        //    {
        //        return Ok(booking);
        //    }

        //    return BadRequest(new { message = "booking is not recognized" });
        //}



        [Route("GetByPatient")]     
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<List<BookingDTO>>> GetByPatient([FromQuery] Guid id)
        {
            List<BookingDTO> bookings = await _bookingService.GetByPatient(id);

            if (bookings != null)
            {
                return Ok(bookings);
            }

            return BadRequest(new { message = "there'are not such patient" });
        }



        [Route("GetByDoctor")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<List<BookingDTO>>> GetByDoctor([FromQuery] Guid id)
        {
            List<BookingDTO> bookings = await _bookingService.GetByDoctor(id);

            if (bookings != null)
            {
                return Ok(bookings);
            }

            return BadRequest(new { message = "there'are not such doctor" });
        }
    }
}
