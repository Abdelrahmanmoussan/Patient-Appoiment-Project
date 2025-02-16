using ContactDoctor.Models;
using Hospital.DataAccess;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Controllers
{
    public class DoctorsController : Controller
    {
        ApplecationDbContext dbContext = new ApplecationDbContext();
        public IActionResult BookAppointment()
        {
            var doctors = dbContext.Doctors;
            return View(doctors.ToList());
        }


        public IActionResult CompleteAppointment(string doctorName)
        {
            var doctor = dbContext.Doctors.FirstOrDefault(d => d.Name == doctorName);

            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }


        [HttpGet]
        public IActionResult Index()
        { 
            var appointments = dbContext.PatientAppointments;
            return View(appointments.ToList());
        }

        [HttpPost]
        public IActionResult Index(PatientAppointment patientAppointment)
        {
            dbContext.PatientAppointments.Add(new PatientAppointment
            {
                PatientName = patientAppointment.PatientName,
                AppointmentDate = patientAppointment.AppointmentDate,
                AppointmentTime = patientAppointment.AppointmentTime,
                DoctorId = patientAppointment.DoctorId,
                DoctorName = patientAppointment.DoctorName
            });
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
