using CountryAppISO3166.Models;
using CountryAppISO3166.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace CountryAppISO3166.ViewModels.PageViewModels
{
    
    public class CountrySearchViewModel : BaseViewModel
    {

		ObservableCollection<Country> _itemsViewModel = new ObservableCollection<Country>();
		public ObservableCollection<Country> ItemsViewModel
		{
			get
			{
				
				return _itemsViewModel;
				
			}
			set
			{
				_itemsViewModel = value;
				RaisePropertyChanged();
			}
		}

		
		
		private ICountryRestService countryRestService;

		public CountrySearchViewModel()
		{

			countryRestService = App.IoCContainer.GetInstance<ICountryRestService>();
			


		}

		public async Task PopulateCountries()
		{
			try
			{
				IsBusy = true;
				var tempMakes = await countryRestService.getAllCountries();
				var items = new ObservableCollection<Country>();
				foreach (var make in tempMakes)
				{
					items.Add(make);
				}
				ItemsViewModel = items;
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

		public async Task PopulateCountriesByTerm(string searchTerm)
		{
			try
			{
				IsBusy = true;
				var items = new ObservableCollection<Country>();

				if (string.IsNullOrEmpty(searchTerm))
				{
					var tempMakes = await countryRestService.getAllCountries();

					foreach (var make in tempMakes)
					{
						items.Add(make);
					}
				}
				else {

					var tempMakes = await countryRestService.getCountriesByTerm(searchTerm);

					foreach (var make in tempMakes)
					{
						items.Add(make);
					}
				}

				ItemsViewModel.Clear();
				ItemsViewModel = items;
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

	}
}
