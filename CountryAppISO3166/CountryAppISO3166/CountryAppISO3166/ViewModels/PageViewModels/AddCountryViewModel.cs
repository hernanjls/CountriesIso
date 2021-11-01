using System;
using System.Windows.Input;
using CountryAppISO3166.Models;
using CountryAppISO3166.Services;
using Xamarin.Forms;

namespace CountryAppISO3166.ViewModels
{
    public class AddCountryViewModel
    {

        private ICountryRestService countryRestService;

        public Country SelectedItem { get; set; }
        public AddCountryViewModel()
        {
            countryRestService = App.IoCContainer.GetInstance<ICountryRestService>();
            SelectedItem = new Country();
        }

        public ICommand SendItemCommand => new Command(async () =>
        {
            
            var ret_new =  await countryRestService.postCountry(SelectedItem);

            if (ret_new != null)
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }


        });

        
    }
}
