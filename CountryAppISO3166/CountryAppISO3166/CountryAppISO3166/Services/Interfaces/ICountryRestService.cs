using CountryAppISO3166.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CountryAppISO3166.Services
{
    public interface ICountryRestService
    {

        Task<List<Country>> getAllCountries();
        Task<List<Country>> getCountriesByTerm(string term);
        Task<Country> postCountry(Country item);


        Task<List<SubRegion>> getSubRegionsByCountry(int countryId);


        Task<SubRegion> postSubRegion(SubRegion item);
        Task<SubRegion> putSubRegion(SubRegion item);
        Task<string> deleteSubRegion(SubRegion item);

    }
}
