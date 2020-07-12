using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class Post : INotifyPropertyChanged
    {
        private Venue venue;

        [JsonIgnore]
        public Venue Venue
        {
            get { return venue; }
            set
            {
                venue = value;
                if (venue.categories != null)
                {
                    var firstCategoty = venue.categories.FirstOrDefault();

                    if (firstCategoty != null)
                    {
                        CategoryId = firstCategoty.id;
                        CategoryName = firstCategoty.name;
                    }
                }
                
                if (venue.location != null)
                {
                    Address = venue.location.address;
                    Distance = venue.location.distance;
                    Latitude = venue.location.lat;
                    Longitude = venue.location.lng;
                }
                
                VenueName = venue.name;
                UserId = App.user.Id;

                OnPropertyChanged("Venue");
            }
        }


        private string id;

        public string Id
        {
            get { return id; }
            set 
            { 
                id = value;
                OnPropertyChanged("Id");
            }
        }

        private string experience;
            
        public string Experience
        {
            get { return experience; }
            set
            { 
                experience = value;
                OnPropertyChanged("Experience");
            }
        }


        private string venuename;

        public string VenueName
        {
            get { return venuename; }
            set 
            { 
                venuename = value;
                OnPropertyChanged("VenueName");
            }
        }

        private string  categoryid;

        public string CategoryId
        {
            get { return categoryid; }
            set 
            {
                categoryid = value;
                OnPropertyChanged("CategoryId");
            }
        }

        private string  categoryname;

        public string CategoryName
        {
            get { return categoryname; }
            set
            { 
                categoryname = value;
                OnPropertyChanged("CategoryName");
            }
        }

        private string address;

        public string Address
        {
            get { return address; }
            set 
            { 
                address = value;
                OnPropertyChanged("Address");
            }
        }


        private double latitude;

        public double Latitude
        {
            get { return latitude; }
            set 
            { 
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }

        private double longitude;

        public double Longitude
        {
            get { return longitude; }
            set 
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }

        private int distance;

        public int Distance
        {
            get { return distance; }
            set 
            { 
                distance = value;
                OnPropertyChanged("Distance");
            }
        }

        private string userid;

        public string UserId
        {
            get { return userid; }
            set 
            {
                userid = value;
                OnPropertyChanged("UserId");
            }
        }

        private DateTimeOffset createdat;

        public DateTimeOffset CREATEDAT
        {
            get { return createdat; }
            set 
            { 
                createdat = value;
                OnPropertyChanged("CREATEDAT");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static async void Insert(Post post)
        {
            await App.postsTable.InsertAsync(post);
            await App.MobileService.SyncContext.PushAsync();
        }

        public static async Task<bool> Delete(Post post)
        {
            try
            {
                await App.postsTable.DeleteAsync(post);
                await App.MobileService.SyncContext.PushAsync();
                return true;
            }
            catch ( Exception ex)
            {
                return false;   
            }
        }

        public static async Task<List<Post>> GetUserPosts()
        {
            var posts =  await App.postsTable.Where(p => p.UserId == App.user.Id).ToListAsync();
            return posts;
        }

        public static Dictionary<string,int> PostCategories(List<Post> posts)
        {
            var categories = (from p in posts
                              orderby p.CategoryId
                              select p.CategoryName).Distinct().ToList();



            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var category in categories)
            {
                var count = (from post in posts
                             where post.CategoryName == category
                             select post).ToList().Count;


                categoriesCount.Add(category, count);
            }

            return categoriesCount;
        }

 
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            } 
        }
    }
}
