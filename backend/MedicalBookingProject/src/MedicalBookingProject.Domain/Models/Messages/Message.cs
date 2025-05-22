using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Models.Messages
{
    public class Message
    {
        public Guid Id { get; set; }
        public required string Text { get; set; }
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public DateTime SendedAt { get; set; }
        public required MessageType messageType { get; set; } = MessageType.NotSelected;
        public required MessageStatus messageStatus { get; set; } = MessageStatus.NotRead;
    }
}
