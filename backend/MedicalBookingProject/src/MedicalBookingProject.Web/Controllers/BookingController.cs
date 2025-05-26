using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using MedicalBookingProject.Application.Services;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Users;




namespace MedicalBookingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        //[HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "manager")]
        //public async Task<ActionResult<SheduleResponse>> CreateBooking() //[FromBody] BookingRequest request)
        //{
        //Shedule shedule = new Shedule(request.DoctorId, request.StartDay, request.Days,
        //                              request.TimeStart, request.TimeStop, request.TimeChunk);
        //Shedule shed = new(request.StartDay, request.Days);  //request.DoctorId,
        //var newShedule = await _sheduleService.CreateShedule(shedule);
        //return Ok(); // newShedule);
        //}

        [Route("GetOneBooking")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> GetOneBooking(Guid id)
        {
            Booking booking = await _bookingService.GetOneBooking(id);

            if (booking != null)
            {
                return Ok(booking);
            }

            return BadRequest(new { message = "booking is not recognized" });
        }

        // 
        [Route("CancelBooking")]
        [HttpPatch]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> CancelBooking(Guid id)
        {
            Booking booking = await _bookingService.CancelBooking(id);

            if (booking != null)
            {
                return Ok(booking);
            }

            return BadRequest(new { message = "booking is not recognized" });
        }

    }
}
