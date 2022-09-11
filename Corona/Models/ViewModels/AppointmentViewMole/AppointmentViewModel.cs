using Corona.Models.CommonMapping;
using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModels.AppointmentViewMole
{
    public class AppointmentViewModel
    {
        public string Tittle { get; set; }
        public List<RequestTest> Appointments { get; set; }
    }
}
