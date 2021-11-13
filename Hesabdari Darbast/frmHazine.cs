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
        void Display2()
        {

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Hazine";
            adp.Fill(ds, "tbl_Hazine");
            dgvNamayesheHazine.DataSource = ds;
            dgvNamayesheHazine.DataMember = "tbl_Hazine";
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
            buttonX2.Visible = false;
            Display2();
            dgvNamayesheHazine.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNamayesheHazine.Columns[0].HeaderText = "سند";
            dgvNamayesheHazine.Columns[0].Width = 90;
            dgvNamayesheHazine.Columns[1].HeaderText = "حساب پرداختنی  ";
            dgvNamayesheHazine.Columns[1].Width = 120;
            dgvNamayesheHazine.Columns[2].HeaderText = " نوع هزینه ";
            dgvNamayesheHazine.Columns[2].Width = 120;
            dgvNamayesheHazine.Columns[3].HeaderText = "تاریخ  ";
            dgvNamayesheHazine.Columns[3].Width = 120;
            dgvNamayesheHazine.Columns[4].HeaderText = " قیمت(ریال) ";
            dgvNamayesheHazine.Columns[4].Width = 120;
            dgvNamayesheHazine.Columns[5].HeaderText = "توضیحات  ";
            dgvNamayesheHazine.Columns[5].Width = 170;

        }

        private void dgvNoeHazine_MouseUp(object sender, MouseEventArgs e)
        {
            txtidhazine.Text = dgvNoeHazine[0, dgvNoeHazine.CurrentRow.Index].Value.ToString();
            txtaddhazine.Text = dgvNoeHazine[1, dgvNoeHazine.CurrentRow.Index].Value.ToString();
            if (txtidhazine.Text != "")
                btnSaveHazine.Visible = false;
            buttonX1.Visible = true;



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
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            txtidhazine.Text = "";
            txtaddhazine.Text = "";
            buttonX1.Visible = false;
            btnSaveHazine.Visible = true;

        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_SabteNameHazine where AddHazine Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtsearch.Text + "%");
            adp.Fill(ds, "tbl_SabteNameHazine");
            dgvNoeHazine.DataSource = ds;
            dgvNoeHazine.DataMember = "tbl_SabteNameHazine";
        }

        private void txtaddhazine_TextChanged(object sender, EventArgs e)
        {
            txtHazine.Text = txtaddhazine.Text;
        }

        private void btnAddHesab_Click(object sender, EventArgs e)
        {
            frmShomareHesab frm = new frmShomareHesab();
            frm.ShowDialog();



        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {

                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into tbl_Hazine(Hesab,NoeHazine,Tarikh,Gheymat,Tozihat)values(@a,@b,@c,@d,@e)";
                cmd.Parameters.AddWithValue("@a", txtPardakht.Text);
                cmd.Parameters.AddWithValue("@b", txtHazine.Text);
                cmd.Parameters.AddWithValue("@c", txtTarikh.Text);
                cmd.Parameters.AddWithValue("@d", txtMablagh.Text);
                cmd.Parameters.AddWithValue("@e", txtTozihat.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                txtPardakht.Text = "";
                txtHazine.Text = "";
                txtTarikh.Text = "";
                txtMablagh.Text = "";
                txtTozihat.Text = "";

                Display2();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show(" مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvNamayesheHazine.SelectedCells[0].Value);
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Delete from tbl_Hazine Where IdHazine=@N";
                cmd.Parameters.AddWithValue("@N", txtSanad.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("حذف با موفقیت انجام شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display2();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void dgvNamayesheHazine_MouseUp(object sender, MouseEventArgs e)
        {
            txtSanad.Text = dgvNamayesheHazine[0, dgvNamayesheHazine.CurrentRow.Index].Value.ToString();
            txtPardakht.Text = dgvNamayesheHazine[1, dgvNamayesheHazine.CurrentRow.Index].Value.ToString();
            txtHazine.Text = dgvNamayesheHazine[2, dgvNamayesheHazine.CurrentRow.Index].Value.ToString();
            txtTarikh.Text = dgvNamayesheHazine[3, dgvNamayesheHazine.CurrentRow.Index].Value.ToString();
            txtMablagh.Text = dgvNamayesheHazine[4, dgvNamayesheHazine.CurrentRow.Index].Value.ToString();
            txtTozihat.Text = dgvNamayesheHazine[5, dgvNamayesheHazine.CurrentRow.Index].Value.ToString();
            BtnSave.Visible = false;
            buttonX2.Visible = true;

        }

        private void btnVirayesh_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "update tbl_Hazine set Hesab='" + txtPardakht.Text + "',NoeHazine='" + txtHazine.Text + "',Tarikh='" + txtTarikh.Text + "',Gheymat='" + txtMablagh.Text + "',Tozihat='" + txtTozihat.Text + "' where IdHazine =" + txtSanad.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ویرایش شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display2();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

        private void dgvNamayesheHazine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            txtPardakht.Text = "";
            txtHazine.Text = "";
            txtTarikh.Text = "";
            txtMablagh.Text = "";
            txtTozihat.Text = "";
            txtTarikh.Focus();
            BtnSave.Visible = true;
            buttonX2.Visible = false;


        }
    }
}
