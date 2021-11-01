using System;
using System.Collections.Generic;
using System.Text;

#region enumlar
public enum Bankalar
{
    Merkez_Bankasi = 0,
    Garanti,
    Is_Bankasi,
    Akbank,
    Yapi_Kredi,
    Ziraat,
    HSBC,
    Halkbank,
    Vakifbank,
    TEB,
    Sekerbank,
    Kuveyt_Turk,
    Enpara
}
public enum VarlikTurleri
{
    TL = 0,
    USD,
    EUR,
    GBP,
    XAU,
    OAU,
}
#endregion


namespace YatirimDefteri.Models
{
    public class Kur
    {
        public Bankalar banka;
        public VarlikTurleri varlikTuru;
        public float alis;
        public float satis;

    }
}
