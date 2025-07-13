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


        [HttpPost] 
        [Route("CreateMedicalRecord")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async void CreateMedicalRecord([FromBody] MedicalRecordRequest request)
        {
            await _medicalRecordService.CreateMedicalRecord(request.PatientId, 
                                                            request.TimeslotId, 
                                                            request.DoctorId, 
                                                            request.AppointmentId, 
                                                            request.Diagnosis, 
                                                            request.Symptoms,
                                                            request.PrescribedTreatment,
                                                            request.ReferralTests,
                                                            request.VisualExamination,
                                                            request.FinalCost
                                                            );
        }


        [HttpGet]
        public async Task<ActionResult<MedicalRecord>> GetById(Guid id)
        {
            MedicalRecord medRec = await _medicalRecordService.GetMedicalRecord(id);
            return Ok(medRec);
        }


        [HttpPut]
        public async Task<ActionResult<Guid>> UpdateMedicalRecord([FromBody] MedicalRecordRequest request)
        {
            await _medicalRecordService.UpdateMedicalRecord(request.Id, request.Symptoms,
                                                            request.Diagnosis, request.PrescribedTreatment);
            return Ok(request.Id);
        }
    }
}
