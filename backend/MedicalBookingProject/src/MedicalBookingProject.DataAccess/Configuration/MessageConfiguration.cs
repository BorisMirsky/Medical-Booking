using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalBookingProject.Domain.Models.Messages;
using Microsoft.EntityFrameworkCore;


namespace MedicalBookingProject.DataAccess.Configuration
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {

        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(m => m.FromRoleId)
                .IsRequired();
            builder.Property(m => m.FromId)
                .IsRequired();
            builder.Property(m => m.ToRoleId)
                .IsRequired();
            builder.Property(m => m.ToId)
                .IsRequired();
            builder.Property(m => m.IsRead)
                .IsRequired();
            builder.Property(m => m.Text)
                .IsRequired();
            builder.Property(m => m.SendedAt)
                .IsRequired();
        }
    }
}
