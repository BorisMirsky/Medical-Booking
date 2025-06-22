using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Messages;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity.Data;
using MedicalBookingProject.Application.Services;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }


        [Route("SendMessage")]
        [HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<IActionResult> SendMessage([FromBody] MessageRequest request)
        {
            Message message = await _messageService.SendMessage(request.FromRoleId,
                                                                request.FromId, request.ToRoleId, 
                                                                request.ToId, request.IsRead, 
                                                                request.Text);
             
            return Ok(message);
        }


        [Route("ReadReceivedMessages")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult> ReadReceivedMessages([FromBody] MessageRequest request)
        {
            List<Message> messages = await _messageService.ReadReceivedMessages(request.ToRoleId, request.ToId);

            if (messages != null)
            {
                return Ok(messages);
            }
            return Ok("This user hasn't any received messages");
            //return BadRequest(new { message = "___WTF___" });
        }


        [Route("ReadSendedMessages")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "admin")]
        public async Task<ActionResult> ReadSendedMessages([FromBody] MessageRequest request)
        {
            List<Message> messages = await _messageService.ReadSendedMessages(request.FromRoleId, request.FromId);

            if (messages != null)
            {
                return Ok(messages);
            }
            return Ok("This user hasn't any sended messages");
            //return BadRequest(new { message = "___WTF___" });
        }
    }
}
