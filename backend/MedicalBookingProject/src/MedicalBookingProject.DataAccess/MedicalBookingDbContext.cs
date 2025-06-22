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

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Message> Messages { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}
           
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Configuration.DoctorConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.PatientConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.RoleConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.TimeslotConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.BookingConfiguration());
            modelBuilder.ApplyConfiguration(new Configuration.MessageConfiguration());
            //modelBuilder.ApplyConfiguration(new Configuration.MedicalrecordConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
