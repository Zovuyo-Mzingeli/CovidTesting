using Corona.Models.CommonMapping;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.DoctorViewModel
{
    public class DoctorViewModel : IMapFrom<ApplicationUser>
    {
        public string tId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Info { get; set; }
        public List<RequestTest> PatientAppointments { get; set; } = new List<RequestTest>();
    }
}
