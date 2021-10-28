using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using A2.models;
using Newtonsoft.Json;

namespace A2.apis
{
    public class teamfighttactic : api
    {
        public teamfighttactic(string region) : base(region)
        {
            
        }

        public List<positionInfo> GetTFTstat(string sumId)
        {
            {
                string path = "tft/league/v1/entries/by-summoner/" + sumId;

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
}