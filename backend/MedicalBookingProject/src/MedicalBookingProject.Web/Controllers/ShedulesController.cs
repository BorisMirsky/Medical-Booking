using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.DataAccess.Entities;



namespace MedicalBookingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShedulesController : ControllerBase
    {
        private readonly ISheduleService _sheduleService;
        private readonly IBookingService _bookingService;

        public ShedulesController(ISheduleService sheduleService, IBookingService bookingService)
        {
            _sheduleService = sheduleService;
            _bookingService = bookingService;
        }


        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "manager")]
        public async Task<ActionResult<SheduleResponse>> CreateShedule([FromBody] SheduleRequest request)
        {
            var newShedule = await _sheduleService.CreateShedule(request.DoctorId, request.StartDay, request.Days,
                                                             request.TimeStart, request.TimeStop, request.TimeChunk);
            return Ok(newShedule);
        }


        [HttpGet]
        public async Task<ActionResult<Shedule>> GetSlotById(Guid id)
        {
            Shedule shedule = await _sheduleService.GetSlot(id);
            return Ok(shedule);
        }


        [HttpPatch]
        public async Task<ActionResult<Guid>> UpdateBooking([FromBody] BookingRequest request)
        {
            var slotId = await _sheduleService.UpdateSlot(request.SlotId, request.PatientId, request.IsBooked);
            await _bookingService.CreateBooking(request.SlotId, request.PatientId,
                                                request.DoctorId, request.IsBooked,
                                                request.CancelledBy, request.BookingOrCancelDatetime);
            return Ok(slotId);
        }
    }
}
