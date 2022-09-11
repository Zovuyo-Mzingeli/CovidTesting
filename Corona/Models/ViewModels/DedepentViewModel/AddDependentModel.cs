using Corona.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.ViewModel.DedepentViewModel
{
    public class AddDependentModel
    {
        public Dependent GetDependent { get; set; }
        public IEnumerable<ApplicationUser> members { get; set; }
        public IEnumerable<Dependent> nonMembers { get; set; }
    }
}
