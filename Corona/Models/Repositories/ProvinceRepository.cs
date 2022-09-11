using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corona.Data;
using Corona.Models.Content;

namespace Corona.Models.Repositories
{
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly CoronaContext context;

        public ProvinceRepository(CoronaContext context)
        {
            this.context = context;
        }
        public Province Add(Province province)
        {
            context.tblProvince.Add(province);
            context.SaveChanges();
            return province;
        }

        public Province Delete(int Id)
        {
            Province province = context.tblProvince.Find(Id);
            if (province != null)
            {
                context.tblProvince.Remove(province);
                context.SaveChanges();
            }
            return province;
        }

        public Province GetProvince(int Id)
        {
            return context.tblProvince.Find(Id);
        }

        public IEnumerable<Province> GetProvinces()
        {
            return context.tblProvince;
        }

        public Province Update(Province editProvince)
        {
            var province = context.tblProvince.Attach(editProvince);
            province.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return editProvince;
        }
    }
}