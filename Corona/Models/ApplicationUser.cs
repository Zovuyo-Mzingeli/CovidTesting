using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Corona.Enums;
using Corona.Extensions;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Corona.Models
{
    public class ApplicationUser : IdentityUser
    {
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
        [MaxLength(250)]
        public string AddressLine1 { get; set; }
        [PersonalData]
        [MaxLength(250)]
        public string AddressLine2 { get; set; }
       
        [PersonalData]
        [MaxLength(50)]
        public string SuburbId { get; set; }

        public char UserStatus { get; set; } = 'A';

        [PersonalData]
        [MaxLength(50)]

        public string MedicalAidId { get; set; }
        [PersonalData]
        [MaxLength(50)]

        public string MedicalAidNumber { get; set; }
        [PersonalData]
        [MaxLength(50)]

        public string PlanId { get; set; }


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
        [NotMapped]
        public string PatientIdOrDob
        {
            get
            {
                return string.Format("{0} ({1})", Idnumber, Dob);
            }
        }

        public virtual Suburb Suburb { get; set; }
        public virtual MedicalAid Medical { get; set; }
        public virtual MedicalPlan MedicalPlan { get; set; }
        public ICollection<ApplicationUserRole> UserRoles { get; set; }
        public ICollection<Dependent> Dependents { get; set; }
        public List<PatientVitals> LabUsers { get; set; } = new List<PatientVitals>();
        public List<PatientVitals> Nurses { get; set; } = new List<PatientVitals>();
        public List<TestBooking> AllNurses { get; set; } = new List<TestBooking>();
        public List<RequestTest> NurseRequest { get; set; } = new List<RequestTest>();
        public List<RequestTest> PatientRequest { get; set; } = new List<RequestTest>();

    }
}
