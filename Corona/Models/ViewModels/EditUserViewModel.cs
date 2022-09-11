using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Corona.Enums;
using Corona.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Corona.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string Id { get; set; }
        [PersonalData]
        [DataType(DataType.Date)]
        [Required]
        public DateTime Dob { get; set; }
        [MaxLength(50)]
        [PersonalData]

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your email address")]
        public string Email { get; set; }
        

        [MinLength(13, ErrorMessage = "SA ID number is not less than 13 numbers")]
        
        [PersonalData]
        public string Idnumber { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your First Name")]

        [PersonalData]
        [MaxLength(50)]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }
        [PersonalData]
        [MaxLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Last Name")]

        public string LastName { get; set; }
        [PersonalData]
        [MinLength(10, ErrorMessage = "Please must not be less 10")]
        [DataType(DataType.PhoneNumber)]
        [Range(0, 9999999999, ErrorMessage = "Phone does not contain letters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your phone number")]

        public string PhoneNumber { get; set; }

        [PersonalData]
        [MaxLength(250)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Address Line 1")]

        public string AddressLine1 { get; set; }
        [PersonalData]
        [MaxLength(250)]

        public string AddressLine2 { get; set; }
        [PersonalData]
        [MaxLength(50)]
       
        public string CityId { get; set; }

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
        public string PlanId { get; set; }

    }
}
