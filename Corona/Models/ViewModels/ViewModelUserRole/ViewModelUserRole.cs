using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Enums;

namespace Corona.Models.ViewModels.DoctorViewModel
{
    public class ViewModelUserRole
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public string Email { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public string ClinicId { get; set; }
        public string ProfileImage { get; set; }
    }
}
