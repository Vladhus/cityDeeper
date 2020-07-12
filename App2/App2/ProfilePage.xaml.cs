using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var postTable = await Post.GetUserPosts();


            var categoriesCount = Post.PostCategories(postTable);
            catagoriesListView.ItemsSource = categoriesCount;
            postCountLabel.Text = postTable.Count.ToString();
        }
    }
}