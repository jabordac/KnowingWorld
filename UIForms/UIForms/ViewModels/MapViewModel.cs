using API.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
//using Xamarin.Forms.GoogleMaps;

namespace UIForms.ViewModels
{
    public class MapViewModel : BaseViewModel
    {
        private ApiService apiService;
        public Country Country { get; set; }

        public MapViewModel(Country country)
        {
            this.Country = country;
            this.apiService = new ApiService();
        }
    }
}
