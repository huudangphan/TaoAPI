    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace GetAPI
{
    
    public static class RestClient
    {
        private static readonly string baseURL= "https://localhost:44375/api/Account";
        //public static async Task<string> get()
        //{
        //    using(HttpClient client =new HttpClient())
        //    {
        //        using(HttpResponseMessage res=await  client.GetAsync(baseURL))
        //        {
        //            using(HttpContent content=res.Content)
        //            {
        //                string data =await content.ReadAsStringAsync();
        //                if (data != null)
        //                    return data;
        //            }
        //        }
        //    }
        //    return string.Empty;
        //}
        //public static async Task<string> getid(string id)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        using (HttpResponseMessage res = await client.GetAsync(baseURL+"/"+ id))
        //        {
        //            using (HttpContent content = res.Content)
        //            {
        //                string data = await content.ReadAsStringAsync();
        //                if (data != null)
        //                    return data;
        //            }
        //        }
        //    }
        //    return string.Empty;
        //}
        public static async Task<String> PostLogin(string username,string password)
        {
            var inputData = new Dictionary<string, string>
                {
                    
                    {"username",username},
                    {"password",password }
                };
            var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL +"/"+username+"/"+password))
                {
                    res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty; 
        }
        public static async Task<String> PostAccount(string username, string password)
        {
            var inputData = new Dictionary<string, string>
                {

                    {"username",username},
                    {"password",password }
                };
            var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage res = new HttpResponseMessage();
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                using ( res = await client.PostAsync("https://localhost:44375/api/Account", input))
                {
                   
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<String> Post(string id, string userID, string thu, string thoigian, string viec)
        {
            var inputData = new Dictionary<string, string>
                {
                     {"id", "1" },
                     { "user_id","1"},
                     { "thoiGian","9 gio" },           
                     {"day","2" },
                     {"viec","thiet ke giao dien" }             

                };
            var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                
                using (HttpResponseMessage res = await client.PostAsync("https://localhost:44375/api/CongViec",input))

                {

                    res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<String> Put(int id, string username, string password)
        {
            var inputData = new Dictionary<string, string>
                {
                    { "id","0"},
                    {"username",username},
                    {"password",password }
                };
            var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsync(baseURL + "/" + id, input))
                {

                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty; /*input.ToString();*/
        }
        public static async Task<string> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://localhost:44375/api/CongViec/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        res.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        public static string makeJson(string json)
        {
            JToken parseJson = JToken.Parse(json);
            return parseJson.ToString(Formatting.Indented);
        }


    }
}
