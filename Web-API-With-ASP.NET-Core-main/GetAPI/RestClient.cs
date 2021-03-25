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

namespace GetAPI
{
    
    public static class RestClient
    {
        private static readonly string baseURL= "https://localhost:44375/api/Account";
        public static async Task<string> get()
        {
            using(HttpClient client =new HttpClient())
            {
                using(HttpResponseMessage res=await  client.GetAsync(baseURL))
                {
                    using(HttpContent content=res.Content)
                    {
                        string data =await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
        public static async Task<string> getid(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL+"/"+ id))
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
        public static async Task<String> Post(string username,string password)
        {
            var inputData = new Dictionary<string, string>
                {
                    
                    {"username",username},
                    {"password",password }
                };
            var input = new FormUrlEncodedContent(inputData);
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsync(baseURL,input))
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
        public static async Task<String> Put(int id,string username, string password)
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
                using (HttpResponseMessage res = await client.PutAsync(baseURL+"/" +id, input))
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
        public static async Task<string> Delete(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://localhost:44375/api/Account/" + id))
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
        public static string makeJson(string json)
        {
            JToken parseJson = JToken.Parse(json);
            return parseJson.ToString(Formatting.Indented);
        }


        //public async Task<string> post(string username,string password)
        //{
        //    HttpWebRequest webRequest;


        //    var requestParams = new Dictionary<string, string>
        //    {
        //        { "id","0"},
        //        {"username",username},
        //        {"password",password }
        //    };
            
        //}
    }
}
