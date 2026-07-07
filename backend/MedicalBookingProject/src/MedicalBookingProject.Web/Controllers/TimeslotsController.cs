
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;



namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TimeslotsController : ControllerBase
    {

        private readonly ITimeslotService _timeslotService;

        public TimeslotsController(ITimeslotService timeslotService) 
        {
            _timeslotService = timeslotService;
        }


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
        public async Task<ActionResult> UpdateTimeslot([FromBody] TimeslotUpdateRequest request)
        {
            await _timeslotService.UpdateTimeslot(request.SlotId, request.PatientId, request.IsBooked);
            return Ok("Slot updated");
        }
    }
}
