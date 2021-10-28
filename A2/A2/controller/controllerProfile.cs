using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using A2.Utils;
using A2.apis;

namespace A2.controller
{
    public class controllerProfile 
    {
       public bool Getinfo(string id, string region)
        {
            league league = new league(region);

            var data = league.getPosition(id);

            return data != null;
        }
    }
}