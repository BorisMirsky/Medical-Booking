using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using MedicalBookingProject.Application.Services;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;
using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;



namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }


        [Route("CreateBooking")]     
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "patient")]
        public async Task<ActionResult> CreateBooking([FromBody] BookingRequest request)
        {
            await _bookingService.CreateBooking(request.SlotId, request.PatientId,
                                                request.DoctorId, request.IsBooked);
            return Ok();
        }


        [Route("SetBookingClosed")]
        [HttpPatch]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<ActionResult<Guid>> SetBookingClosed([FromQuery] Guid id)
        {
            var result = await _bookingService.SetBookingClosed(id);
            return Ok(result);
        }


        [Route("GetByPatient")]     
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, doctor, patient")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, doctor, patient")]
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
