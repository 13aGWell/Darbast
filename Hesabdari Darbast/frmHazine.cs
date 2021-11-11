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
    public partial class frmHazine : Form
    {
        public frmHazine()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        void Display1()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_SabteNameHazine";
            adp.Fill(ds, "tbl_SabteNameHazine");
            dgvNoeHazine.DataSource = ds;
            dgvNoeHazine.DataMember = "tbl_SabteNameHazine";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtStart_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtEnd_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnSaveHazine_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into tbl_SabteNameHazine(AddHazine)values(@A)";
                cmd.Parameters.AddWithValue("@A", txtaddhazine.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                txtaddhazine.Text = "";
                Display1();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void frmHazine_Load(object sender, EventArgs e)
        {
            Display1();
            dgvNoeHazine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNoeHazine.Columns[0].HeaderText = " کد هزینه";
            dgvNoeHazine.Columns[0].Width = 90;
            dgvNoeHazine.Columns[1].HeaderText = "نام هزینه ";
            dgvNoeHazine.Columns[1].Width = 230;
            buttonX1.Visible = false;
        }

        private void dgvNoeHazine_MouseUp(object sender, MouseEventArgs e)
        {
            txtidhazine.Text = dgvNoeHazine[0, dgvNoeHazine.CurrentRow.Index].Value.ToString();
            txtaddhazine.Text = dgvNoeHazine[1, dgvNoeHazine.CurrentRow.Index].Value.ToString();
            if (txtidhazine.Text != "")
                btnSaveHazine.Visible = false;
            buttonX1.Visible = true;


            {

            }
        }



        private void btnDeletHazine_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvNoeHazine.SelectedCells[0].Value);
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Delete from tbl_SabteNameHazine Where IdHazine=@N";
                cmd.Parameters.AddWithValue("@N", txtidhazine.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("حذف با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display1();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnEditHazine_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "update tbl_SabteNameHazine set AddHazine='" + txtaddhazine.Text + "' where IdHazine =" +txtidhazine.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ویرایش شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display1();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void dgvNoeHazine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtHazine.Text = dgvNoeHazine.CurrentRow.Cells[1].Value.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txtidhazine.Text = "";
            txtaddhazine.Text = "";
            buttonX1.Visible = false;
            btnSaveHazine.Visible = true;

        }
    }
}
