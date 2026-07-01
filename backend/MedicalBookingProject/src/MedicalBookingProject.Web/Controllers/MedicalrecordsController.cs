using MedicalBookingProject.Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;


namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MedicalRecordsController : ControllerBase
    {

        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }


        [Route("CreateMedicalRecord")]
        [HttpPost] 
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<ActionResult> CreateMedicalRecord([FromBody] MedicalRecordRequest request)
        {
            await _medicalRecordService.CreateMedicalRecord(request.BookingId,
                                                            request.DoctorId,
                                                            request.PatientId,
                                                            request.TimeslotId,
                                                            //request.AppointmentId,
                                                            request.Diagnosis,
                                                            request.Symptoms,
                                                            request.PrescribedTreatment,
                                                            request.ReferralTests,
                                                            request.VisualExamination,
                                                            request.FinalCost
                                                            );

            return Ok();
        }


        [Route("GetByPatientId")]
        [HttpGet("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<ActionResult<List<MedicalRecordDTO>>> GetByPatientId(Guid id)
        {
            List<MedicalRecordDTO> medRecs = await _medicalRecordService.GetByPatient(id);
            return Ok(medRecs);
        }

    }
}
