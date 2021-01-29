using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using Xamarin.Forms;
using API.Models;
using UIForms.Views;

namespace UIForms.ViewModels
{
    public class CountryItemViewModel : Country
    {
        public ICommand LocateCommand => new Command(() => Locate());

        private async void Locate()
        {
            MainViewModel.GetInstance().Map = new MapViewModel((Country)this);
            await Application.Current.MainPage.Navigation.PushAsync(new MapPage());
        }
    }
}
