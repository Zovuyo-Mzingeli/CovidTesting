using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.PatientViewModel
{
    public class PatientAppointmentsListViewModel
    {
        public string AppointmentId { get; set; }
        public string AppointmentDescription { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}" )]
        public DateTime AppointmentDate { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
        public bool IsConfirmed { get; set; }
        public string DoctorName { get; set; }
        public string NurseName { get; set; }
        public string ClinicName { get; set; }
        public string HospitalName { get; set; }
        public string PatientName { get; set; }
    }
}
