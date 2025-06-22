using MedicalBookingProject.Domain.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalBookingProject.Domain.Abstractions
{
    public interface IMessageRepo
    {

        Task<Message> Send(Int16 FromRoleId, Guid FromId, Int16 ToRoleId,
                                  Guid ToId, Boolean IsRead, string Text);
        Task<List<Message>> ReadReceived(Int16 ToRoleId, Guid ToId);
        Task<List<Message>> ReadSended(Int16 FromRoleId, Guid FromId);

    }
}
