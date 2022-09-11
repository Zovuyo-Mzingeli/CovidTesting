using AutoMapper.QueryableExtensions;
using Corona.Data;
using Corona.Models.Content;
using Corona.Models.Repositories.FavouriteSuburbs;
using Corona.Models.ViewModel.SuburbViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.FavourateSuburbs
{
    public class FavouriteSuburbRepository : IFavouriteSuburbRepository
    {
        public readonly CoronaContext context;

        public FavouriteSuburbRepository(CoronaContext context)
        {
            this.context = context;
        }

        public async Task AddFavouriteSuburb(string NurseId, string SuburbId)
        {
            var Favourate = new FavouriteSuburb
            {
                NurseId = NurseId,
                SuburbId = SuburbId
            };
            await context.tblFavourateSuburb.AddAsync(Favourate);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<NurseFavouriteViewModel>> AllFavouriteAsync()
        {
            return await context
                .tblFavourateSuburb
                .OrderByDescending(x => x.Nurse.LastName)
                .ProjectTo<NurseFavouriteViewModel>()
                .ToListAsync();

        }

        public async Task<IEnumerable<NurseFavouriteViewModel>> FavouriteAsync(string nurseId)
        {
            return await context
                .tblFavourateSuburb
                .Where(n => n.NurseId == nurseId)
                .OrderByDescending(l => l.Nurse.LastName)
                .ProjectTo<NurseFavouriteViewModel>()
                .ToListAsync();
        }

        public FavouriteSuburb GetFavouriteSuburbById(string favourateId)
        {
            return context.tblFavourateSuburb.FirstOrDefault(a => a.FavouriteId == favourateId);

        }
    }
}
