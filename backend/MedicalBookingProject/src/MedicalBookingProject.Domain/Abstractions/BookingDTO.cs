namespace MedicalBookingProject.Domain.Abstractions
{
    public record BookingDTO
    (
        Guid Id,
        Guid DoctorId,
        Guid PatientId,
        Guid TimeslotId,
        string DoctorSpeciality,
        string DoctorUserName
        //string TimeslotDatetimeStart,
        //string TimeslotDatetimeStop
    );
}
