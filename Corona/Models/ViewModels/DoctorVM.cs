using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Corona.Enums;
using Corona.Models.Content;

namespace Corona.Models.ViewModels
{
    public class DoctorVM
    {
        
        public List<SelectListItem> GenderType { get; set; }
        public DoctorVM()
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
    }
}
