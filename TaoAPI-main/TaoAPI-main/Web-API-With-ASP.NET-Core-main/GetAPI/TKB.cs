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
        BindingSource list = new BindingSource();
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
            AddBinding();

        }
        public void AddBinding()
        {
            // binding data
            cbDay.DataBindings.Add(new Binding("Text", dtgvTKB.DataSource, "day"));
            txtTime.DataBindings.Add(new Binding("Text", dtgvTKB.DataSource, "thoigian"));
            txtJob.DataBindings.Add(new Binding("Text", dtgvTKB.DataSource, "viec"));
            txtid.DataBindings.Add(new Binding("Text", dtgvTKB.DataSource, "id"));
        }
        public void loadData()
        {
            string id = sess.id;
            string baseUrl = "https://localhost:44375/api/CongViec/"+id ;
            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(baseUrl);
                var data = JsonConvert.DeserializeObject<List<ModelLich>>(json);
                list.DataSource = data;
                dtgvTKB.DataSource = data;
                

            }
            

        }
        public void Them(string day, string thoigian, string viec, string id)
        {

            ModelLich lich = new ModelLich();
            string userID = sess.id;
            // User Id da dang nhap
            lich.id = id;
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

        public void Sua(string id, string day, string thoigian, string viec)
        {
            ModelLich lich = new ModelLich();
            lich.id = id;
            lich.day = day;
            lich.thoigian = thoigian;
            lich.viec = viec;
            lich.user_id = sess.id;
            string putData = JsonConvert.SerializeObject(lich);
            string strUrl = String.Format("https://localhost:44375/api/CongViec/"+id);
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "PUT";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(putData);
                streamWriter.Flush();
                streamWriter.Close();
                var reponse = request.GetResponse();
                using(var streamReader=new StreamReader(reponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    
                }
            }

        }

        private async void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            int idVao = Int32.Parse(txtid.Text);
            int idTang = idVao + 1;
            string id = idTang.ToString();
            string day = cbDay.Text;
            string time = txtTime.Text;
            string job = txtJob.Text;
            var checkid = await RestClient.getidTKB(sess.id, id);
            // kiem tra id 
            if (checkid != "[]")
            {
                MessageBox.Show("Id already exist");

            }
            else
            {
                Them(day, time, job, id);
                MessageBox.Show("Add schedule success");
            }
                

            loadData();
            
            
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            string id = txtid.Text;
            string day = cbDay.Text;
            string time = txtTime.Text;
            string job = txtJob.Text;
            Sua(id,day,time,job);
            MessageBox.Show("Change Schedule success");
            loadData();
        }
        public void Xoa(string id)
        {
            ModelLich lich = new ModelLich();
            lich.id = id;
            
            string putData = JsonConvert.SerializeObject(lich);
            string strUrl = String.Format("https://localhost:44375/api/CongViec/"+id);
            WebRequest request = WebRequest.Create(strUrl);
            request.Method = "DELETE";
            request.ContentType = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(putData);
                streamWriter.Flush();
                streamWriter.Close();
                var reponse = request.GetResponse();
                using (var streamReader = new StreamReader(reponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
        }
        private async void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            string id = txtid.Text;
            string userid = sess.id;
            var check =await RestClient.getidTKB(userid, id);
            if (check != "[]")
            {
                Xoa(id);
                MessageBox.Show("Delete success");
            }   
            // Neu khong tim thay cong viec 
               
            else
                MessageBox.Show("Schedule doesn't exist");


            loadData();
        }

        private void TKB_Load(object sender, EventArgs e)
        {

        }
    }
}