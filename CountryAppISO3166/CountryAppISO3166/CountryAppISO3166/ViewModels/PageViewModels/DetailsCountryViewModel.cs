using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using CountryAppISO3166.Models;
using CountryAppISO3166.Services;
using Xamarin.Forms;

namespace CountryAppISO3166.ViewModels
{
    public class DetailsCountryViewModel : BaseViewModel
    {

        private ICountryRestService countryRestService;

        public Country SelectedItem { get; set; }

        List<SubRegion> _subRegionsViewModel = new List<SubRegion>();
        public List<SubRegion> SubRegionsViewModel
        {
            get
            {

                return _subRegionsViewModel;

            }
            set
            {
                _subRegionsViewModel = value;
                RaisePropertyChanged();
            }
        }

        public DetailsCountryViewModel()
        {
            countryRestService = App.IoCContainer.GetInstance<ICountryRestService>();
            
        }


        public async Task PopulateSubRegionsByCountry(int countryId)
        {
            try
            {
                IsBusy = true;
                var items = new List<SubRegion>();

                var tempMakes = await countryRestService.getSubRegionsByCountry(countryId);

                foreach (var make in tempMakes)
                {
                    items.Add(make);
                }

                SubRegionsViewModel.Clear();
                SubRegionsViewModel = items;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            finally
            {
                IsBusy = false;
            }

        }

    

        public ICommand EditCoutryCommand => new Command(async () =>
        {
            

            //await _dataService.PutTodo(SelectedTodo.Id, SelectedTodo);
        });

        public ICommand DeleteCountryCommand => new Command(async () =>
        {
           

           // await _dataService.DeleteTodo(SelectedTodo.Id);
        });
    }
}
