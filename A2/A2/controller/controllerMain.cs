using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2.apis;
using A2.Utils;
using Xamarin.Forms;

namespace A2.controller
{
    public class controllerMain
    {
        public bool GetSummoner(string sumName, string region)
        {
            summoner summoner = new summoner(region);

            var sum = summoner.GetSummonerByName(sumName);

            constants.sum = sum;
            constants.Region = region;

            return sum != null;
        }
    }
}