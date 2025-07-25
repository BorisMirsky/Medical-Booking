﻿namespace MedicalBookingProject.Domain.Abstractions
{
    public record BookingDTO
    (
        Guid Id,
        Guid DoctorId,
        Guid PatientId,
        Guid TimeslotId,
        Boolean IsBooked,
        Boolean IsClosed,
        DateTime CreatedAt,
        string? DoctorSpeciality,
        string? DoctorUserName,
        string? PatientUserName,
        string? TimeslotDatetimeStart,
        string? TimeslotDatetimeStop
    );
}
