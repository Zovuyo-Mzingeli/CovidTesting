using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Models.Content;

namespace Corona.Models.Repositories
{
    public interface ICityRepository
    {
        IEnumerable<City> GetCities();
        int CountCity(string id);
        City GetCity(string id);
        void Add(City city);
    }
}
