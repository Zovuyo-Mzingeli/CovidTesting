using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Infrastructure;
using Corona.Models.Content;

namespace Corona.Models.ViewModels
{
    public class ProvinceViewModel
    {
        public IEnumerable<Province> Provinces { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
