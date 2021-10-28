using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using A2.views;
using A2.apis;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A2.sql
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class favUsers : ContentPage
    {
        public favUsers()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var personList = await App.Database.GetPeopleAsync();
            if (personList != null)
            {
                pList.ItemsSource = personList;
                
            }
            
        }


        public async void onSelectPerson(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            
            summoner summoner = new summoner((e.SelectedItem as Favourites).summonerRegion);
            var summonerData = summoner.GetSummonerByName((e.SelectedItem as Favourites).summonerName);
            await Navigation.PushAsync(new rankedData((e.SelectedItem as Favourites).summonerName, (e.SelectedItem as Favourites).summonerRegion, summonerData.summonerLevel, true));
        }
    }
}