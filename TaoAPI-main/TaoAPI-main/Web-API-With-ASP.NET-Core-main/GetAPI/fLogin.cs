using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace GetAPI
{
    public partial class fLogin : Form
    {
        string baseUrl = "https://localhost:44375/api/Account";
        public fLogin()
        {
            InitializeComponent();
        }
        public async void login()
        {
            string id = txtid.Text;
            string username = txtusername.Text;
            string password = txtpassword.Text;
            Session s = new Session();
            s.id = txtid.Text;
            s.username = username;
            s.password = password;
            var response = await RestClient.PostLogin(username, password);



            if ( response!= "[]")
            {


                TKB f = new TKB(s);
                f.Show();
                //fLich l = new fLich(s);
                //l.Show();
              
            }
            else
            {
                MessageBox.Show("username or password invalid");
            }


        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            
            login();
        }

        private void btndangky_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }
    }
}
