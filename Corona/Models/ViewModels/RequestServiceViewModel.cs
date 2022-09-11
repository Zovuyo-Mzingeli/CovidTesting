using Corona.Models.CommonMapping;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModel
{
    public class RequestServiceViewModel : IMapFrom<RequestTest>
    {
        [Key]
        public string RequestTestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public TimeSpan EndTime { get; set; }

        [DataType(DataType.Date)]
        public string ScheduleFor { get; set; } 
        public string Time { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string SuburbId { get; set; }
        public string CityId { get; set; }
        public string postalCode { get; set; }
        public bool isConfirmed { get; set; }
        public bool isSelected { get; set; }
        public string PatientId { get; set; }
        public string DependentId { get; set; }
        public string NurseId { get; set; }
        public virtual ApplicationUser Patient { get; set; }
        public virtual ApplicationUser Nurse { get; set; }
        public virtual City City { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual Dependent Dependent { get; set; }

        
       


    }
}
