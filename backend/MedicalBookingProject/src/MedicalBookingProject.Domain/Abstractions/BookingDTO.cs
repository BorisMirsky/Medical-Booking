namespace MedicalBookingProject.Domain.Abstractions
{
    public record BookingDTO
    (
        Guid Id,
        Guid DoctorId,
        Guid PatientId,
        Guid TimeslotId,
        Boolean IsBooked,
        DateTime CreatedAt,
        string? DoctorSpeciality,
        string? DoctorUserName,
        string? TimeslotDatetimeStart,
        string? TimeslotDatetimeStop
    );
}
