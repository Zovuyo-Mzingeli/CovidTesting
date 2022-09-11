using Corona.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Devop.Models.ViewModel.NurseViewModels
{
    public class AssignLabUserToPerformResults
    {
        [Key]
        public string NurseVisitId { get; set; }


        public string Temperature { get; set; }
 
        public string BloodPressure { get; set; }
      
        public string OxygenLevel { get; set; }
 
        public string TestBarCode { get; set; }
        public string PatientName { get; set; }
        [Required]
        public string LabName { get; set; }
        [Required]
        public string TestResults { get; set; }
        public bool ConfirmedResut { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Lab { get; set; }
        public IEnumerable<SelectListItem> Labs { get; set; }



    }
}
