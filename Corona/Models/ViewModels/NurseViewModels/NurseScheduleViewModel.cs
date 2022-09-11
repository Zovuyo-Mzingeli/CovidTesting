using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModel.NurseViewModels
{
    public class NurseScheduleViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public string Date { get; set; }
        public RequestTest test { get; set; }
        public IEnumerable<RequestServiceViewModel> Requests { get; set; }

       
            


    }
}
