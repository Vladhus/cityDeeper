using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Model;
using App2.ViewModel;
using Xamarin.Forms;

namespace App2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        MainVM viewModel;

        public MainPage()
        {
            InitializeComponent();

             var assemblyImageSource = typeof(MainPage);
            viewModel = new MainVM();

            BindingContext = viewModel;


            loginImage.Source = ImageSource.FromResource("App2.Assets.Images.8.png",assemblyImageSource);

            
        }

        private void randomImageForMainMenu()
        {
            var assemblyImageSource = typeof(MainPage);
            System.Random random = new Random();

            int pictureNum = random.Next(1, 7);
        
            switch (pictureNum)
            {
                case 1:
                    loginImage.Source = ImageSource.FromResource("App2.Assets.Images.7.png", assemblyImageSource);
                    break;
                case 2:
                    loginImage.Source = ImageSource.FromResource("App2.Assets.Images.5.png", assemblyImageSource);
                    break;
                case 3:
                    loginImage.Source = ImageSource.FromResource("App2.Assets.Images.4.png", assemblyImageSource);
                    break;
                case 4:
                    loginImage.Source = ImageSource.FromResource("App2.Assets.Images.11.png", assemblyImageSource);
                    break;
                case 5:
                    loginImage.Source = ImageSource.FromResource("App2.Assets.Images.1.png", assemblyImageSource);
                    break;
                case 6:
                    loginImage.Source = ImageSource.FromResource("App2.Assets.Images.8.png", assemblyImageSource);
                    break;
            }  
        }
    }
}
