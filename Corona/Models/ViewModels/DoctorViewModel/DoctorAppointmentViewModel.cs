using Corona.Models.CommonMapping;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.DoctorViewModel
{
    public class DoctorAppointmentViewModel : IMapFrom<RequestTest>
    {
        public int AppointmentId { get; set; }

        public string Info { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public TimeSpan TimeStart { get; set; }

        public TimeSpan TimeEnd { get; set; }

        public ApplicationUser Patient { get; set; }
    }
}
