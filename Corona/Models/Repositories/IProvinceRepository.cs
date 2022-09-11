using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Models.Content;

namespace Corona.Models.Repositories
{
    public interface IProvinceRepository
    {
        Province GetProvince(int Id);
        IEnumerable<Province> GetProvinces();
        Province Add(Province province);
        Province Update(Province editProvince);
        Province Delete(int Id);
    }
}
