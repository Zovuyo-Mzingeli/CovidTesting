using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Models.Content;

namespace Corona.Models.ViewModels
{
    public class LaboratoristListViewModel
    {
        public long StaffNumber { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; } 
    }
}
