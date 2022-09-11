using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Content
{
    public partial class Province
    {
        [Key]
        public string ProvinceId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter province name")]
        [Display(Name = "province name")]
      
        public string ProvinceName { get; set; }

        public virtual ICollection<ApplicationUser> TblUser { get; set; }
    }
}
