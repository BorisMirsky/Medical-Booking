namespace MedicalBookingProject.Web.Contracts
{
    public record RegisterAdminRequest
    {
        public required string Email { get; set; } // = String.Empty;
        public required string Password { get; set; }  // = String.Empty;
        //public string UserName { get; set; } = String.Empty;
        //public string Role { get; set; } = String.Empty;
    }
}
