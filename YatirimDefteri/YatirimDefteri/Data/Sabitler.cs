using System;
using System.Collections.Generic;
using System.Text;

namespace YatirimDefteri.Data
{
    public class Sabitler
    {
        //<!--PRIVATEs START -->

        //<!--PRIVATEs END -->


        #region REMOTE_HOST_LINKS
        static string site_adresi = "http://192.168.1.9/yatirimci";
        public static string loginUrl = site_adresi + "/giris.php";
        public static string kurSorguUrl = site_adresi + "/kurSorgula.php";
        public static string durumSorguUrl = site_adresi + "/durumum.php";
        public static string kayitUrl = site_adresi + "/kayit.php";
        #endregion
    }
}
