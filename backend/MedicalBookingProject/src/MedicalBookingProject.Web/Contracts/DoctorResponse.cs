namespace MedicalBookingProject.Web.Contracts
{
    public record DoctorResponse
    (
        Guid Id,
        string CityFrom,
        string Email,
        string Password,
        string Rolename,
        string Speciality,
        string UserName,
        string Gender,
        int? Price,
        int? Salary
    );
}
