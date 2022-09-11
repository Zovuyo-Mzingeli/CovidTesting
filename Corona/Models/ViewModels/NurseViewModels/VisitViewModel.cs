using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Devop.Models.ViewModel.NurseViewModels
{
    public class VisitViewModel
    {
        public string NurseVisitId { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string OxygenLevel { get; set; }
        public string TestBarCode { get; set; }
        public string PatientName { get; set; }
        public string LabName { get; set; }
        public string TestResults { get; set; }
    }
}
