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

        public ShedulesController(ISheduleService sheduleService)
        {
            _sheduleService = sheduleService;
        }


        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "manager")]
        public async Task<ActionResult<SheduleResponse>> CreateShedule([FromBody] SheduleRequest request)
        {
            Shedule shedule = new Shedule(request.DoctorId, request.StartDay, request.Days,
                                          request.TimeStart, request.TimeStop, request.TimeChunk);  
            //Shedule shed = new( request.StartDay, request.Days);  //request.DoctorId,
            var newShedule = await _sheduleService.CreateShedule(shedule);
            return Ok(newShedule);
        }


        [HttpGet]
        public async Task<ActionResult<Shedule>> GetSlotById(Guid id)
        {
            Shedule slot = await _sheduleService.GetSlot(id);
            return Ok(slot);
        }

        [HttpPatch]
        public async Task<ActionResult<Guid>> BookingSlotById(Guid id, Guid id1)
        {
            var slotId = await _sheduleService.BookingSlot(id, id1);
            return Ok(slotId);
        }

    }
}
