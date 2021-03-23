using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace GetAPI
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
    public class RestClient
    {
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }
        public RestClient()
        {
            endPoint = string.Empty;
            httpMethod = httpVerb.GET;

        }
        public string makeRequest()
        {
            string strResponseValue = string.Empty;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(endPoint);
            request.Method = httpMethod.ToString();
            using(HttpWebResponse response =(HttpWebResponse) request.GetResponse())
            {
                if(response.StatusCode!=HttpStatusCode.OK)
                {
                    throw new AccessViolationException("erorr code:" + response.StatusCode.ToString());

                }
                // process the response stream... 
                using (Stream reponseStream = response.GetResponseStream())
                {
                    if(reponseStream!=null)
                    {
                        using(StreamReader reader=new StreamReader(reponseStream))
                            // read reponse
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                        //end o using repone stream
                    }
                }
                // end of using reponseStream
            }

            return strResponseValue;
        }
    }
}
