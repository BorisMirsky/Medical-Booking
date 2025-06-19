using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Web.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Application.Services;



namespace MedicalBookingProject.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeslotsController : ControllerBase
    {

        private readonly ITimeslotService _timeslotService;

        private readonly IBookingService _bookingService;

        public TimeslotsController(ITimeslotService timeslotService, IBookingService bookingService)
        {
            _timeslotService = timeslotService;
            _bookingService = bookingService;
        }


        [Route("CreateTimeslot")]
        [HttpPost]  
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "manager")]
        public async Task<ActionResult> CreateTimeslot([FromBody] TimeslotRequest request)
        {
            await _timeslotService.CreateTimeslot(request.DoctorId, request.StartDay, 
                                                  request.Days, request.TimeStart, 
                                                  request.TimeStop, request.TimeChunk);
            return Ok("ok");
        }


        //// По id слота
        //[Route("GetById")]
        //[HttpGet]  //("{slotId:int}")]
        //public async Task<ActionResult<Timeslot>> GetById(Guid slotId)
        //{
        //    Timeslot timeslot = await _timeslotService.GetTimeslot(slotId);
        //    return Ok(timeslot);
        //}



        // По id доктора
        [Route("ByDoctorId")]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Timeslot>>> ByDoctorId(Guid id)
        {
            var timeslots = await _timeslotService.GetTimeslotsByDoctor(id);
            return Ok(timeslots);
        }



        // Доктор + день
        //[Route("ByDayAndDoctorId")]
        //[HttpGet]
        //public async Task<ActionResult<List<Timeslot>>> ByDayAndDoctorId(Guid id, DateTime day)
        //{
        //    var timeslots = await _timeslotService.GetTimeslot(id);
        //    return Ok(timeslots);
        //}


        [HttpPatch]
        public async Task<ActionResult<Guid>> UpdateBooking([FromBody] BookingRequest request)
        {
            // Изменение в таблице Слотс
            var slotId = await _timeslotService.UpdateTimeslot(request.SlotId, request.PatientId, request.IsBooked);
            // Изменение (добавление) в таблице Букингс
            // будет убрано в отдельный контроллер
            await _bookingService.CreateBooking(request.SlotId, request.CancelledBy,
                                                request.BookingOrCancelDatetime,
                                                request.PatientId, request.IsBooked);
            return Ok(slotId);
        }

    }
}
