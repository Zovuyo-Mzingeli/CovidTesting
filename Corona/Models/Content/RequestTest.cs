using Corona.Data;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Corona.Models.Content
{
    public class RequestTest
    {
        [Key]
        public string RequestId { get; set; }
        public DateTime RequestedDate { get; set; } = DateTime.Now;
        public string NurseId { get; set; }
        public string RequestorId { get; set; }
        public string DependentId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string SuburbId { get; set; }
        public string Status { get; set; } = "New";

        public virtual ApplicationUser Nurse { get; set; }
        public virtual ApplicationUser Requestor { get; set; }
        public virtual Suburb Suburb { get; set; }
        public virtual Dependent Dependent { get; set; }
        public virtual ICollection<TestBooking> TestBookings { get; set; }

    }
}
