namespace MedicalBookingProject.Web.Contracts
{
    public record RegisterDoctorRequest
    {
        public string Email { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public string UserName { get; set; } = String.Empty;
        public string Role { get; set; } = String.Empty;
        public string Speciality { get; set; } = String.Empty;
        public string Gender { get; set; } = String.Empty;
    }
}
