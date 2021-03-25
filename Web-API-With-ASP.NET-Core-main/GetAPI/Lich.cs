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
    public static class Lich
    {
        private static  readonly string baseURL="https://localhost:44375/api/CongViec";
        public static async Task<string> getid(string id,string day,string thoigian)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(baseURL + "/" + id+"/"+day+"/"+thoigian))
                {
                    using (HttpContent content = res.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        if (data != null)

                            return data;
                        
                    }
                }
            }
            return string.Empty;
        }
        

    }
}
