using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Corona.Models.CommonMapping;
using Corona.Models.Content;

namespace Corona.Models.ViewModels.AppointmentViewMole
{
    public class AppointmentViewService : IMapFrom<RequestTest>
    {
        [Key]
        public string AppointmentId { get; set; }
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;
        [DataType(DataType.Time)]
        public TimeSpan StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan EndTime { get; set; }
        public bool isConfirmed { get; set; }
        //[Required]
        [MaxLength(250)]
        public string AppointmentDescription { get; set; }
        public string DoctorId { get; set; }
        public virtual ApplicationUser Doctor { get; set; }
        public string NurseId { get; set; }
        public virtual ApplicationUser Nurse { get; set; }
        public string PatientId { get; set; }
        public virtual ApplicationUser Patient { get; set; } 
    }
}

