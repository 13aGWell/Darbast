using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BehComponents;


namespace Hesabdari_Darbast
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                cmd = new SqlCommand("select count(*) from Tbl_karbar where UserName=@N And Password=@M", con);
                cmd.Parameters.AddWithValue("@N", txtUserName.Text);
                cmd.Parameters.AddWithValue("@M", txtPassword.Text);
                con.Open();
                i = (int)cmd.ExecuteScalar();

                con.Close();

                if (i > 0)
                {
                    
                    new FrmLoading().ShowDialog();
                    this.Close();


                }
                else
                {
                    
                    MessageBoxFarsi.Show("نام کاربری و رمز عبور اشتباه است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);
                }
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
