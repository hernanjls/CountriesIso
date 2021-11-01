using System;
using System.Windows.Input;
using CountryAppISO3166.Models;
using CountryAppISO3166.Services;
using Xamarin.Forms;

namespace CountryAppISO3166.ViewModels
{
    public class EditSubRegionViewModel
    {

        private ICountryRestService countryRestService;

        public SubRegion SelectedItem { get; set; }

        public EditSubRegionViewModel(SubRegion reg)
        {
            countryRestService = App.IoCContainer.GetInstance<ICountryRestService>();
            SelectedItem = reg;
        }


        public ICommand EditItemCommand => new Command(async () =>
        {
           
            await countryRestService.putSubRegion(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        });

        public ICommand DeleteItemCommand => new Command(async () =>
        {
            await countryRestService.deleteSubRegion(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        });


        
    }
}
