using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Authentication.JwtBearer;
//  + LoginDoctor + RegisterPatient + LoginPatient + LoginAdmin (все POST)
// + возможность редактирования Doctor           (UPDATE)
// + возможность блокировки Doctor & Patient     (как это сделать? добавит флажок)



namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        [Route("Register")]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> Register([FromBody] RegisterDoctorRequest request)
        {
            if (String.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }
            Doctor registeredDoctor = await _doctorService.Register(request.Email,
                                                                request.Password,
                                                                request.UserName,
                                                                request.Role,
                                                                request.Speciality,
                                                                request.Gender);
            if (registeredDoctor != null)
            {
                return Ok(registeredDoctor);
            }
            return BadRequest(new { message = "User Doctor registration unsuccessful" });
        }



        [Route("GetDoctors")]
        [HttpGet] 
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<DoctorResponse>> GetDoctors()
        {
            List<Doctor> users = await _doctorService.GetAllDoctors();

            if (users != null)
            {
                return Ok(users);
            }

            return BadRequest(new { message = "___WTF___" });
        }



        [Route("GetDoctor")]
        [HttpGet("{id:int}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<DoctorResponse>> GetDoctor(Guid id)
        {
            Doctor user = await _doctorService.Get(id);

            if (user != null)
            {
                return Ok(user);
            }

            return BadRequest(new { message = "User Doctor is not recognized" });
        }



        [Route("GetDoctorsBySpeciality")]
        [HttpGet("{speciality}")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult<List<DoctorResponse>>> GetDoctorsBySpeciality(string speciality)
        {
            List<Doctor> doctors = await _doctorService.GetDoctorsBySpeciality(speciality);

            if (doctors != null)
            {
                return Ok(doctors);
            }

            return BadRequest(new { message = "User Doctor is not recognized" });
        }
    }
}

