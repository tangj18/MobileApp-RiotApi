using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace A2.apis
{
    public class api 
    {
        private string key { get; set; }
        private string region { get; set; }
      public api(string reg)
        {
            key = "RGAPI-f86916c3-0333-434f-beaa-2a3d637eae87";
            region = reg;
        }

        protected HttpResponseMessage GET(string URL)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = client.GetAsync(URL);
                result.Wait();

                return result.Result;
            }
        }

        protected string GetURI(string path)
        {
            return "https://" + region + ".api.riotgames.com/" + path + "?api_key=" + key;
        }
    }
}