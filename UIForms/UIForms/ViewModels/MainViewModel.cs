using System;
using System.Collections.Generic;
using System.Text;

namespace UIForms.ViewModels
{
    public class MainViewModel
    {
        private static MainViewModel instance;
        public CountriesViewModel Countries { get; set; }
        public MapViewModel Map { get; set; }

        public MainViewModel()
        {
            instance = this;
        }

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
