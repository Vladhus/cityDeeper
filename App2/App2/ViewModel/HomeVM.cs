using App2.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace App2.ViewModel
{
    public class HomeVM
    {
        public NavigationCommand NavigationCommand { get; set; }

        public HomeVM()
        {
            NavigationCommand = new NavigationCommand(this);
        }

        public async void Navigate()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewTravelPage());
        }
    }
}
