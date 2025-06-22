namespace MedicalBookingProject.Web.Contracts
{
    public record MessageRequest
    {
        //public Guid Id { get; set; }
        public Int16 FromRoleId { get; set; }
        public Guid FromId { get; set; }
        public Int16 ToRoleId { get; set; }
        public Guid ToId { get; set; }
        public Boolean IsRead { get; set; } = false;
        public String Text { get; set; } = String.Empty;
        
        //public String Title { get; set; } = String.Empty;
        // public String MessageType { get; set; } = String.Empty;    

    }
}
