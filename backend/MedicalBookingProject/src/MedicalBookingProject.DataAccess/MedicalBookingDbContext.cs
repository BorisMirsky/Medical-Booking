using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalBookingProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using MedicalBookingProject.Domain.Models.Users;
using MedicalBookingProject.Domain.Models.Shedules;
using MedicalBookingProject.Domain.Models.Bookings;



namespace MedicalBookingProject.DataAccess
{
    public class MedicalBookingDbContext : DbContext
    {
        public MedicalBookingDbContext(DbContextOptions<MedicalBookingDbContext> options)
                : base(options)
        {
        }
        public DbSet<UserDoctorEntity> UsersDoctors { get; set; }
        public DbSet<UserPatientEntity> UsersPatients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<SheduleEntity> SheduleEntities { get; set; }
        public DbSet<Shedule> Shedules { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<BookingEntity> BookingEntities { get; set; }
        public DbSet<AppointmentEntity> AppointmentEntities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.LogTo(logStream.WriteLine);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}
