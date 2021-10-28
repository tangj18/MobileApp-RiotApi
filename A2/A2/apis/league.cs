using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using A2.apis;
using Xamarin.Forms;
using A2.models;
using Newtonsoft.Json;

namespace A2.apis
{
    public class league : api
    {
        public league(string reg) : base(reg)
        {

        }
       
        public List<positionInfo> getPosition(string sumId)
        {
            string path = "lol/league/v4/entries/by-summoner/" + sumId;

            var response = GET(GetURI(path));
            string content = response.Content.ReadAsStringAsync().Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<positionInfo>>(content);
            }
            else
            {
                return null;
            }

        }
    }
}