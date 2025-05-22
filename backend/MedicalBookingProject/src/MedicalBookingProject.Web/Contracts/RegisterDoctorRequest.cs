namespace MedicalBookingProject.Web.Contracts
{
    public record RegisterDoctorRequest
    {
        //public Guid Id { get; set; } = Guid.Empty;  //    NewGuid();
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Role { get; set; } = "";
        public int? RoleId { get; set; }
        public string? Token { get; set; } = "";
        public bool? IsActive { get; set; } = false;
        public string Speciality { get; set; } = "";
        public string? Gender { get; set; } = "";
        public int? Price { get; set; }
        public int? Salary { get; set; }
    }
}
