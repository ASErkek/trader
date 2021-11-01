using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace YatirimDefteri.Models
{
    public class Varlik
    {
        public Bankalar banka;
        public VarlikTurleri varlikTuru;
        public float miktar;

        string birim_isareti;
        public Color renk = Color.Red;
        public string renk_string = "#00FF00";
        public Varlik(Bankalar banka, VarlikTurleri varlikTuru, float miktar)
        {
            this.banka = banka;
            this.varlikTuru = varlikTuru;
            this.miktar = miktar;
            Birim_gorsellerini_ayarla();
            
        }

        public string varlikAdi
        {
            get
            {
                return varlikTuru.ToString();
            }
        }
        public string varlikMiktari
        {
            get
            {
                return birim_isareti + " "+ miktar.ToString("#.00");
            }
        }

        void Birim_gorsellerini_ayarla()
        {
            switch (varlikTuru)
            {
                case VarlikTurleri.TL:
                    renk = Color.CadetBlue;
                    birim_isareti = "₺";
                    break;
                case VarlikTurleri.USD:
                    renk = Color.DeepPink;
                    birim_isareti = "$";
                    break;
                case VarlikTurleri.EUR:
                    renk = Color.Bisque;
                    birim_isareti = "€";
                    break;
                case VarlikTurleri.GBP:
                    renk = Color.Chocolate;
                    birim_isareti = "x";
                    break;
                case VarlikTurleri.XAU:
                    renk = Color.Cyan;
                    birim_isareti = "x";
                    break;
                case VarlikTurleri.OAU:
                    renk = Color.DarkSlateBlue;
                    birim_isareti = "x";
                    break;
                default:
                    break;
            }
        }
        
    }
}
