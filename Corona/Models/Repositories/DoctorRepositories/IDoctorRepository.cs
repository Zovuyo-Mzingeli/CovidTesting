using Corona.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.DoctorRepositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorViewModel>> AllAsync();
    }
}
