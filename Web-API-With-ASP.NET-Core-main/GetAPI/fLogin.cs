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
        public void login()
        {
            
            string username = txtusername.Text;
            string password = txtpassword.Text;
            string id = txtid.Text;
            Session s = new Session();

            s.id = id;
            
            if (RestClient.PostLogin(username, password) != null)
            {
                var x = RestClient.PostLogin(username, password);
                string a= MessageBox.Show(RestClient.makeJson(x));
                MessageBox.Show(a);


                fLich f = new fLich();
                f.Show();
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
    }
}
