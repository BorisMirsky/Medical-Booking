using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
//using System.IdentityModel.Tokens.Jwt;
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
    public class UsersController : ControllerBase
    {
        private readonly IUsersDoctorService _doctorService;
        private readonly IUsersPatientService _patientService;

        public UsersController(IUsersDoctorService doctorService)
        {
            _doctorService = doctorService;
            _patientService = patientService;
        }


        [Route("RegisterDoctor")]
        [HttpPost]   
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorRequest request)
        {
            if (String.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            UserDoctor registeredUserDoctor = await _doctorService.Register(request.Email,
                                                                request.Password,
                                                                request.UserName,
                                                                request.Role,
                                                                request.Speciality);

            if (registeredUserDoctor != null)
            {
                return Ok(registeredUserDoctor);
            }

            return BadRequest(new { message = "User Doctor registration unsuccessful" });
        }


        [Route("RegisterPatient")]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientRequest request)
        {
            if (String.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }
            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            UserPatient registeredUserPatient = await _doctorService.Register(request.Email,
                                                                request.Password,
                                                                request.UserName,
                                                                request.Role);

            if (registeredUserPatient != null)
            {
                return Ok(registeredUserPatient);
            }

            return BadRequest(new { message = "User Doctor registration unsuccessful" });
        }
    }


}



}
