using Corona.Data;
using Corona.Models.ViewModels.DoctorViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.DoctorRepositories
{
    public class DoctorRepository
    {
        private readonly CoronaContext context;
        public DoctorRepository(CoronaContext context)
        {
            this.context = context;
        }
        //public async Task<IEnumerable<DoctorViewModel>> AllAsync()
        //   => await this.context
        //           .Users
        //           .Where(u => u.IsDoctor)
        //           .ProjectTo<DoctorViewModel>()
        //           .ToListAsync();
    }
}
