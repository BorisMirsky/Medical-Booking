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
        public Int16 FromRoleId { get; set; }
        public Guid FromId { get; set; }
        public Int16 ToRoleId { get; set; }
        public Guid ToId { get; set; }
        public String Text { get; set; } = String.Empty;
        public DateTime SendedAt { get; set; }
        public MessageType? messageType { get; set; } = MessageType.NotSelected;
        public Boolean IsRead { get; set; } = false;
        //public required MessageStatus messageStatus { get; set; } = MessageStatus.NotRead;
    }
}
