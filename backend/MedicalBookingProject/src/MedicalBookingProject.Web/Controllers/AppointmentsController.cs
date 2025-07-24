using MedicalBookingProject.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Services;
using MedicalBookingProject.Domain.Models.Shedules;




namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AppointmentsController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [Route("CreateAppointment")]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<ActionResult> CreateAppointment([FromBody] AppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.BookingId, request.DoctorId,
                                                  request.PatientId, request.TimeslotId, request.PatientCame,
                                                  request.PatientIsLate, request.PatientUnacceptableBehavior);
            return Ok();
        }


        [Route("GetByPatient")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, doctor, patient")]
        public async Task<ActionResult<List<AppointmentDTO>>> GetByPatient([FromQuery] Guid id)
        {
            List<AppointmentDTO> apps = await _appointmentService.GetByPatient(id);

            if (apps != null)
            {
                return Ok(apps);
            }

            return BadRequest(new { message = "there'are not such patient" });
        }



        [Route("GetByDoctor")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin, doctor")]
        public async Task<ActionResult<List<AppointmentDTO>>> GetByDoctor([FromQuery] Guid id)
        {
            List<AppointmentDTO> apps = await _appointmentService.GetByDoctor(id);

            if (apps != null)
            {
                return Ok(apps);
            }

            return BadRequest(new { message = "there'are not such doctor" });
        }
    }
}
