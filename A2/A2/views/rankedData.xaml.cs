using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using A2.apis;
using A2.Utils;
using Newtonsoft.Json;
using A2.sql;


namespace A2.views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class rankedData : TabbedPage
    {
        public string sqlRegion;
        public string sqlName;
        
        public rankedData(string name, string region, int lvl, bool database)
        {
            InitializeComponent();
            
            summoner summoner = new summoner(region);
            league league = new league(region);
            teamfighttactic tft = new teamfighttactic(region);
            helperFunction helperFunction = new helperFunction();
            emblemGetter emblemGetter = new emblemGetter();

            var summonerData = summoner.GetSummonerByName(name);

            sqlRegion = region;
            sqlName = summonerData.name;
            

            username.Text = summonerData.name;
            username1.Text = summonerData.name;
            username2.Text = summonerData.name;
            string imgString = "https://opgg-static.akamaized.net/images/profile_icons/profileIcon" + summonerData.profileIconId + ".jpg";
            var img = new Uri(imgString);
            proficon.Source = img;
            proficon1.Source = img;
            proficon2.Source = img;
            string lvlString = helperFunction.getLvlBorder(lvl);
            lvlBorder.Source = new Uri(lvlString);
            lvlBorder1.Source = new Uri(lvlString);
            lvlBorder2.Source = new Uri(lvlString);
            leveltag.Text = lvl.ToString();
            leveltag1.Text = lvl.ToString();
            leveltag2.Text = lvl.ToString();

            var soloData = league.getPosition(summonerData.id).Where(p => p.queueType.Equals("RANKED_SOLO_5x5")).FirstOrDefault();
            var flexData = league.getPosition(summonerData.id).Where(p => p.queueType.Equals("RANKED_FLEX_SR")).FirstOrDefault();
            var rankedTFTdata = tft.GetTFTstat(summonerData.id).Where(p => p.queueType.Equals("RANKED_TFT")).FirstOrDefault();
            var hyperTFTdata = tft.GetTFTstat(summonerData.id).Where(p => p.queueType.Equals("RANKED_TFT_TURBO")).FirstOrDefault();
            var xsolo = JsonConvert.SerializeObject(soloData, Formatting.Indented);
            var xflex = JsonConvert.SerializeObject(flexData, Formatting.Indented);
            var xRankedTFT = JsonConvert.SerializeObject(rankedTFTdata, Formatting.Indented);
            var xHyperTFT = JsonConvert.SerializeObject(hyperTFTdata, Formatting.Indented);


            //sql for toolbar
            if (database)
            {
                addFav.Text = "Unfavourite";
            }
            else
            {
                addFav.Text = "Add To Favourite";
            }

            

            //solo queue data

            if (xsolo == "null")
            {
                rankborder.Source = new Uri("https://static.wikia.nocookie.net/leagueoflegends/images/5/5e/Season_2019_-_Provisional.png/revision/latest/scale-to-width-down/676?cb=20190908074433");
                rankborder.Margin = new Thickness(0, 0, 0, -130);
                noRank.IsVisible = true;
                rankEmblem.IsVisible = false;
                statistics.IsVisible = false;
                winRate.IsVisible = false;
                wrLabel.IsVisible = false;
                progressBack.IsVisible = false;
                progressFront.IsVisible = false;
                promoTitle.IsVisible = false;
                p1.IsVisible = false;
                p2.IsVisible = false;
                p3.IsVisible = false;
                p4.IsVisible = false;
                p5.IsVisible = false;
                p1T.IsVisible = false;
                p2T.IsVisible = false;
                p3T.IsVisible = false;
                p4T.IsVisible = false;
                p5T.IsVisible = false;
            }
            else
            {
                noRank.IsVisible = false;
                rankEmblem.IsVisible = true;
                statistics.IsVisible = true;
                winRate.IsVisible = true;
                wrLabel.IsVisible = true;
                progressBack.IsVisible = true;
                progressFront.IsVisible = true;
                promoTitle.IsVisible = true;
                p1.IsVisible = true;
                p2.IsVisible = true;
                p3.IsVisible = true;
                p4.IsVisible = true;
                p5.IsVisible = true;
                p1T.IsVisible = true;
                p2T.IsVisible = true;
                p3T.IsVisible = true;
                p4T.IsVisible = true;
                p5T.IsVisible = true;

                string ranktier = soloData.tier + soloData.rank;
                string tempRankBorder = emblemGetter.EmblemResult(ranktier);
                int totalGames = soloData.wins + soloData.losses;
                int ratio = (int)Math.Round((double)(100 * soloData.wins) / totalGames);
                string winRatio = ratio.ToString() + "%";
                double wr = Convert.ToDouble(ratio) / 100;
                rankborder.Source = new Uri(tempRankBorder);
                rankEmblem.Text = soloData.tier + " " + soloData.rank;
                statistics.Text = soloData.leaguePoints + "LP / " + soloData.wins + "W " + soloData.losses + "L";
                winRate.Text = winRatio;
                progressFront.Progress = wr;

                if (soloData.rank == "I")
                {
                    rankborder.Margin = new Thickness(0, 0, 0, -130);
                }
                else if (soloData.rank == "II")
                {
                    rankborder.Margin = new Thickness(0, -20, 0, -145);
                }
                else if (soloData.rank == "III" || soloData.rank == "IV")
                {
                    rankborder.Margin = new Thickness(0, -40, 0, -160);
                }

                if ((soloData.tier == "IRON" || soloData.tier == "BRONZE" || soloData.tier == "SILVER" || soloData.tier == "GOLD" || soloData.tier == "PLATINUM" || soloData.tier == "DIAMOND") && soloData.leaguePoints == 100)
                {
                    promoTitle.IsVisible = true;

                    char[] characters = soloData.miniSeries.progress.ToCharArray();
                    int numOfGames = soloData.miniSeries.wins + soloData.miniSeries.losses;



                    p1.ProgressColor = Color.FromHex(helperFunction.getColor(characters[0]));
                    p2.ProgressColor = Color.FromHex(helperFunction.getColor(characters[1]));
                    p3.ProgressColor = Color.FromHex(helperFunction.getColor(characters[2]));
                    p4.ProgressColor = Color.FromHex(helperFunction.getColor(characters[3]));
                    p5.ProgressColor = Color.FromHex(helperFunction.getColor(characters[4]));

                    switch (numOfGames)
                    {
                        case 0:
                            p1.IsVisible = false;
                            p2.IsVisible = false;
                            p3.IsVisible = false;
                            p4.IsVisible = false;
                            p5.IsVisible = false;
                            break;
                        case 1:
                            p1.IsVisible = true;
                            p2.IsVisible = false;
                            p3.IsVisible = false;
                            p4.IsVisible = false;
                            p5.IsVisible = false;
                            p1T.Text = characters[0].ToString();
                            break;
                        case 2:
                            p1.IsVisible = true;
                            p2.IsVisible = true;
                            p3.IsVisible = false;
                            p4.IsVisible = false;
                            p5.IsVisible = false;
                            p1T.Text = characters[0].ToString();
                            p2T.Text = characters[1].ToString();
                            break;
                        case 3:
                            p1.IsVisible = true;
                            p2.IsVisible = true;
                            p3.IsVisible = true;
                            p4.IsVisible = false;
                            p5.IsVisible = false;
                            p1T.Text = characters[0].ToString();
                            p2T.Text = characters[1].ToString();
                            p3T.Text = characters[2].ToString();
                            break;
                        case 4:
                            p1.IsVisible = true;
                            p2.IsVisible = true;
                            p3.IsVisible = true;
                            p4.IsVisible = true;
                            p5.IsVisible = false;
                            p1T.Text = characters[0].ToString();
                            p2T.Text = characters[1].ToString();
                            p3T.Text = characters[2].ToString();
                            p4T.Text = characters[3].ToString();
                            break;
                        case 5:
                            p1.IsVisible = true;
                            p2.IsVisible = true;
                            p3.IsVisible = true;
                            p4.IsVisible = true;
                            p5.IsVisible = true;
                            p1T.Text = characters[0].ToString();
                            p2T.Text = characters[1].ToString();
                            p3T.Text = characters[2].ToString();
                            p4T.Text = characters[3].ToString();
                            p5T.Text = characters[4].ToString();
                            break;

                    }

                }
                else
                {
                    promoTitle.IsVisible = false;
                    p2.IsVisible = false;
                    p3.IsVisible = false;
                    p4.IsVisible = false;
                    p5.IsVisible = false;
                    p1.IsVisible = false;
                }
            }


            //Flex Queue Data

            if (xflex == "null")
            {
                rankborder1.Source = new Uri("https://static.wikia.nocookie.net/leagueoflegends/images/5/5e/Season_2019_-_Provisional.png/revision/latest/scale-to-width-down/676?cb=20190908074433");
                rankborder1.Margin = new Thickness(0, 0, 0, -130);
                noRank1.IsVisible = true;
                rankEmblem1.IsVisible = false;
                statistics1.IsVisible = false;
                winRate1.IsVisible = false;
                wrLabel1.IsVisible = false;
                progressBack1.IsVisible = false;
                progressFront1.IsVisible = false;
                promoTitle1.IsVisible = false;
                p1f.IsVisible = false;
                p2f.IsVisible = false;
                p3f.IsVisible = false;
                p4f.IsVisible = false;
                p5f.IsVisible = false;
                p1Tf.IsVisible = false;
                p2Tf.IsVisible = false;
                p3Tf.IsVisible = false;
                p4Tf.IsVisible = false;
                p5Tf.IsVisible = false;
            }
            else
            {
                noRank1.IsVisible = false;
                rankEmblem1.IsVisible = true;
                statistics1.IsVisible = true;
                winRate1.IsVisible = true;
                wrLabel1.IsVisible = true;
                progressBack1.IsVisible = true;
                progressFront1.IsVisible = true;
                promoTitle1.IsVisible = true;
                p1f.IsVisible = true;
                p2f.IsVisible = true;
                p3f.IsVisible = true;
                p4f.IsVisible = true;
                p5f.IsVisible = true;
                p1Tf.IsVisible = true;
                p2Tf.IsVisible = true;
                p3Tf.IsVisible = true;
                p4Tf.IsVisible = true;
                p5Tf.IsVisible = true;

                string ranktier1 = flexData.tier + flexData.rank;
                string tempRankBorder1 = emblemGetter.EmblemResult(ranktier1);
                int totalGames1 = flexData.wins + flexData.losses;
                int ratio1 = (int)Math.Round((double)(100 * flexData.wins) / totalGames1);
                string winRatio1 = ratio1.ToString() + "%";
                double wr1 = Convert.ToDouble(ratio1) / 100;
                rankborder1.Source = new Uri(tempRankBorder1);
                rankEmblem1.Text = flexData.tier + " " + flexData.rank;
                statistics1.Text = flexData.leaguePoints + "LP / " + flexData.wins + "W " + flexData.losses + "L";
                winRate1.Text = winRatio1;
                progressFront1.Progress = wr1;

                if (flexData.rank == "I")
                {
                    rankborder1.Margin = new Thickness(0, 0, 0, -130);
                }
                else if (flexData.rank == "II")
                {
                    rankborder1.Margin = new Thickness(0, -20, 0, -145);
                }
                else if (flexData.rank == "III" || flexData.rank == "IV")
                {
                    rankborder1.Margin = new Thickness(0, -40, 0, -160);
                }

                if ((flexData.tier == "IRON" || flexData.tier == "BRONZE" || flexData.tier == "SILVER" || flexData.tier == "GOLD" || flexData.tier == "PLATINUM" || flexData.tier == "DIAMOND") && flexData.leaguePoints == 100)
                {
                    promoTitle1.IsVisible = true;

                    char[] characters = flexData.miniSeries.progress.ToCharArray();
                    int numOfGames = flexData.miniSeries.wins + flexData.miniSeries.losses;



                    p1f.ProgressColor = Color.FromHex(helperFunction.getColor(characters[0]));
                    p2f.ProgressColor = Color.FromHex(helperFunction.getColor(characters[1]));
                    p3f.ProgressColor = Color.FromHex(helperFunction.getColor(characters[2]));
                    p4f.ProgressColor = Color.FromHex(helperFunction.getColor(characters[3]));
                    p5f.ProgressColor = Color.FromHex(helperFunction.getColor(characters[4]));

                    switch (numOfGames)
                    {
                        case 0:
                            p1f.IsVisible = false;
                            p2f.IsVisible = false;
                            p3f.IsVisible = false;
                            p4f.IsVisible = false;
                            p5f.IsVisible = false;
                            break;
                        case 1:
                            p1f.IsVisible = true;
                            p2f.IsVisible = false;
                            p3f.IsVisible = false;
                            p4f.IsVisible = false;
                            p5f.IsVisible = false;
                            p1Tf.Text = characters[0].ToString();
                            break;
                        case 2:
                            p1f.IsVisible = true;
                            p2f.IsVisible = true;
                            p3f.IsVisible = false;
                            p4f.IsVisible = false;
                            p5f.IsVisible = false;
                            p1Tf.Text = characters[0].ToString();
                            p2Tf.Text = characters[1].ToString();
                            break;
                        case 3:
                            p1f.IsVisible = true;
                            p2f.IsVisible = true;
                            p3f.IsVisible = true;
                            p4f.IsVisible = false;
                            p5f.IsVisible = false;
                            p1Tf.Text = characters[0].ToString();
                            p2Tf.Text = characters[1].ToString();
                            p3Tf.Text = characters[2].ToString();
                            break;
                        case 4:
                            p1f.IsVisible = true;
                            p2f.IsVisible = true;
                            p3f.IsVisible = true;
                            p4f.IsVisible = true;
                            p5f.IsVisible = false;
                            p1Tf.Text = characters[0].ToString();
                            p2Tf.Text = characters[1].ToString();
                            p3Tf.Text = characters[2].ToString();
                            p4Tf.Text = characters[3].ToString();
                            break;
                        case 5:
                            p1f.IsVisible = true;
                            p2f.IsVisible = true;
                            p3f.IsVisible = true;
                            p4f.IsVisible = true;
                            p5f.IsVisible = true;
                            p1Tf.Text = characters[0].ToString();
                            p2Tf.Text = characters[1].ToString();
                            p3Tf.Text = characters[2].ToString();
                            p4Tf.Text = characters[3].ToString();
                            p5Tf.Text = characters[4].ToString();
                            break;

                    }

                }
                else
                {
                    promoTitle1.IsVisible = false;
                    p1f.IsVisible = false;
                    p2f.IsVisible = false;
                    p3f.IsVisible = false;
                    p4f.IsVisible = false;
                    p5f.IsVisible = false;
                    p1f.IsVisible = false;
                }
            }


         
            //tft page
            if(xRankedTFT == "null" && xHyperTFT != "null")
            {
                //only hyperroll rank
                rTFTemblem.Source = new Uri("https://static.wikia.nocookie.net/leagueoflegends/images/5/5e/Season_2019_-_Provisional.png/revision/latest/scale-to-width-down/676?cb=20190908074433");
                rTFTemblem.Margin = new Thickness(10, 40, -30, -115);
                rTFTrank.Text = "Unrated"; 
                rTFTrankText.IsVisible = true;
                rTFTprog.IsVisible = false;
                rTFTprogBack.IsVisible = false;
                rTFTwinrate.IsVisible = false;
                rTFTratio.IsVisible = false;
                rTFTratio1.IsVisible = false;
                rTFTwr.IsVisible = false;

                hTFTrank.IsVisible = true;
                hTFTrankText.IsVisible = false;
                hTFTnum.IsVisible = true;
                hTFTprog.IsVisible = true;
                hTFTwinrate.IsVisible = true;
                hTFTratio.IsVisible = true;
                hTFTwr.IsVisible = true;

                string ranktier = "badge_" + hyperTFTdata.ratedTier + ".png";
                int totalGames = hyperTFTdata.wins + hyperTFTdata.losses;
                int ratio = (int)Math.Round((double)(100 * hyperTFTdata.wins) / totalGames);
                string winRatio = ratio.ToString() + "%";
                double wr = Convert.ToDouble(ratio) / 100;
                winRate.Text = winRatio;
                progressFront.Progress = wr;

                hTFTemblem.Margin = new Thickness(5, 40, -40, -85);
                hTFTemblem.Source = ranktier;
                hTFTrank.Text = hyperTFTdata.ratedTier;
                hTFTnum.Text = hyperTFTdata.ratedRating.ToString();
                hTFTprog.Progress = wr;
                hTFTratio.Text = hyperTFTdata.wins + "W - " + hyperTFTdata.losses + "L";
                hTFTwr.Text = winRatio;

            }
            else if(xRankedTFT != "null" && xHyperTFT == "null")
            {
                //only ranked ranked
                hTFTemblem.Source = new Uri("https://static.wikia.nocookie.net/leagueoflegends/images/5/5e/Season_2019_-_Provisional.png/revision/latest/scale-to-width-down/676?cb=20190908074433");
                hTFTemblem.Margin = new Thickness(5, 40, -40, -85);
                hTFTrank.Text = "Unrated";
                hTFTnum.IsVisible = false;
                hTFTprog.IsVisible = false;
                hTFTprogBack.IsVisible = false;
                hTFTwinrate.IsVisible = false;
                hTFTratio.IsVisible = false;
                hTFTwr.IsVisible = false;
                hTFTrankText.IsVisible = true;

                string ranktier = rankedTFTdata.tier + rankedTFTdata.rank;
                string tempRankBorder = emblemGetter.EmblemResult(ranktier);
                int totalGames = rankedTFTdata.wins + rankedTFTdata.losses;
                int ratio = (int)Math.Round((double)(100 * rankedTFTdata.wins) / totalGames);
                string winRatio = ratio.ToString() + "%";
                double wr = Convert.ToDouble(ratio) / 100;

                rTFTrank.IsVisible = true;
                rTFTprog.IsVisible = true;
                rTFTwinrate.IsVisible = true;
                rTFTwr.IsVisible = true;
                rTFTrankText.IsVisible = false;

                rTFTemblem.Source = new Uri(tempRankBorder);
                rTFTrank.Text = rankedTFTdata.tier + " "+ rankedTFTdata.rank;
                rTFTratio.Text = rankedTFTdata.leaguePoints.ToString() + "LP   ";
                rTFTratio1.Text = rankedTFTdata.wins.ToString() + "W - " + rankedTFTdata.losses.ToString() + "L";
                rTFTprog.Progress = wr;
                rTFTwr.Text = winRatio;

                if (rankedTFTdata.rank == "I")
                {
                    rTFTemblem.Margin = new Thickness(10, 40, -30, -125);
                }
                else if (rankedTFTdata.rank == "II")
                {
                    rTFTemblem.Margin = new Thickness(10, 25, -30, -130);
                }
                else if (rankedTFTdata.rank == "III" || rankedTFTdata.rank == "IV")
                {
                    rTFTemblem.Margin = new Thickness(10, 10, -30, -135);
                }


            }
            else if (xRankedTFT == "null" && xHyperTFT == "null")
            {
                //neither rank
                hTFTemblem.Source = new Uri("https://static.wikia.nocookie.net/leagueoflegends/images/5/5e/Season_2019_-_Provisional.png/revision/latest/scale-to-width-down/676?cb=20190908074433");
                rTFTemblem.Margin = new Thickness(10, 40, -30, -125);
                hTFTrank.Text = "Unrated";
                hTFTnum.IsVisible = false;
                hTFTprog.IsVisible = false;
                hTFTprogBack.IsVisible = false;
                hTFTwinrate.IsVisible = false;
                hTFTratio.IsVisible = false;
                hTFTwr.IsVisible = false;


                rTFTemblem.Source = new Uri("https://static.wikia.nocookie.net/leagueoflegends/images/5/5e/Season_2019_-_Provisional.png/revision/latest/scale-to-width-down/676?cb=20190908074433");
                hTFTemblem.Margin = new Thickness(5, 40, -40, -85);
                rTFTrank.Text = "Unrated";
                rTFTprog.IsVisible = false;
                rTFTprogBack.IsVisible = false;
                rTFTwinrate.IsVisible = false;
                rTFTratio.IsVisible = false;
                rTFTratio1.IsVisible = false;
                rTFTwr.IsVisible = false;
            }
            else
            {
                //display both
                rTFTrankText.IsVisible = false;
                string ranktier = rankedTFTdata.tier + rankedTFTdata.rank;
                string tempRankBorder = emblemGetter.EmblemResult(ranktier);
                int totalGames = rankedTFTdata.wins + rankedTFTdata.losses;
                int ratio = (int)Math.Round((double)(100 * rankedTFTdata.wins) / totalGames);
                string winRatio = ratio.ToString() + "%";
                double wr = Convert.ToDouble(ratio) / 100;
                rTFTemblem.Source = new Uri(tempRankBorder);
                rTFTrank.Text = rankedTFTdata.tier + " " + rankedTFTdata.rank;
                rTFTratio.Text = rankedTFTdata.leaguePoints.ToString() + "LP   ";
                rTFTratio1.Text = rankedTFTdata.wins.ToString() + "W - " + rankedTFTdata.losses.ToString() + "L";
                rTFTprog.Progress = wr;
                rTFTwr.Text = winRatio;





                hTFTrankText.IsVisible = false;
                string ranktier1 = "badge_" + hyperTFTdata.ratedTier + ".png";
                int totalGames1 = hyperTFTdata.wins + hyperTFTdata.losses;
                int ratio1 = (int)Math.Round((double)(100 * hyperTFTdata.wins) / totalGames1);
                string winRatio1 = ratio1.ToString() + "%";
                double wr1 = Convert.ToDouble(ratio) / 100;
                winRate.Text = winRatio1;
                progressFront.Progress = wr1;
                hTFTemblem.Margin = new Thickness(5, 40, -40, -85);
                hTFTemblem.Source = ranktier1;
                hTFTrank.Text = hyperTFTdata.ratedTier;
                hTFTnum.Text = hyperTFTdata.ratedRating.ToString();
                hTFTprog.Progress = wr1;
                hTFTratio.Text = hyperTFTdata.wins + "W - " + hyperTFTdata.losses + "L";
                hTFTwr.Text = winRatio1;

            }
        }

        async void boolFav(object sender,EventArgs e)
        {
            var person = await App.Database.GetPersonByName(sqlName);
            if (person != null) //In database
            {
                await App.Database.RemovePersonAsync(person);
                addFav.Text = "Add To Favourite";
            }
            else
            {
                await App.Database.SavePersonAsync(new Favourites
                {
                    summonerName = sqlName,
                    summonerRegion = sqlRegion
                });
                addFav.Text = "Unfavourite";
            }
        }
    }
}