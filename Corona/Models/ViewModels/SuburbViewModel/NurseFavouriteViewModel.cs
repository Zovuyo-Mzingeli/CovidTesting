using Corona.Models.CommonMapping;
using Corona.Models.Content;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModel.SuburbViewModel
{
    public class NurseFavouriteViewModel : IMapFrom<FavouriteSuburb>
    {
        public string FavouriteId { get; set; }
        [PersonalData]
        [MaxLength(50)]
        [Required]
        public string SuburbId { get; set; }
        [PersonalData]
        [MaxLength(50)]
        public string NurseId { get; set; }

        public virtual Suburb Suburb { get; set; }

    }
}
