using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.ExamViewModel
{
    public class DiagnosisViewModel
    {
        public string DiagnosisCode { get; set; }
        public string PatientId { get; set; }
        public string StaffId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Today;
        public string ExaminationNotes { get; set; }
        public string ReferalDescriptin { get; set; }
        public string Prescription { get; set; }
        public string DepartmentId { get; set; }
        public string PhysicalExamNotes { get; set; }
        public string AllergyId { get; set; }
        public string Type { get; set; }
        public string AllergyDiagnoseTestType { get; set; }
        public string AllergyTypeId { get; set; }
    }
}
