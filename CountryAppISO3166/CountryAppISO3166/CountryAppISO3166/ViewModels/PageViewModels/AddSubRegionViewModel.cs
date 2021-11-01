using System;
using System.Windows.Input;
using CountryAppISO3166.Models;
using CountryAppISO3166.Services;
using Xamarin.Forms;

namespace CountryAppISO3166.ViewModels
{
    public class AddSubRegionViewModel
    {

        private ICountryRestService countryRestService;

        public SubRegion SelectedItem { get; set; }

        public AddSubRegionViewModel(int countryId)
        {
            countryRestService = App.IoCContainer.GetInstance<ICountryRestService>();
            SelectedItem = new SubRegion();
            SelectedItem.CountryID = countryId;
        }

        public ICommand SendItemCommand => new Command(async () =>
        {
            
            var ret_new =  await countryRestService.postSubRegion(SelectedItem);

            if (ret_new != null)
            {
                await App.Current.MainPage.Navigation.PopAsync();
            }


        });

        
    }
}
