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
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }



        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<ActionResult<AppointmentResponse>> CreateAppointment([FromBody] AppointmentRequest request)
        {
            Appointment app = new Appointment(request.DoctorId, request.PatientId, 
                                              request.SlotId, request.MedicalCardId, 
                                              request.PatientCame, request.PatientIsLate,
                                              request.FinalCost);
            //Shedule shed = new( request.StartDay, request.Days);  //request.DoctorId,
            var newApp = await _appointmentService.CreateAppointment(app);
            return Ok(newApp);
        }



        [HttpGet]
        public async Task<ActionResult<Appointment>> GetById(Guid id)
        {
            Appointment app = await _appointmentService.GetAppointment(id);
            return Ok(app);
        }


        [HttpPatch]
        public async Task<ActionResult<Guid>> PatientUnacceptableBehavior(Guid id, string description)
        {
            await _appointmentService.UpdateUnacceptableBehavior(id, description);
            return Ok(id);
        }


    }
}
