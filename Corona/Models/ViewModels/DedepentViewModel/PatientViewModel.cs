using Corona.Models.CommonMapping;
using Corona.Models.Content;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModel.DedepentViewModel
{
    public class PatientViewModel : IMapFrom<Dependent>
    {

        [PersonalData]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Dob { get; set; }
        [MaxLength(50)]
        [PersonalData]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        [Required]
        [MaxLength(13)]
        [PersonalData]
        public string Idnumber { get; set; }
        [Required]
        [PersonalData]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string LastName { get; set; }
        [PersonalData]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone number")]

        public string PhoneNumber { get; set; }

        [PersonalData]
        
        public string Gender { get; set; }
        [PersonalData]
        [MaxLength(250)]
       
        public string AddressLine1 { get; set; }
        [PersonalData]
        [MaxLength(250)]
        public string AddressLine2 { get; set; }
        [PersonalData]
        [MaxLength(50)]
       
        public string CityId { get; set; }
        public string DependentId { get; set; }
        [PersonalData]
        [MaxLength(50)]
      
        public string SuburbId { get; set; }
        [PersonalData]
       
        public string PostalCode { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string MedicalAidNumber { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string MedicalAidId { get; set; }

        [PersonalData]
        [MaxLength(50)]
        public string MedicalPlanId { get; set; }

       // public IEnumerable<SelectListItem> Nurses { get; set; }

    }
}
