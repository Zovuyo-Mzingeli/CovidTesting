using Corona.Extensions;
using Corona.Models.Content;
using Corona.Models.ViewModels.AppointmentViewMole;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.DoctorViewModel
{
    public class DoctorScheduleViewModel
    {
        public string RequestId { get; set; }
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public string NurseId { get; set; }
        public string RequestorId { get; set; }
        public string DependentId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string SuburbId { get; set; }
        public string Status { get; set; } = "New";
        [MyBirthDateValidation(ErrorMessage = "You cannot schedule a request for previous date!")]
        public DateTime BookingDate { get; set; }
        public string TimeSlot { get; set; }
        public string Email { get; set; }


    }
}
