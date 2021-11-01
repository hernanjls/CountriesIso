using CountryAppISO3166.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CountryAppISO3166.Services
{
    public class CountryRestService : ICountryRestService
    {
        public async Task<List<Country>> getAllCountries()
        {

            string UrlApi = App.UrlApi + "country/" ;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var json = await httpClient.GetStringAsync(UrlApi);

            var items = JsonConvert.DeserializeObject<List<Country>>(json);

            return items;
        }

        public async Task<List<Country>> getCountriesByTerm(string term)
        {
            string UrlApi = App.UrlApi + "country/search";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var jsonData = JsonConvert.SerializeObject(term);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();
            
            var items = JsonConvert.DeserializeObject<List<Country>>(responseBody);

            return items;
        }

       
        public async Task<Country> postCountry(Country item)
        {
            string UrlApi = App.UrlApi + "country/";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var jsonData = JsonConvert.SerializeObject(item);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<Country>(responseBody);

            return ret;

        }

        public async Task<List<SubRegion>> getSubRegionsByCountry(int countryId)
        {
            string UrlApi = App.UrlApi + "country/subregions";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var jsonData = JsonConvert.SerializeObject(countryId);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var items = JsonConvert.DeserializeObject<List<SubRegion>>(responseBody);

            return items;
        }

        public async Task<SubRegion> postSubRegion(SubRegion item)
        {
            string UrlApi = App.UrlApi + "country/postsubregion";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var jsonData = JsonConvert.SerializeObject(item);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<SubRegion>(responseBody);

            return ret;
        }

        public async Task<SubRegion> putSubRegion(SubRegion item)
        {
            string UrlApi = App.UrlApi + "country/putsubregion";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var jsonData = JsonConvert.SerializeObject(item);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<SubRegion>(responseBody);

            return ret;
        }

        public async Task<string> deleteSubRegion(SubRegion item)
        {
            string UrlApi = App.UrlApi + "country/deletesubregion";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var jsonData = JsonConvert.SerializeObject(item);

            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<string>(responseBody);

            return ret;
        }
    }
}
