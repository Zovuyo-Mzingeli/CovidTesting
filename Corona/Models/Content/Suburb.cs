using Corona.Data;
using Corona.Models.Content;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Corona.Models.Content
{
    public class Suburb
    {
        [Key]
        public string SuburbId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Suburb name")]
        [Display(Name = "Suburb")]
     
        public string SuburbName { get; set; }
        public string CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<FavouriteSuburb> Favourites { get; set; }
        public virtual ICollection<Dependent> Dependents { get; set; }

    }
}
