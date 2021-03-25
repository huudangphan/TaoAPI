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


namespace GetAPI
{
    public partial class fLich : Form
    {
        public fLich()
        {
            InitializeComponent();
            loadData();
        }
        public async void loadData()

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

            //string id = "2";
            //string day = "3";
            //string thoigian = "8gio";
            //using (HttpClient client = new HttpClient())
            //{
            //    using (HttpResponseMessage res = await client.GetAsync("https://localhost:44375/api/CongViec/1/0/string/string" /*+ "/" + id + "/" + day + "/" + thoigian*/))
            //    {
            //        var data = res.Content.ReadAsAsync<IEnumerable<ModelLich>>().Result;

            //        dataGridView1.DataSource = data;

            //    }
            //}

        }
    }
}
