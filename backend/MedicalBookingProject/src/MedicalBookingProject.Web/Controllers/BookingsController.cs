using Microsoft.AspNetCore.Http;
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



        [Route("GetByPatient/{id}")] 
        [HttpGet] 
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<IEnumerable<BookingDTO>>> GetByPatient(Guid id)
        {
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine(id);
            Debug.WriteLine("");
            Debug.WriteLine("");
            //Guid id1 = new Guid("CD1E0477-C80C-43EC-8BA6-8B000D26DE29");
            IEnumerable<BookingDTO> bookings = await _bookingService.GetByPatient(id);

            if (bookings != null)
            {
                return Ok(bookings);
            }

            return BadRequest(new { message = "there'are not that patient" });
        }



        //[Route("GetByDoctor")]
        //[HttpGet("{doctorId}")]
        ////[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        //public async Task<IActionResult> GetByDoctor(Guid doctorId)
        //{
        //    List<Booking> bookings = await _bookingService.GetByDoctor(doctorId);

        //    if (bookings != null)
        //    {
        //        return Ok(bookings);
        //    }

        //    return BadRequest(new { message = "there'are not bookings for that doctor" });
        //}
    }
}
