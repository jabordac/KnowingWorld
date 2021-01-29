using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIForms.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace UIForms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Title = $"Ubicación de {MainViewModel.GetInstance().Map.Country.Name.ToUpper()}";
            MoveMapToCountryPositionAsync();
        }

        private void MoveMapToCountryPositionAsync()
        {
            double latitud = MainViewModel.GetInstance().Map.Country.Latlng.ToArray()[0];
            double longitud = MainViewModel.GetInstance().Map.Country.Latlng.ToArray()[1];

            Position position = new Position(latitud, longitud);
            string name = MainViewModel.GetInstance().Map.Country.Name;

            MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(700)));

            MyMap.Pins.Add(new Pin
            {
                Label = name.ToUpper(),
                Position = new Position(position.Latitude, position.Longitude),
                Type = PinType.Place
            });
        }
    }
}