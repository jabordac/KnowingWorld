using System;
using UIForms.ViewModels;
using UIForms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace UIForms
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainViewModel.GetInstance().Countries = new CountriesViewModel();
            MainPage = new NavigationPage(new CountriesPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
