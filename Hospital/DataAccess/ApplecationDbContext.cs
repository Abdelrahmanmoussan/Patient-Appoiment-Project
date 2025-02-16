using ContactDoctor.Models;
using Hospital.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital.DataAccess
{
    public class ApplecationDbContext : DbContext
    {

        public DbSet<Doctor> Doctors {  get; set;}
        public DbSet<PatientAppointment> PatientAppointments { get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=MOUSSAN\\MSSQLSERVERS;Initial Catalog=Hospital;Integrated Security=True;TrustServerCertificate=True");
        }
                protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
                new Doctor { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor2.jpg" },
                new Doctor { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor4.jpg" },
                new Doctor { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor3.jpg" },
                new Doctor { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor5.jpg" }
            );
            

            modelBuilder.Entity<PatientAppointment>()
                .HasOne(p => p.Doctor)
                .WithMany(a => a.Appointments)
                .HasForeignKey(p => p.DoctorId);

            base.OnModelCreating(modelBuilder);

        }
    
    }
}
