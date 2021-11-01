using CountryAppISO3166.Models;
using CountryAppISO3166.ViewModels.PageViewModels;
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
    public partial class CountrySearch : ContentPage
    {
        string searchTerm = "";
        CountrySearchViewModel vm;
        public CountrySearch()
        {
            InitializeComponent();

            BindingContext = vm = new CountrySearchViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.PopulateCountries();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var country = e.Item as Country;

            Navigation.PushAsync(new CountryDetails(country));
        }

        protected async void search_Clicked(object sender, EventArgs e)
        {
            await vm.PopulateCountriesByTerm(searchTerm);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchTerm = e.NewTextValue;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CountryAdd());
        }
    }
}