using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;



namespace MedicalBookingProject.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepo _bookingRepo;
        public BookingService(IBookingRepo bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        // Внесение в таблицу букинг - бронирование либо отмена.
        public async Task<Guid> CreateBooking(Guid slotid, Guid patientid, Guid doctorid,
                                              Boolean isbooked, 
                                              Guid? cancelledby, DateTime? cancelledat)
        {
            if (isbooked == false)
            {
                cancelledby = patientid;
                cancelledat = DateTime.Now;
            }
            return await _bookingRepo.Create(slotid, patientid, doctorid, isbooked,
                                             cancelledby, cancelledat);
        }

        // patch booking
        //public async Task<Guid> CreateBooking(Guid slotId, 
        //                                      Guid? cancelledBy, 
        //                                      DateTime? bookingOrCancelDatetime,
        //                                      Guid patientId, Boolean? isBooked) // Guid doctorId,

        //{

        //    Guid _patientid = (isBooked == true) ? patientId : Guid.Empty;
        //    Guid? _cancelledby = (isBooked == true) ? Guid.Empty : cancelledBy;
        //    //DateTime? _cancelledat = (isbooked == true) ? null : DateTime.Now;
        //    DateTime? _cancelledat = DateTime.Now;

        //    return await _bookingRepo.Create(slotId, _cancelledby, _cancelledat);
        //    //_patientid, doctorId, isBooked,                                           
        //}

        public async Task<Booking> GetOneBooking(Guid id)
        {
            return await _bookingRepo.GetOneBooking(id);
        }
    }
}
