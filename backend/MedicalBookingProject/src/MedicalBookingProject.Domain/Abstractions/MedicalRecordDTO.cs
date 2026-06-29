
namespace MedicalBookingProject.Domain.Abstractions
{
    public record MedicalRecordDTO
    (
        Guid Id,
        Guid PatientId,
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

