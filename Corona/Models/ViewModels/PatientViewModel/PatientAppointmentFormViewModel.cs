using Corona.Models.CommonMapping;
using Corona.Models.Content;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.PatientViewModel
{
    public class PatientAppointmentFormViewModel : IMapFrom<RequestTest>
    {
        public string RequestTestId { get; set; }
        [DataType(DataType.Date)]
        public DateTime RequestedDate { get; set; } = DateTime.Today;
        public string Status { get; set; } = "New";
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string SuburbId { get; set; }
        public string DependentId { get; set; }
        public string NurseId { get; set; }

        public IEnumerable<SelectListItem> Nurses { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
        public Dependent dependents { get; set; }
    }
}
