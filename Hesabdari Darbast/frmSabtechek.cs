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
    public partial class frmSabtechek : Form
    {

      private readonly bool _isEditMode;

    public frmSabtechek(bool isEditMode = false)
     {

      _isEditMode = isEditMode;
      InitializeComponent();
 
       BtnSaveChek.Visible = _isEditMode;
     }

            public frmSabtechek()
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
            adp.SelectCommand.CommandText = "select * from tbl_Chek";
            adp.Fill(ds, "tbl_Chek");
            dgvChek.DataSource = ds;
            dgvChek.DataMember = "tbl_Chek";

        }
        private void BtnSaveChek_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into tbl_Chek(TarikheSodor,Mahiyat,TarikheSarResid,Mablagh,ShomareChek,Girande,Vaziyat,Bank,Darvajhe,Sayad,Babat)values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k)";
                cmd.Parameters.AddWithValue("@a", txtTarikheSodor.Text);
                cmd.Parameters.AddWithValue("@b", cmbMahiyat.Text);
                cmd.Parameters.AddWithValue("@c", txtTarikheSarResid.Text);
                cmd.Parameters.AddWithValue("@d", txtMablaghChek.Text);
                cmd.Parameters.AddWithValue("@e", txtShomareChek.Text);
                cmd.Parameters.AddWithValue("@f", txtGirandeChek.Text);
                cmd.Parameters.AddWithValue("@g", cmbVaziyat.Text);
                cmd.Parameters.AddWithValue("@h", txtBank.Text);
                cmd.Parameters.AddWithValue("@i", txtDarVajh.Text);
                cmd.Parameters.AddWithValue("@j", cmbSayad.Text);
                cmd.Parameters.AddWithValue("@k", txtBabat.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                btnChekJadid.Visible = true;
                BtnSaveChek.Visible = false;
                dgvChek.Enabled = true;
                txtTarikheSodor.Text = "";
                cmbMahiyat.Text = "";
                txtTarikheSarResid.Text = "";
                txtMablaghChek.Text = "";
                txtShomareChek.Text = "";
                txtGirandeChek.Text = "";
                cmbVaziyat.Text = "";
                txtBank.Text = "";
                txtDarVajh.Text = "";
                cmbSayad.Text = "";
                txtBabat.Text = "";
                Display();

            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Warning, MessageBoxFarsiDefaultButton.Button1);
            }

        }

        private void frmSabtechek_Load(object sender, EventArgs e)
        {
            if (txtIdChek.Text == "")
            {
                btnVirayeshChek.Visible = false;
            }
            btnChekJadid.Visible = false;
            Display();
            dgvChek.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChek.Columns[0].HeaderText = "شماره رسید";
            dgvChek.Columns[0].Width = 90;
            dgvChek.Columns[1].HeaderText = "تاریخ صدور";
            dgvChek.Columns[1].Width = 90;
            dgvChek.Columns[2].HeaderText = "ماهیت";
            dgvChek.Columns[2].Width = 90;
            dgvChek.Columns[3].HeaderText = "تاریخ سر رسید";
            dgvChek.Columns[3].Width = 90;
            dgvChek.Columns[4].HeaderText = "مبلغ(ريال)";
            dgvChek.Columns[4].Width = 90;
            dgvChek.Columns[5].HeaderText = "شماره چک";
            dgvChek.Columns[5].Width = 90;
            dgvChek.Columns[6].HeaderText = "گیرنده";
            dgvChek.Columns[6].Width = 90;
            dgvChek.Columns[7].HeaderText = "وضعیت";
            dgvChek.Columns[7].Width = 90;
            dgvChek.Columns[8].HeaderText = "بانک";
            dgvChek.Columns[8].Width = 90;
            dgvChek.Columns[9].HeaderText = "در وجه";
            dgvChek.Columns[9].Width = 90;
            dgvChek.Columns[10].HeaderText = "ثبت صیاد";
            dgvChek.Columns[10].Width = 90;
            dgvChek.Columns[11].HeaderText = "بابت";
            dgvChek.Columns[11].Width = 200;
        }
        private void btnChekJadid_Click(object sender, EventArgs e)
        {
            dgvChek.Enabled = false;
            txtTarikheSodor.Text = "";
            cmbMahiyat.Text = "";
            txtTarikheSarResid.Text = "";
            txtMablaghChek.Text = "";
            txtShomareChek.Text = "";
            txtGirandeChek.Text = "";
            cmbVaziyat.Text = "";
            txtBank.Text = "";
            txtDarVajh.Text = "";
            cmbSayad.Text = "";
            txtBabat.Text = "";
            BtnSaveChek.Enabled = true;
            btnChekJadid.Visible = false;
        }
        private void txtSearchTarikh_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Chek where TarikheSarResid Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtSearchTarikh.Text + "%");
            adp.Fill(ds, "tbl_Chek");
            dgvChek.DataSource = ds;
            dgvChek.DataMember = "tbl_Chek";
        }

        private void txtSearchVaziyat_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Chek where Vaziyat Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtSearchVaziyat.Text + "%");
            adp.Fill(ds, "tbl_Chek");
            dgvChek.DataSource = ds;
            dgvChek.DataMember = "tbl_Chek";
        }
        private void txtSearcheBabat_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Chek where Babat Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtSearcheBabat.Text + "%");
            adp.Fill(ds, "tbl_Chek");
            dgvChek.DataSource = ds;
            dgvChek.DataMember = "tbl_Chek";
        }
        private void dgvChek_MouseMove(object sender, MouseEventArgs e)
        {
            txtIdChek.Text = dgvChek[0, dgvChek.CurrentRow.Index].Value.ToString();
            txtTarikheSodor.Text = dgvChek[1, dgvChek.CurrentRow.Index].Value.ToString();
            cmbMahiyat.Text = dgvChek[2, dgvChek.CurrentRow.Index].Value.ToString();
            txtTarikheSarResid.Text = dgvChek[3, dgvChek.CurrentRow.Index].Value.ToString();
            txtMablaghChek.Text = dgvChek[4, dgvChek.CurrentRow.Index].Value.ToString();
            txtShomareChek.Text = dgvChek[5, dgvChek.CurrentRow.Index].Value.ToString();
            txtGirandeChek.Text = dgvChek[6, dgvChek.CurrentRow.Index].Value.ToString();
            cmbVaziyat.Text = dgvChek[7, dgvChek.CurrentRow.Index].Value.ToString();
            txtBank.Text = dgvChek[8, dgvChek.CurrentRow.Index].Value.ToString();
            txtDarVajh.Text = dgvChek[9, dgvChek.CurrentRow.Index].Value.ToString();
            cmbSayad.Text = dgvChek[10, dgvChek.CurrentRow.Index].Value.ToString();
            txtBabat.Text = dgvChek[11, dgvChek.CurrentRow.Index].Value.ToString();
            BtnSaveChek.Enabled = false;
            btnChekJadid.Visible = true;
        }
        private void btnDeleteCheck_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvChek.SelectedCells[0].Value);
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "Delete from tbl_Chek Where IdChek=@N";
                cmd.Parameters.AddWithValue("@N", txtIdChek.Text);
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

        private void txtSearchShomareResid_TextChanged_1(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Chek where IdChek Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtSearchShomareResid.Text + "%");
            adp.Fill(ds, "tbl_Chek");
            dgvChek.DataSource = ds;
            dgvChek.DataMember = "tbl_Chek";
        }

        private void btnShowChek_Click(object sender, EventArgs e)
        {
            new frmNamayesheChekha().ShowDialog();

        }

        private void btnVirayeshChek_Click_1(object sender, EventArgs e)
        {
            try
            {

                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "update tbl_Chek set TarikheSodor='" + txtTarikheSarResid.Text + "',Mahiyat='" + cmbMahiyat.Text + "',TarikheSarResid='" + txtTarikheSarResid.Text + "',Mablagh='" + txtMablaghChek.Text + "',ShomareChek='" + txtShomareChek.Text + "',Girande='" + txtGirandeChek.Text + "',Vaziyat='" + cmbVaziyat.Text + "',Bank='" + txtBank.Text + "',Darvajhe='" + txtDarVajh.Text + "',Sayad='" + cmbSayad.Text + "',Babat='" + txtBabat.Text + "' where IdChek =" + txtIdChek.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ویرایش شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display();
                txtTarikheSodor.Text = "";
                cmbMahiyat.Text = "";
                txtTarikheSarResid.Text = "";
                txtMablaghChek.Text = "";
                txtShomareChek.Text = "";
                txtGirandeChek.Text = "";
                cmbVaziyat.Text = "";
                txtBank.Text = "";
                txtDarVajh.Text = "";
                cmbSayad.Text = "";
                txtBabat.Text = "";
                this.Close();
            }
            catch (Exception)
            {
                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);

            }
        }

    }
}
