using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Ubiety.Dns.Core;
using System.IO;
using System.Net;
using System.Net.Http;

namespace GetAPI
{
   
    public partial class fLich : Form
    {
        BindingSource list = new BindingSource();
        BindingSource list3 = new BindingSource();
        BindingSource list4 = new BindingSource();
        BindingSource list5 = new BindingSource();
        BindingSource list6 = new BindingSource();
        BindingSource list7 = new BindingSource();
        BindingSource listcn = new BindingSource();
        public fLich()
        {
            InitializeComponent();

            loadAllData();
        }
        public void loadAllData()
        {
            loadData();
            //binding();
        }
         void binding()
        {

            txtday2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "day"));
            txttime2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "thoigian"));
            txtjob2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "viec"));
            txtid2.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday3.DataBindings.Add(new Binding("Text", dtgv3.DataSource, "day"));
            txttime3.DataBindings.Add(new Binding("Text", dtgv3.DataSource, "thoigian"));
            txtjob3.DataBindings.Add(new Binding("Text", dtgv3.DataSource, "viec"));
            txtid3.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday4.DataBindings.Add(new Binding("Text", dtgv4.DataSource, "day"));
            txttime4.DataBindings.Add(new Binding("Text", dtgv4.DataSource, "thoigian"));
            txtjob4.DataBindings.Add(new Binding("Text", dtgv4.DataSource, "viec"));
            txtday4.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));


            txtday5.DataBindings.Add(new Binding("Text", dtgv5.DataSource, "day"));
            txttime5.DataBindings.Add(new Binding("Text", dtgv5.DataSource, "thoigian"));
            txtjob5.DataBindings.Add(new Binding("Text", dtgv5.DataSource, "viec"));
            txtid5.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday6.DataBindings.Add(new Binding("Text", dtgv6.DataSource, "day"));
            txttime6.DataBindings.Add(new Binding("Text", dtgv6.DataSource, "thoigian"));
            txtjob6.DataBindings.Add(new Binding("Text", dtgv6.DataSource, "viec"));
            txtid6.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtday7.DataBindings.Add(new Binding("Text", dtgv7.DataSource, "day"));
            txttime7.DataBindings.Add(new Binding("Text", dtgv7.DataSource, "thoigian"));
            txtjob7.DataBindings.Add(new Binding("Text", dtgv7.DataSource, "viec"));
            txtid7.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));

            txtdaycn.DataBindings.Add(new Binding("Text", dtgvcn.DataSource, "day"));
            txttimecn.DataBindings.Add(new Binding("Text", dtgvcn.DataSource, "thoigian"));
            txtjobcn.DataBindings.Add(new Binding("Text", dtgvcn.DataSource, "viec"));
            txtidcn.DataBindings.Add(new Binding("Text", dtgv2.DataSource, "id"));


        }




        async void loadData()

        {
            #region 1
            //var response= await Lich.getid("2", "3", "8gio");
            //txtsang3.Text = response;


            //HttpClient clint = new HttpClient();
            //clint.BaseAddress = new Uri("https://localhost:44375/api/");
            //HttpResponseMessage response = clint.GetAsync("CongViec/2/3/8gio").Result;

            //var emp = response.Content.ReadAsAsync<IEnumerable<ModelLich>>().Result;
            //dataGridView1.DataSource = emp;
            #endregion
            Session s = new Session();
            string userid = s.id;
            string baseUrl = "https://localhost:44375/api/CongViec/1" +"/2";


            // convert json to datagridview
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(baseUrl);
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv2.DataSource = user;
                list.DataSource = user;
            }


            #region a


             using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/1" + "/3");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv3.DataSource = user;
                list3.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/1" + "/4");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv4.DataSource = user;
                list4.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/1" + "/5");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv5.DataSource = user;
                list5.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/1" + "/6");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv6.DataSource = user;
                list6.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/1" + "/7");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgv7.DataSource = user;
                list7.DataSource = user;
            }
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString("https://localhost:44375/api/CongViec/1" + "/cn");
                var user = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgvcn.DataSource = user;
                listcn.DataSource = user;
            }
            #endregion

        }

        private void dtgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void addlich()
        {
            string id = "0";
            string userid = "1";
            string day = "2";
            string time = "22";
            string job = "aaa";
            var inputData = new Dictionary<string, string>
                {
                     {"id",id },
                     { "user_id",userid},
                     { "thoiGian",time },

                     {"day",day },
                     {"viec",job  }




                };
            var input = new FormUrlEncodedContent(inputData);
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:44375/api/CongViec");
                
                request.Method = "POST";
                
                request.Credentials = CredentialCache.DefaultCredentials;
                ((HttpWebRequest)request).UserAgent = "Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0)";


                string postData = "{\"id\":" + id + ",\"user_id\":" + userid + ",\"thoiGian\":" + time + ",\"day\":" + day + ",\"time\":" + time + ",\"job\":" + job + "}";

                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                request.ContentType = "application/json; charset=utf-8";

                
                
                request.ContentLength = byteArray.Length;

                
                Stream dataStream = request.GetRequestStream();
               
                dataStream.Write(byteArray, 0, byteArray.Length);
                
                dataStream.Close();
                
                WebResponse response = request.GetResponse();
              
                MessageBox.Show(((HttpWebResponse)response).StatusDescription);
               
                dataStream = response.GetResponseStream();
                
                StreamReader reader = new StreamReader(dataStream);
               
                string responseFromServer = reader.ReadToEnd();
              
                MessageBox.Show(responseFromServer);
                
                reader.Close();
                dataStream.Close();
                response.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Wrong request ! " + ex.Message, "Error");
            }
        }

        private async void btnthem_Click(object sender, EventArgs e)
        {
            string id = "1";
            string userid = "1";
            string day = "2";
            string time = "15 gio";
            string job = "thiet ke api";
            var x = await RestClient.Post(id, userid, day, time, job);
            txtday2.Text = x.ToString();



        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            //int id = 2;
            //RestClient.Delete(id);
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

