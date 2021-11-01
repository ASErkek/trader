using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using YatirimDefteri.Models;
namespace YatirimDefteri.Data
{
    public class RestService
    {
        #region baglanti
        HttpClient client;
        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        }

        public async Task<T> Post<T>(List<KeyValuePair<string, string>> postData, string weburl) where T : class
        {
            var content = new FormUrlEncodedContent(postData);
            var response = await client.PostAsync(weburl, content);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return (T)responseObject;

        }
        public async Task<T> Get<T>(string weburl) where T : class
        {
            var response = await client.GetAsync(weburl);
            var jsonResult = response.Content.ReadAsStringAsync().Result;
            var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
            return (T)responseObject;

        }
        public T Get_wait<T>(string weburl) where T : class
        {
            var response = client.GetAsync(weburl);
            if(response.Result.IsSuccessStatusCode)
            {
                var jsonResult = response.Result.Content.ReadAsStringAsync().Result;
                var responseObject = JsonConvert.DeserializeObject<T>(jsonResult);
                return (T)responseObject;
            }
            return null;
           
            

        }
        #endregion


        #region specific_purpose

        public async Task<List<Models.Kur>> KurSorgula(int banka, int varlikTuru = -1)
        {
            var postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("banka", banka.ToString()));
            postData.Add(new KeyValuePair<string, string>("varlikTuru", varlikTuru.ToString()));


            string weburl = YatirimDefteri.Data.Sabitler.kurSorguUrl;
            var response = await Post<List<Models.Kur>>(postData, weburl);
            return (List<Models.Kur>)response;
        }

        public Models.Durum DurumSorgula()
        {
            string weburl = YatirimDefteri.Data.Sabitler.durumSorguUrl;
            var response = Get_wait<Models.Durum>(weburl);
           
            return response;
        }
        public async Task<Kullanici> Login(string kadi,string pass, string access_token)
        {
            List<KeyValuePair<string, string>> veri = new List<KeyValuePair<string, string>>();
            veri.Add(new KeyValuePair<string, string>("kadi", kadi));
            veri.Add(new KeyValuePair<string, string>("pass", pass));
            veri.Add(new KeyValuePair<string, string>("access_token", access_token));

            string weburl = YatirimDefteri.Data.Sabitler.loginUrl;
            var response = await Post<Kullanici>(veri, weburl);
            if(response != null && response.id>0)
            {
                return (Kullanici)response;
            }
            else
            {
                return null;
            }
            

        }
        public async Task<Kullanici> Kayit(string kadi, string pass, string eposta)
        {
            List<KeyValuePair<string, string>> veri = new List<KeyValuePair<string, string>>();
            veri.Add(new KeyValuePair<string, string>("kadi", kadi));
            veri.Add(new KeyValuePair<string, string>("pass", pass));
            veri.Add(new KeyValuePair<string, string>("eposta", eposta));

            string weburl = YatirimDefteri.Data.Sabitler.kayitUrl;
            var response = await Post<Kullanici>(veri, weburl);
            if (response != null && response.id > 0)
            {
                return (Kullanici)response;
            }
            else
            {
                return null;
            }


        }
        #endregion

    }

}
