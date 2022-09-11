using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Content
{
    public class PatientVitals
    {
        [Key]
        public string VitalsId { get; set; }
        public string TestResult { get; set; }
        public string Temperature { get; set; }
        public string BloodPressure { get; set; }
        public string OxygenLevel { get; set; }
        public string Barcode { get; set; }
        public string PatientId { get; set; }
        public string NurseId { get; set; }
        public string LabUserId { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Nurse { get; set; }
        public virtual ApplicationUser LabUser { get; set; }
    }
}
