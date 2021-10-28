using System;
using System.Collections.Generic;
using System.Text;

namespace A2.Utils
{
    class helperFunction
    {

        public helperFunction()
        {

        }

        public string getColor(char c)
        {
            if(c == 'L')
            {
                return "#ff4a36";
            }  
            else if (c == 'W')
            {
                return "#34d5eb";
            }
            else
            {
                return "#b3b5b4";
            }
        }
        string lvlString;
        public string getLvlBorder(int level)
        {
            if(level >= 0 && level < 30)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/8/86/Level_1_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105818";
            }else if(level >=30 && level < 50)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/4/40/Level_30_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105839";
            }
            else if (level >= 50 && level < 75)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/c/c0/Level_50_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105839";
            }
            else if (level >= 75 && level < 100)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/d/d7/Level_75_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105840";
            }
            else if (level >= 100 && level < 125)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/9/99/Level_100_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105841";
            }
            else if (level >= 125 && level < 150)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/e/eb/Level_125_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105841";
            }
            else if (level >= 150 && level < 175)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/8/8f/Level_150_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105842";
            }
            else if (level >= 175 && level < 200)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/9/9e/Level_175_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105842";
            }
            else if (level >= 200 && level < 225)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/1/11/Level_200_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105843";
            }
            else if (level >= 225 && level < 250)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/e/e6/Level_225_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105844";
            }
            else if (level >= 250 && level < 275)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/b/bd/Level_250_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105838";
            }
            else if (level >= 275 && level < 300)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/2/27/Level_275_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105914";
            }
            else if (level >= 300 && level < 325)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/7/70/Level_300_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105915";
            }
            else if (level >= 325 && level < 350)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/1/1c/Level_325_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105916";
            }
            else if (level >= 350 && level < 375)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/b/b4/Level_350_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105917";
            }
            else if (level >= 375 && level < 400)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/6/6f/Level_375_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180324105917";
            }
            else if (level >= 400 && level < 425)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/8/88/Level_400_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180406054517";
            }
            else if (level >= 425 && level < 450)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/e/e3/Level_425_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180406054642";
            }
            else if (level >= 450 && level < 475)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/a/a9/Level_450_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180406054738";
            }
            else if (level >= 475 && level < 500)
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/9/9f/Level_475_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180406054805";
            }
            else
            {
                lvlString = "https://static.wikia.nocookie.net/leagueoflegends/images/2/2e/Level_500_Summoner_Icon_Border.png/revision/latest/scale-to-width-down/1000?cb=20180406054832";
            }

            return lvlString;
        }
    }
}
