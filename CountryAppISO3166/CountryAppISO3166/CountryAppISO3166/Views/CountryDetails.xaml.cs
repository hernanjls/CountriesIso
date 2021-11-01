using CountryAppISO3166.Models;
using CountryAppISO3166.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountryAppISO3166.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CountryDetails : ContentPage
    {

        DetailsCountryViewModel vm;
        Country country;
        public CountryDetails(Country item)
        {
            country = item;
            vm = new DetailsCountryViewModel();

            vm.SelectedItem = item;

            BindingContext = vm;

            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PopulateSubRegionsByCountry(country.CountryID);
        }

        private async void FAB_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SubRegionAdd(country));
        }

        private async void ListViewRegions_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var subRegion = e.Item as SubRegion;

           await  Navigation.PushAsync(new EditSubRegion(subRegion));
        }
    }
}