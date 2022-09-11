using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models
{
    public class Patient_Medication
    {
        [Key]
        public string Patient_MedsId { get; set; }
        public string PatientId { get; set; }
        public string PharmacistId { get; set; }
        public bool MedsReceived { get; set; }
        public DateTime Date { get; set; }

        public ApplicationUser Pharmacist { get; set; }
        public ApplicationUser Patient { get; set; } 
        [NotMapped]
        public IEnumerable<SelectListItem> Patients { get; set; }
    }
}
