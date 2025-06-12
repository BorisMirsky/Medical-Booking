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
            var app = await _appointmentService.CreateAppointment(request.BookingId);
            return Ok(app);
        }


        [HttpGet]
        public async Task<ActionResult<Appointment>> GetById(Guid id)
        {
            Appointment app = await _appointmentService.GetAppointment(id);
            return Ok(app);
        }


        [HttpPut]
        public async Task<ActionResult<Guid>> PatientUnacceptableBehavior([FromBody] AppointmentRequest request)
        {
            await _appointmentService.UpdateAppointment(request.Id, request.PatientCame, request.PatientIsLate,
                                                        request.PatientUnacceptableBehavior,
                                                        request.Treatment, request.MakingDiagnosis,
                                                        request.ReferralTests, request.VisualExaminationPatient,
                                                        request.FinalCost);
            return Ok(request.Id);
        }
    }
}
