using System;
using System.Collections.Generic;
using System.Text;

namespace A2.Utils
{
    public class emblemGetter
    {
        
        public emblemGetter()
        {
            
        }
        
        public string tempString;
        public string EmblemResult(string t)
        {
            

            switch (t)
            {
                case "IRONIV":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Iron_4.png/revision/latest/scale-to-width-down/280?cb=20181229234928";
                    break;
                case "IRONIII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/9/95/Season_2019_-_Iron_3.png/revision/latest/scale-to-width-down/280?cb=20181229234927";
                    break;
                case "IRONII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/5/5f/Season_2019_-_Iron_2.png/revision/latest/scale-to-width-down/280?cb=20181229234927";
                    break;
                case "IRONI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/0/03/Season_2019_-_Iron_1.png/revision/latest/scale-to-width-down/280?cb=20181229234926";
                    break;
                case "BRONZEIV":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/5/5a/Season_2019_-_Bronze_4.png/revision/latest/scale-to-width-down/280?cb=20181229234913";
                    break;
                case "BRONZEIII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/8/81/Season_2019_-_Bronze_3.png/revision/latest/scale-to-width-down/280?cb=20181229234912";
                    break;
                case "BRONZEII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/a/ac/Season_2019_-_Bronze_2.png/revision/latest/scale-to-width-down/280?cb=20181229234911";
                    break;
                case "BRONZEI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/f/f4/Season_2019_-_Bronze_1.png/revision/latest/scale-to-width-down/280?cb=20181229234910";
                    break;
                case "SILVERIV":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/5/52/Season_2019_-_Silver_4.png/revision/latest/scale-to-width-down/280?cb=20181229234938";
                    break;
                case "SILVERIII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/1/19/Season_2019_-_Silver_3.png/revision/latest/scale-to-width-down/280?cb=20181229234937";
                    break;
                case "SILVERII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/5/56/Season_2019_-_Silver_2.png/revision/latest/scale-to-width-down/280?cb=20181229234936";
                    break;
                case "SILVERI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Silver_1.png/revision/latest/scale-to-width-down/280?cb=20181229234936";
                    break;
                case "GOLDIV":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/c/cc/Season_2019_-_Gold_4.png/revision/latest/scale-to-width-down/280?cb=20181229234922";
                    break;
                case "GOLDIII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/a/a6/Season_2019_-_Gold_3.png/revision/latest/scale-to-width-down/280?cb=20181229234921";
                    break;
                case "GOLDII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/8/8a/Season_2019_-_Gold_2.png/revision/latest/scale-to-width-down/280?cb=20181229234921";
                    break;
                case "GOLDI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/9/96/Season_2019_-_Gold_1.png/revision/latest/scale-to-width-down/280?cb=20181229234920";
                    break;
                case "PLATINUMIV":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/a/ac/Season_2019_-_Platinum_4.png/revision/latest/scale-to-width-down/280?cb=20181229234934";
                    break;
                case "PLATINUMIII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/2/2b/Season_2019_-_Platinum_3.png/revision/latest/scale-to-width-down/280?cb=20181229234934";
                    break;
                case "PLATINUMII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/a/a3/Season_2019_-_Platinum_2.png/revision/latest/scale-to-width-down/280?cb=20181229234933";
                    break;
                case "PLATINUMI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/7/74/Season_2019_-_Platinum_1.png/revision/latest/scale-to-width-down/280?cb=20181229234932";
                    break;
                case "DIAMONDIV":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/e/ec/Season_2019_-_Diamond_4.png/revision/latest/scale-to-width-down/280?cb=20181229234919";
                    break;
                case "DIAMONDIII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/d/dc/Season_2019_-_Diamond_3.png/revision/latest/scale-to-width-down/280?cb=20181229234918";
                    break;
                case "DIAMONDII":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/7/70/Season_2019_-_Diamond_2.png/revision/latest/scale-to-width-down/280?cb=20181229234918";
                    break;
                case "DIAMONDI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/9/91/Season_2019_-_Diamond_1.png/revision/latest/scale-to-width-down/280?cb=20181229234917";
                    break;
                case "MASTERI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/1/11/Season_2019_-_Master_1.png/revision/latest/scale-to-width-down/280?cb=20181229234929";
                    break;
                case "GRANDMASTERI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/7/76/Season_2019_-_Grandmaster_1.png/revision/latest/scale-to-width-down/280?cb=20181229234923";
                    break;
                case "CHALLENGERI":
                    tempString = "https://static.wikia.nocookie.net/leagueoflegends/images/5/5f/Season_2019_-_Challenger_1.png/revision/latest/scale-to-width-down/280?cb=20181229234913";
                    break;


            }
            return tempString;
        }
    }
}
