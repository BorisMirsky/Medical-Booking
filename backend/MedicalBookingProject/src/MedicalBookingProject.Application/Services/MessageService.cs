using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MedicalBookingProject.Domain.Models.Messages;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.DataAccess.Repo;
using System.Data;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;



namespace MedicalBookingProject.Application.Services
{
    public class MessageService : IMessageService
    {

        private readonly IMessageRepo _messageRepo;

        public MessageService(IMessageRepo messageRepo)
        {
            _messageRepo = messageRepo;
        }

        public async Task<Message> SendMessage(Int16 FromRoleId, Guid FromId, Int16 ToRoleId,
                                  Guid ToId, Boolean IsRead, string Text)
        {
            return await _messageRepo.Send(FromRoleId, FromId, ToRoleId,
                                            ToId, IsRead, Text);
        }

        public async Task<List<Message>> ReadReceivedMessages(Int16 ToRoleId, Guid ToId)
        {
            return await _messageRepo.ReadReceived(ToRoleId, ToId);
        }

        public async Task<List<Message>> ReadSendedMessages(Int16 FromRoleId, Guid FromId)
        {
            return await _messageRepo.ReadReceived(FromRoleId, FromId);
        }
    }
}
