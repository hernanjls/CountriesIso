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
            string UrlApi = App.UrlApi + "country/search/" + term;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            
            var response = await httpClient.GetStringAsync(UrlApi);

            var items = JsonConvert.DeserializeObject<List<Country>>(response);

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
            string UrlApi = App.UrlApi + "country/subregions/" + countryId;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var response = await httpClient.GetStringAsync(UrlApi);

            var items = JsonConvert.DeserializeObject<List<SubRegion>>(response);

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

            var response = await httpClient.PutAsync(UrlApi, content);

            var responseBody = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<SubRegion>(responseBody);

            return ret;
        }

        public async Task<string> deleteSubRegion(SubRegion item)
        {
            string UrlApi = App.UrlApi + "country/deletesubregion/" + item.SubRegionID;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", App.accessToken);

            var response = await httpClient.DeleteAsync(UrlApi);

            var responseBody = await response.Content.ReadAsStringAsync();

            var ret = JsonConvert.DeserializeObject<string>(responseBody);

            return ret;
        }
    }
}
