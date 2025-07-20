using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Users;
using System.Runtime.CompilerServices;



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
                                              Boolean isbooked) 
        {
            return await _bookingRepo.Create(slotid, patientid, doctorid, isbooked);
        }

        public async Task<List<BookingDTO>> GetByPatient(Guid patientId)
        {
            return await _bookingRepo.GetByPatient(patientId);
        }


        public async Task<List<BookingDTO>> GetByDoctor(Guid id)
        {
            return await _bookingRepo.GetByDoctor(id);
        }

        public async Task<Guid> SetBookingClosed(Guid id)
        {
            return await _bookingRepo.SetBookingClosed(id);
        }
    }
}
