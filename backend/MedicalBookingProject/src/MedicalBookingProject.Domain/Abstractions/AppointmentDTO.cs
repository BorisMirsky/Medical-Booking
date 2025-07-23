using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalBookingProject.Domain.Abstractions
{
    public record AppointmentDTO
    (
        Guid Id,
        Guid DoctorId,
        Guid PatientId,
        Guid TimeslotId,
        Guid BookingId,
        string? PatientUserName,
        string? DoctorUserName,
        string? DoctorSpeciality,
        string? TimeslotDatetimeStart,
        string? TimeslotDatetimeStop
        //string? PatientCame,
        //string? PatientIsLate,
        //string? PatientUnacceptableBehavior
    );
}

