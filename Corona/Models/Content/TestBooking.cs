using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Content
{
    public class TestBooking
    {
        public string TestBookingId { get; set; }
        public string RequestId { get; set; }
        public DateTime BookingDate { get; set; }
        public string TimeSlot { get; set; }
        public string NurseId { get; set; }
        public string Status { get; set; }
        public virtual ApplicationUser Nurse { get; set; }
        public virtual RequestTest RequestTest { get; set; }
    }
}
