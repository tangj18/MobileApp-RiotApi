using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using A2.controller;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A2.apis;
using A2.views;
using Newtonsoft.Json;
using A2.sql;

namespace A2.views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class searchPage : ContentPage
    {
        public searchPage()
        {
            InitializeComponent();

            var regionList = new List<string>();
            regionList.Add("NA1");
            regionList.Add("BR1");
            regionList.Add("EUN1");
            regionList.Add("EUW1");
            regionList.Add("JP1");
            regionList.Add("KR");
            regionList.Add("LA1");
            regionList.Add("LA2");
            regionList.Add("OC1");
            regionList.Add("RU");
            regionList.Add("TR1");

            Region.ItemsSource = regionList;
            searchPageBackground.Source = new Uri("https://i.pinimg.com/originals/b7/00/bb/b700bb75fef515ee3437495ad91c09be.jpg");
            logo.Source = "lolStats.png";
        }
        public bool inDatabase = false;
        private async void searchPlayer(object s, EventArgs e)
        {
            

            if(Username.Text == null || Region.SelectedItem.ToString() == null)
            {
                await DisplayAlert("Error!", "Please Select Region And Enter Summoner Name.", "Ok");
                
            }
            else{
                string name = Username.Text;
                string region = Region.SelectedItem.ToString();

                summoner summoner = new summoner(region);
                league league = new league(region);
                teamfighttactic tft = new teamfighttactic(region);
               

                var summonerData = summoner.GetSummonerByName(name);
                
                var sumSR = JsonConvert.SerializeObject(summonerData, Formatting.Indented);


                var person = await App.Database.GetPersonByName(summonerData.name);
                if(person != null)
                {
                    
                    inDatabase = true;
                }
                else
                {
                    
                    inDatabase = false;
                }


                if (sumSR == "null")
                {
                    await DisplayAlert("ok", "Summoner Name Not Found!", "ok");
                }
                else
                {
                    
                    var soloData = league.getPosition(summonerData.id).Where(p => p.queueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault();
                    var flexData = league.getPosition(summonerData.id).Where(p => p.queueType.Equals("RANKED_FLEX_SR")).FirstOrDefault();
                    var tftRankedData = tft.GetTFTstat(summonerData.id).Where(p => p.queueType.Equals("RANKED_TFT")).FirstOrDefault();
                    var tftHyperData = tft.GetTFTstat(summonerData.id).Where(p => p.queueType.Equals("RANKED_TFT_TURBO")).FirstOrDefault();

                    var xsolo = JsonConvert.SerializeObject(soloData, Formatting.Indented);
                    var xflex = JsonConvert.SerializeObject(flexData, Formatting.Indented);
                    var xTFT = JsonConvert.SerializeObject(tftRankedData, Formatting.Indented);
                    var xHyper = JsonConvert.SerializeObject(tftHyperData, Formatting.Indented);
                    
                    if (xsolo == "null" && xflex == "null" && xTFT == "null" && xHyper == "null")
                    {
                        
                        await DisplayAlert("User Rank Empty", "Sorry, User information will be unranked, come back when you have at least one ranking.", "Okay");

                    }
                    else
                    {
                        
                        await Navigation.PushAsync(new rankedData(name, region, summonerData.summonerLevel, inDatabase));
                        Username.Text = string.Empty;
                    }      
                }
            }
        }

        async void ShowFav(object s, EventArgs e)
        {
            await Navigation.PushAsync(new favUsers());
        }
    }
}