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
        DataSet ds = new DataSet();

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                string struser, search;
                if (cmbNoo.SelectedItem == "مدیر")
                {
                    struser = "Admin";
                    cls_variable.stru = "مدیر";
                }
                else
                {
                    struser = "User";
                    cls_variable.stru = "کاربر";
                }

                search = "select IdKarbar from Tbl_karbar where NoeeKarbar='" +struser+ "' AND UserName='"+txtUserName.Text+ "' AND Password='"+txtPassword.Text+"'";
                SqlDataAdapter da = new SqlDataAdapter(search,con);
                da.Fill(ds,"Tbl_karbar");
                if (ds.Tables["Tbl_karbar"].Rows.Count > 0 )
                {
                    new FrmLoading().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBoxFarsi.Show("نام کاربری و رمز عبور اشتباه است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);
                }
                con.Close();

            }
            catch (Exception)
            {
                MessageBoxFarsi.Show(" مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
