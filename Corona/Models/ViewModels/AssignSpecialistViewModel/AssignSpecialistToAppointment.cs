using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Corona.Models.CommonMapping;
using Corona.Models.Content;

namespace Corona.Models.ViewModels.AssignSpecialistViewModel
{
    public class AssignSpecialistToAppointment 
    {
        //public Appointment Appointment { get; set; }
        public string AppointmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please assign a nurse to appointment")]

        public string AppointmentDescription { get; set; }
        public DateTime AppointmentDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string HospitalId { get; set; }
        public string ClinicId { get; set; }
        public string DoctorId { get; set; }
        public string NurseId { get; set; }
        public string PatientName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please check the box to confirm appointment")]
        public bool IsConfirmed { get; set; }

        public string Email { get; set; }

        public ApplicationUser Patient { get; set; }
        public ApplicationUser Nurse { get; set; } 

        public IEnumerable<SelectListItem> Nurses { get; set; }
    }
}
