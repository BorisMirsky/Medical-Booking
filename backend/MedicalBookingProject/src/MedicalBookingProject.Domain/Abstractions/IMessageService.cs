using MedicalBookingProject.Domain.Models.Messages;


namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMessageService
    {
        Task<Message> SendMessage(Int16 FromRoleId, Guid FromId, Int16 ToRoleId,
                                  Guid ToId, Boolean IsRead, string Text);
        Task<List<Message>> ReadReceivedMessages(Int16 ToRoleId, Guid ToId);
        Task<List<Message>> ReadSendedMessages(Int16 FromRoleId, Guid FromId);
    }
}
