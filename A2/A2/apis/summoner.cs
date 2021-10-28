using System;
using System.Collections.Generic;
using System.Text;
using A2.models;

using Newtonsoft.Json;

namespace A2.apis
{
    class summoner : api
    {
        public summoner(string reg) : base(reg)
        {

        }
        public summonerInfo GetSummonerByName(string SummonerName){
            {
                string path = "lol/summoner/v4/summoners/by-name/" + SummonerName;

                var response = GET(GetURI(path));
                string content = response.Content.ReadAsStringAsync().Result;

                if(response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<summonerInfo>(content);
                }
                else
                {
                    return null;
                }
            } 
        }
    }
}
