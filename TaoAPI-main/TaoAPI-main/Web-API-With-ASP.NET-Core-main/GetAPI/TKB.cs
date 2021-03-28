using DevExpress.XtraBars;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetAPI
{
    public partial class TKB : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private Session sess;
        Session Sess
        {
            get { return sess; }
            set { sess = value; }
        }
        public TKB(Session sess)
        {
            InitializeComponent();
            this.sess = sess;
            loadData();
        }
        public void loadData()
        {
            string id = sess.id;
            string baseUrl = "https://localhost:44375/api/CongViec/"+id ;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(baseUrl);
                var data = JsonConvert.DeserializeObject<List<ModelLich>>(json);

                dtgvTKB.DataSource = data;
               
            }
        }
        public void Them(string day, string thoigian, string viec)
        {

            ModelLich lich = new ModelLich();
            string userID = sess.id;


            lich.user_id = userID;
            lich.day = day;
            lich.thoigian = thoigian;
            lich.viec = viec;

            string postData = JsonConvert.SerializeObject(lich);

            string strUrl = String.Format("https://localhost:44375/api/CongViec");
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "POST";
            request.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();
                var response = request.GetResponse();
                using (var streamReader = new StreamReader(response.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                }
            }

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            string day = cbDay.Text;
            string time = txtTime.Text;
            string job = txtJob.Text;
            Them(day, time, job);
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}