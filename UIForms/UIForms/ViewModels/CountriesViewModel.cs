using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;
using API.Models;

namespace UIForms.ViewModels
{
    public class CountriesViewModel : BaseViewModel
    {
        private readonly ApiService apiService;
        private bool isRefreshing;
        private string searchText;

        public List<CountryItemViewModel> CountriesAll { get; set; }


        private ObservableCollection<CountryItemViewModel> countries;
        public ObservableCollection<CountryItemViewModel> Countries
        {
            get => this.countries;
            set => this.SetValue(ref this.countries, value);
        }


        public CountriesViewModel()
        {
            this.apiService = new ApiService();
            this.LoadCountries();
        }

        public bool IsRefreshing
        {
            get => this.isRefreshing;
            set => this.SetValue(ref this.isRefreshing, value);
        }

        public string SearchText
        {
            get => searchText;
            set {
                this.SetValue(ref this.searchText, value);
                Search();
            }
        }

        public ICommand SearchCommand => new Command(() => Search());

        private void Search()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                Countries = new ObservableCollection<CountryItemViewModel>(CountriesAll.Where(c => c.Name.ToLower().StartsWith(SearchText.ToLower())));
            }
            else 
            {
                Countries = new ObservableCollection<CountryItemViewModel>(CountriesAll);
            }
        }

        private async void LoadCountries()
        {
            this.IsRefreshing = true;

            var response = await this.apiService.GetCountriesAsync<CountryItemViewModel>(
                "https://restcountries-v1.p.rapidapi.com",
                "/all",
                "",
                "X-RapidAPI-Key",
                "24f8cc5869msh5b87656d6e615f1p1cf334jsn0c1d83fdb12d"
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Aceptar");
                return;
            }

            var myCountries = (List<CountryItemViewModel>)response.Result;
            this.CountriesAll = new List<CountryItemViewModel>(myCountries);
            this.Countries = new ObservableCollection<CountryItemViewModel>(myCountries);

            this.IsRefreshing = false;
        }

    }
}
