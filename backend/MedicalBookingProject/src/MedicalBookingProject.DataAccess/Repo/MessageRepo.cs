using MedicalBookingProject.Domain.Abstractions;
using MedicalBookingProject.Domain.Models.Messages;
using MedicalBookingProject.DataAccess.Configuration;
using MedicalBookingProject.Domain.Models.Shedules;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using MedicalBookingProject.Domain.Models.Users;



namespace MedicalBookingProject.DataAccess.Repo
{
    public class MessageRepo : IMessageRepo
    {

        private readonly MedicalBookingDbContext _context;

        public MessageRepo(MedicalBookingDbContext context)
        {
            _context = context;
        }

        public async Task<Message> Send(Int16 FromRoleId, Guid FromId, Int16 ToRoleId,
                                  Guid ToId, Boolean IsRead, string Text)
        {
            var entity = new Message();
            entity.Id = Guid.NewGuid();
            entity.FromRoleId = FromRoleId;
            entity.FromId = FromId;
            entity.ToRoleId = ToRoleId;
            entity.ToId = ToId;
            entity.IsRead = IsRead;
            entity.Text = Text;
            await _context.Messages.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }



        public async Task<List<Message>> ReadReceived(Int16 ToRoleId, Guid ToId)
        {
            List<Message> entities = await _context.Messages
                                            .Where(m => m.ToId == ToId)
                                            .ToListAsync();
            return entities!;
        }


        public async Task<List<Message>> ReadSended(Int16 FromRoleId, Guid FromId)
        {
            List<Message> entities = await _context.Messages
                                            .Where(m => m.FromId == FromId)
                                            .ToListAsync();
            return entities!;
        }

    }
}
