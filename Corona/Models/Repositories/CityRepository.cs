using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Data;
using Corona.Models.Content;
using Corona.Models.Repositories;

namespace Corona.Models.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly CoronaContext _context;
        public CityRepository(CoronaContext context)
        {
            _context = context;
        }

        public void Add(City city)
        {
            _context.tblCity.Add(city);
        }
        public int CountCity(string id)
        {
            return _context.tblCity.Count(a => a.CityId == id);
        }

        public IEnumerable<City> GetCities()
        {
            return _context.tblCity.ToList();
        }

        public City GetCity(string id)
        {
            return _context.tblCity.Find(id);
        }

    }
}
