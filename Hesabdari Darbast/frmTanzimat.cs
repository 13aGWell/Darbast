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
    public partial class frmTanzimat : Form
    {
        public frmTanzimat()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd= new SqlCommand();

        void Display()
        {

            DataSet ds= new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from Tbl_tanzimat";
            adp.Fill(ds, "Tbl_tanzimat");
            dgvTanzimat.DataSource = ds;
            dgvTanzimat.DataMember = "Tbl_tanzimat";

        }



        private void frmTanzimat_Load(object sender, EventArgs e)
        {
            Display();
            dgvTanzimat.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTanzimat.Columns[0].HeaderText = "کد ";
            dgvTanzimat.Columns[1].HeaderText = "نام مجموعه";
            dgvTanzimat.Columns[2].HeaderText = "تلفن ثابت";
            dgvTanzimat.Columns[3].HeaderText = "تلفن همراه";
            dgvTanzimat.Columns[4].HeaderText = "آدرس";
            dgvTanzimat.Columns[5].HeaderText = "توضیحات";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into Tbl_tanzimat(Nameforoshgah,tel,Mobile,Address,tozihat)values(@a,@b,@c,@d,@e)";
                cmd.Parameters.AddWithValue("@a", txtNamefroshgah.Text);
                cmd.Parameters.AddWithValue("@b", txtTel.Text);
                cmd.Parameters.AddWithValue("@c", txtMobile.Text);
                cmd.Parameters.AddWithValue("@d", txtAddress.Text);
                cmd.Parameters.AddWithValue("@e", txtTozihat.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display();
            }
            catch (Exception)
            {

                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);
            }


        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvTanzimat_MouseUp(object sender, MouseEventArgs e)
        {
            txtId.Text = dgvTanzimat[0, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtNamefroshgah.Text = dgvTanzimat[1, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtTel.Text = dgvTanzimat[2, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtMobile.Text = dgvTanzimat[3, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtAddress.Text = dgvTanzimat[4, dgvTanzimat.CurrentRow.Index].Value.ToString();
            txtTozihat.Text = dgvTanzimat[5, dgvTanzimat.CurrentRow.Index].Value.ToString();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvTanzimat.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "delete from Tbl_tanzimat where IdTanzimat=@N";
                cmd.Parameters.AddWithValue("@N", txtId.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت حذف شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);

            }


        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "update Tbl_tanzimat set Nameforoshgah='" + txtNamefroshgah.Text + "',tel='" + txtTel.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtAddress.Text + "',tozihat='" + txtTozihat.Text + "' where IdTanzimat=" + txtId.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ویرایش شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }


        }
    }
}
