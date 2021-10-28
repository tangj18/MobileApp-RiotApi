using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace A2.sql
{
    public class Favourites
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string summonerName { get; set; }
        public string summonerRegion { get; set; }
    }
}
