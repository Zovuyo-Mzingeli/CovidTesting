using Corona.Models.Content;
using Corona.Models.ViewModel.SuburbViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Corona.Models.Repositories.FavouriteSuburbs
{
    public interface IFavouriteSuburbRepository
    {
        Task AddFavouriteSuburb(
            string NurseId,
            string SuburbId);

        FavouriteSuburb GetFavouriteSuburbById(string favourateId);
        Task<IEnumerable<NurseFavouriteViewModel>> FavouriteAsync(string nurseId);
        Task<IEnumerable<NurseFavouriteViewModel>> AllFavouriteAsync();

    }
}
