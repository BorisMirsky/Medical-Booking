using MedicalBookingProject.Domain.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MedicalBookingProject.Domain.Models.MedicalRecords; 
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Services;
using MedicalBookingProject.Domain.Models.Shedules;
using System.Diagnostics;



namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicalRecordsController : ControllerBase
    {

        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordsController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }


        [Route("CreateMedicalRecord")]
        [HttpPost] 
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async Task<ActionResult> CreateMedicalRecord([FromBody] MedicalRecordRequest request)
        {
            await _medicalRecordService.CreateMedicalRecord(request.BookingId,
                                                            request.DoctorId,
                                                            request.PatientId,
                                                            request.TimeslotId,
                                                            request.AppointmentId,
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
        public async Task<ActionResult<List<MedicalRecordDTO>>> GetByPatientId(Guid id)
        {
            List<MedicalRecordDTO> medRecs = await _medicalRecordService.GetByPatient(id);
            Debug.WriteLine("");
            Debug.WriteLine("");
            Debug.WriteLine(medRecs);
            Debug.WriteLine("");
            Debug.WriteLine("");
            return Ok(medRecs);
        }


    }
}
