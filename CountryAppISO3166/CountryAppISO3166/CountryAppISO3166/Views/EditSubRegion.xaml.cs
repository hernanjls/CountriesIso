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
    public partial class EditSubRegion : ContentPage
    {
        EditSubRegionViewModel vm;
        SubRegion subRegion;
        public EditSubRegion(SubRegion item)
        {
            subRegion = item;
            BindingContext = vm = new EditSubRegionViewModel(subRegion);

            InitializeComponent();
        }
    }
}