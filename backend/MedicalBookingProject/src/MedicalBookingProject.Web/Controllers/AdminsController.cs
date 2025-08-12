using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;



namespace MedicalBookingProject.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AdminsController : ControllerBase
    {

        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }


        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterAdminRequest request)
        {

            if (String.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "User email needs to entered" });
            }

            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            Admin? registeredAdmin = await _adminService.Register(request.Email,
                                                                request.Password);
            if (registeredAdmin != null)
            {
                return Ok(registeredAdmin);
            }

            return BadRequest(new { message = "User Admin registration unsuccessful" });
        }



        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {

            if (String.IsNullOrEmpty(request.Email))
            {
                return BadRequest(new { message = "Email address needs to entered" });
            }

            else if (String.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { message = "Password needs to entered" });
            }

            Admin? loggedInUser = await _adminService.LoginAccount(request.Email, request.Password);

            if (loggedInUser != null)
            {
                return Ok(loggedInUser);
            }

            return BadRequest(new { message = "User login unsuccessful" });
        }
    }
}
