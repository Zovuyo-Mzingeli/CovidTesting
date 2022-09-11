using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels
{
    public class EditPatientPrescriptionViewModel
    {
        public string Patient_PrescriptionId { get; set; }
        public string MedsReceived { get; set; }
        public string[] Confirm { get; set; }
        public string[] Decline { get; set; }
    }
}
