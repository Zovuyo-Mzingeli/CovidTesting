using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Content
{
    public partial class City
    {
        public City()
        {
           
        }
        [Key]
        public string CityId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter city name")]
        [MaxLength(50)]
        [MinLength(3)]
        public string CityName { get; set; }
        public virtual ICollection<Suburb> Suburbs { get; set; }
    }
}

