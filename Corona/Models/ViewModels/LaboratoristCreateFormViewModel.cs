using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Corona.Enums;
using Corona.Models.Content;

namespace Corona.Models.ViewModels
{
    public class LaboratoristCreateFormViewModel
    {
        public long StaffNumber { get; set; }

        [Required, DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime Dob { get; set; }

        [Required]
        [Display(Name = "ID No.")]
        public string Idnumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        [Required, DataType(DataType.EmailAddress), EmailAddress]
        [Display(Name = "Email")]
        public string EmailAddress { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Contant No.")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Address Line1")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required]
        [Display(Name = "Suburb")]
        public int SuburbId { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string NextOfName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string NextOfKinSurname { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public string NextOfKinNumber { get; set; }

        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }

        [Display(Name = "Hospital")]
        public int? HospitalId { get; set; }


        public List<SelectListItem> GenderType { get; set; }
        public LaboratoristCreateFormViewModel()
        {
            GenderType = new List<SelectListItem>();

            GenderType.Add(new SelectListItem
            {
                Value = ((int)Gender.Male).ToString(),
                Text = Gender.Male.ToString()
            });
            GenderType.Add(new SelectListItem
            {
                Value = ((int)Gender.Female).ToString(),
                Text = Gender.Female.ToString()
            });
        }

        public List<SelectListItem> Departments { get; set; } = new List<SelectListItem>(); 
        public int SelectedSuburb { get; set; }

        public int Age
        {
            get
            {
                var now = DateTime.Today;
                var age = now.Year - Dob.Year;
                if (Dob > now.AddYears(-age)) age--;
                return age;
            }

        }

    }
}
