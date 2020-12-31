using System;
using System.Windows.Forms;

namespace CSharpRestClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region UI Event Handler
        private void BtnGo_Click(object sender, EventArgs e)
        {
            RestClient rClient = new RestClient();

            rClient.endpoint = TxtUrl.Text;
            debugOutput("RESTClient Object created.");

            string strJSON = string.Empty;

            strJSON = rClient.makeRequest();

            debugOutput(strJSON);
        }
        #endregion

        private void debugOutput(string strDebugText)
        {
            try
            {
                System.Diagnostics.Debug.Write(strDebugText + Environment.NewLine);
                TxtResponse.Text = TxtResponse.Text + strDebugText + Environment.NewLine;
                TxtResponse.SelectionStart = TxtResponse.TextLength;
                TxtResponse.ScrollToCaret();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message, ToString() + Environment.NewLine);
            }
        }
    }

}
