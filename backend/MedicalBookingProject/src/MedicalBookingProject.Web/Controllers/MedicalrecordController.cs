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
    [Route("api/[controller]")]
    [ApiController]
    public class MedicalrecordController : ControllerBase
    {

        private readonly IMedicalrecordService _medicalrecordService;

        public MedicalrecordController(IMedicalrecordService medicalrecordService)
        {
            _medicalrecordService = medicalrecordService;
        }


        [HttpPost]   //Task<ActionResult<MedicalRecordResponse>> 
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "doctor")]
        public async void CreateMedicalrecord([FromBody] MedicalRecordRequest request)
        {
            await _medicalrecordService.CreateMedicalRecord(request.Symptoms,
                                                            request.Diagnosis,
                                                            request.PrescribedTreatment);
        }


        [HttpGet]
        public async Task<ActionResult<MedicalRecord>> GetById(Guid id)
        {
            MedicalRecord medRec = await _medicalrecordService.GetMedicalRecord(id);
            return Ok(medRec);
        }


        [HttpPut]
        public async Task<ActionResult<Guid>> PatientUnacceptableBehavior([FromBody] MedicalRecordRequest request)
        {
            await _medicalrecordService.UpdateMedicalRecord(request.Id, request.Symptoms,
                                                            request.Diagnosis, request.PrescribedTreatment);
            return Ok(request.Id);
        }
    }
}
