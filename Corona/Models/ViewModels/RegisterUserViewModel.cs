using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        [Display(Name = "Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Surname")]
        public string LastName { get; set; }

        public DateTime Dob { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        public string DepartmentId { get; set; }
        public string ClinicId { get; set; }
        public string HospitalId { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }
        public string AppointmentId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your appointment description")]
        public string AppointmentDescription { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose date of your appointment")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please choose start time of your appointment")]
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select clinic name")]
        [Display(Name = "Clinic")]
        public string DoctorId { get; set; }
        public string NurseId { get; set; }


        public IEnumerable<SelectListItem> Clinics { get; set; }

        public IEnumerable<SelectListItem> Doctors { get; set; }

        public IEnumerable<SelectListItem> Nurses { get; set; }
    }
}
