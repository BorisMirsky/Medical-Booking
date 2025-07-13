using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Bookings;
using MedicalBookingProject.Domain.Models.Appointments;
using MedicalBookingProject.Domain.Models.MedicalRecords;
using MedicalBookingProject.Domain.Models.Messages;



namespace MedicalBookingProject.DataAccess
{
    public class MedicalBookingDbContext : DbContext
    {

        public MedicalBookingDbContext(DbContextOptions<MedicalBookingDbContext> options)
                : base(options)
        {
        }

        public DbSet<Doctor> Doctors { get; set; } = null!;
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Timeslot> Timeslots { get; set; } = null!;
        public DbSet<Booking> Bookings { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<MedicalRecord> MedicalRecords { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}
           
        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.PatientConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.TimeslotConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.BookingConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.MessageConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.MedicalRecordConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
