using AspNetIdentityDemo.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentityDemo.Api.Services
{

    public interface ICountryService
    {

        Task<List<Country>> GetCountryList(string term);
        Task<Country> GetCountryById(int Id);
        Task CreateCountry(Country reg);
        void UpdateCountry(int id);
        void DeleteCountry(int id);

        Task<List<SubRegion>> GetSubRegionList(int idCountry);

        Task CreateSubRegion(SubRegion reg);
        Task UpdateSubRegion(SubRegion reg);
        Task DeleteSubRegion(int SubRegionID);
    }

    public class CountryService : ICountryService
    {

        private ApplicationDbContext _context;

        public CountryService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<List<Country>> GetCountryList(string term)
        {

            if (string.IsNullOrEmpty(term))
            {
                return await _context.Countries.ToListAsync();
            }


            if (term.Length == 2)
            {
                var ret1 = _context.Countries.Where(x => x.Alpha2Code.Equals(term)).ToListAsync();
                if (ret1.Result.Count > 0)
                {
                    return await ret1;
                }
            }

            var ret = _context.Countries.Where(x => x.FullName.Contains(term) || x.ShortName.Contains(term)).ToListAsync();

            return await ret;

        }

        public async Task<Country> GetCountryById(int Id)
        {
            var ret1 = _context.Countries.Where(x => x.CountryID.Equals(Id)).SingleOrDefaultAsync();
            
            return await ret1;
            
        }

        

        public void DeleteCountry(int id)
        {
            
        }

        

        public void UpdateCountry(int id)
        {
            
        }

        async Task ICountryService.CreateCountry(Country reg)
        {
            _context.Countries.Add(reg);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SubRegion>> GetSubRegionList(int idCountry)
        {
            var ret = _context.SubRegions.Where(x => x.CountryID.Equals(idCountry)).ToListAsync();

            return await ret;
        }

        public  async Task CreateSubRegion(SubRegion reg)
        {
            _context.SubRegions.Add(reg);

            var country = _context.Countries.Where(x => x.CountryID.Equals(reg.CountryID)).SingleOrDefault();
            country.SubRegionsCount = country.SubRegionsCount + 1;

            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubRegion(SubRegion reg)
        {
            var item  = _context.SubRegions.Where(x => x.SubRegionID.Equals(reg.SubRegionID)).SingleOrDefault();

            item.Code = reg.Code;
            item.Category = reg.Category;
            item.Name = reg.Name;

            await _context.SaveChangesAsync();

        }

        public async Task DeleteSubRegion(int SubRegionID)
        {
            var item = _context.SubRegions.Where(x => x.SubRegionID.Equals(SubRegionID)).SingleOrDefault();
            var countryId = item.CountryID;

            if (item != null)
            {
                _context.SubRegions.Remove(item);

                var country = _context.Countries.Where(x => x.CountryID.Equals(countryId)).SingleOrDefault();
                country.SubRegionsCount = country.SubRegionsCount - 1;

            }

            await _context.SaveChangesAsync();

        }
    }
}
