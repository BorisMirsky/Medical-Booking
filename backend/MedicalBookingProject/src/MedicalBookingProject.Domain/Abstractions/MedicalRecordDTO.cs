using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalBookingProject.Domain.Abstractions
{
    public record MedicalRecordDTO
    (
        Guid Id,
        //Guid AppointmentId,
        //Guid BookingId,
        //Guid DoctorId,
        Guid PatientId,
        //Guid TimeslotId,
        //Boolean IsBooked,
        //Boolean IsClosed,
        //DateTime CreatedAt,
        string? DoctorSpeciality,
        string? DoctorUserName,
        string? PatientUserName,
        string? TimeslotDatetimeStart,
        string? TimeslotDatetimeStop,
        string? PatientCame,
        string? PatientIsLate,
        string? PatientUnacceptableBehavior,
        string? Symptoms,
        string? Diagnosis,
        string? PrescribedTreatment,
        string? VisualExamination,
        string? ReferralTests,
        uint? FinalCost
        );
}

