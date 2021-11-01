using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace YatirimDefteri.Models
{
    public class Kullanici
    {
        [PrimaryKey]
        public int id { get; set; }
        public string kadi { get; set; }
        public string pass { get; set; }
        public string access_token { get; set; }

        public Kullanici() { }
        public Kullanici(string _kadi, string _pass)
        {
            kadi = _kadi;
            pass = _pass;
        }
    }
}
