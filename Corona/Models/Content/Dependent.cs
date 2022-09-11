using Microsoft.AspNetCore.Identity;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models
{
    public class Dependent
    {
        [Key]
        public string DependentId { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        [MaxLength(13)]
        [PersonalData]

        public string Idnumber { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [PersonalData]
        [MaxLength(50)]


        public string LastName { get; set; }
        [PersonalData]
        [MaxLength(50)]


        public string Gender { get; set; }
        [PersonalData]
        [MaxLength(250)]

        public string Email { get; set; }
        [PersonalData]
        [MaxLength(250)]

        public string PhoneNumber { get; set; }
        [PersonalData]
        [MaxLength(250)]
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
        [MaxLength(450)]
        public string PatientId { get; set; }

        [PersonalData]
        [MaxLength(50)]

        public string PostalCode { get; set; }

        [PersonalData]
        [MaxLength(50)]

        public string MedicalAidId { get; set; }
        [PersonalData]
        [MaxLength(50)]

        public string MedicalAidNumber { get; set; }
        [PersonalData]
        [MaxLength(50)]

        public string MedicalPlanId { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        [Display(Name = "Personel Details")]
        public string PersonelDetails
        {
            get
            {
                return LastName + " " + FirstName + ", " + Idnumber;
            }
        }
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

        public virtual City City { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual MedicalAid Medical { get; set; }
        public virtual MedicalPlan MedicalPlan { get; set; }
        public ApplicationUser MainMember { get; set; }
        public ICollection<RequestTest> RequestTests { get; set; }
    }
}
