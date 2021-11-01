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
    public partial class SubRegionAdd : ContentPage
    {

        AddSubRegionViewModel vm;

        public SubRegionAdd(Country country)
        {
            InitializeComponent();

            BindingContext = vm = new AddSubRegionViewModel(country.CountryID);

            this.Title = "Add Sub Region for " + country.ShortName;

        }
    }
}