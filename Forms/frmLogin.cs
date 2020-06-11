using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LoginApplication
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.FormClosing += FrmLogin_OnFormClosing;
        }

        private void FrmLogin_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            // If not, app will stay active !!!
            Application.Exit();
        }

        //Connection String
        //string cs = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MyDatabase.mdf;Integrated Security=True;";
        //btn_Submit Click event
        private void btnSubmit_OnClick(object sender, EventArgs e)
        {
            if(txtUserName.Text=="" || txtPassword.Text=="")
            {
                MessageBox.Show("Please provide UserName and Password");
                return;
            }
            try
            {
                //Create SqlConnection
                //If count is equal to 1, than show frmMain form
                if (txtUserName.Text != "" && txtPassword.Text != "")
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();

                    // proveri rolu
                    
                    frmMain fm = new frmMain();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
