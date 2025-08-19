using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Services;
using System.Diagnostics;





namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TimeslotsController : ControllerBase
    {

        private readonly ITimeslotService _timeslotService;

        private readonly IBookingService _bookingService;

        public TimeslotsController(ITimeslotService timeslotService, IBookingService bookingService)
        {
            _timeslotService = timeslotService;
            _bookingService = bookingService;
        }


        // CreateShedule
        [Route("CreateTimeslot")]
        [HttpPost]  
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, Admin")]
        public async Task<ActionResult> CreateTimeslot([FromBody] TimeslotCreateRequest request)
        {
            await _timeslotService.CreateTimeslot(request.DoctorId, 
                                                  request.StartDay, 
                                                  request.Days, request.TimeStart, 
                                                  request.TimeStop, request.TimeChunk);
            return Ok("ok");
        }



        [Route("ByDoctorId")]
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, Admin, doctor, patient")]
        public async Task<ActionResult<List<Timeslot>>> ByDoctorId(Guid id)
        {
            var timeslots = await _timeslotService.GetTimeslotsByDoctor(id);
            return Ok(timeslots);
        }


        [Route("UpdateTimeslot")]       
        [HttpPatch]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "patient")]
        public async Task<ActionResult<Guid>> UpdateTimeslot([FromBody] TimeslotUpdateRequest request)
        {
            var slotId = await _timeslotService.UpdateTimeslot(request.SlotId, request.PatientId, request.IsBooked);
            return Ok(slotId);
        }
    }
}
