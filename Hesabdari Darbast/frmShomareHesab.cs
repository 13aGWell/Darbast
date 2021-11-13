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
    public partial class frmShomareHesab : Form
    {
        public frmShomareHesab()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_ShomareHesab";
            adp.Fill(ds, "tbl_ShomareHesab");
            dgvHesab.DataSource = ds;
            dgvHesab.DataMember = "tbl_ShomareHesab";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into tbl_ShomareHesab(ShomareHesab,TozihateHesab)values(@A,@B)";
                cmd.Parameters.AddWithValue("@A", txtShomareHesab.Text);
                cmd.Parameters.AddWithValue("@B", txtTozihateHesab.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                txtShomareHesab.Text = "";
                txtTozihateHesab.Text = "";
                Display();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void frmShomareHesab_Load(object sender, EventArgs e)
        {
            Display();
            dgvHesab.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHesab.Columns[0].HeaderText = "کد حساب";
            dgvHesab.Columns[0].Width = 70;
            dgvHesab.Columns[1].HeaderText = "شماره حساب";
            dgvHesab.Columns[1].Width = 130;
            dgvHesab.Columns[2].HeaderText = "توضیحات";
            dgvHesab.Columns[2].Width = 190;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvHesab.SelectedCells[0].Value);
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Delete from tbl_ShomareHesab Where IdHesab=@N";
                cmd.Parameters.AddWithValue("@N", txtIdHesab.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("حذف با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void dgvHesab_MouseUp(object sender, MouseEventArgs e)
        {
            txtIdHesab.Text = dgvHesab[0, dgvHesab.CurrentRow.Index].Value.ToString();
        }
    }
    }





