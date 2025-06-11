using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Services;


namespace MedicalBookingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeslotController : ControllerBase
    {

        private readonly ITimeslotService _timeslotService;

        private readonly IBookingService _bookingService;

        public TimeslotController(ITimeslotService timeslotService, IBookingService bookingService)
        {
            _timeslotService = timeslotService;
            _bookingService = bookingService;
        }

        [HttpPost]   //Task<ActionResult<TimeslotResponse>>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "manager")]
        public async void CreateTimeslot([FromBody] TimeslotRequest request)
        {
            await _timeslotService.CreateTimeslot(request.DoctorId, request.StartDay, request.Days,
                                                             request.TimeStart, request.TimeStop, request.TimeChunk);
            //return Ok(newShedule);
        }


        [HttpGet]
        public async Task<ActionResult<Timeslot>> GetById(Guid id)
        {
            Timeslot timeslot = await _timeslotService.GetTimeslot(id);
            return Ok(timeslot);
        }


        [HttpPatch]
        public async Task<ActionResult<Guid>> UpdateBooking([FromBody] BookingRequest request)
        {
            var slotId = await _timeslotService.UpdateTimeslot(request.SlotId, request.PatientId, request.IsBooked);
            await _bookingService.CreateBooking(request.SlotId, request.CancelledBy,
                                                request.BookingOrCancelDatetime,
                                                request.PatientId, request.IsBooked);
            return Ok(slotId);
        }

    }
}
