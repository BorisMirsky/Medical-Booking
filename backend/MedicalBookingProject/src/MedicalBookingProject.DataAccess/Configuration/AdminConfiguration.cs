using MedicalBookingProject.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace MedicalBookingProject.DataAccess.Configuration
{
    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Email)
                .IsRequired();
            builder.Property(d => d.Password)
                .IsRequired();
            builder.Property(d => d.UserName)
                .IsRequired();
            builder.Property(d => d.Token);
        }
    }
}
