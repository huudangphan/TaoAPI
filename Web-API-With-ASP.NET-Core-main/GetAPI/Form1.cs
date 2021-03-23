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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RestClient rCient = new RestClient();
            rCient.endPoint = txtUrl.Text;
            debugOutput("RestClient created");
            string strResponse = string.Empty;
            strResponse = rCient.makeRequest();
            debugOutput(strResponse);

        }
        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                txtReply.Text = txtReply.Text + strDebugText + Environment.NewLine;
                txtReply.SelectionStart = txtReply.TextLength;
                txtReply.ScrollToCaret();
                    
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }
}
