using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModel.DedepentViewModel
{
    public class DependentModificationModel
    {
        [Required]
        public string FullNames { get; set; }
        public string DependentId { get; set; }
        public string[] IdToAdd { get; set; }

    }
}
