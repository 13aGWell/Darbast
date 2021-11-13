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
    public partial class frmNamayesheMoshtari : Form
    {
        public frmNamayesheMoshtari()
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
            adp.SelectCommand.CommandText = "select * from tbl_Moshtari";
            adp.Fill(ds, "tbl_Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "tbl_Moshtari";
        }
        private void frmNamayesheMoshtari_Load(object sender, EventArgs e)
        {
            Display();
            dgvMoshtari.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMoshtari.Columns[0].HeaderText = "شماره قرارداد";
            dgvMoshtari.Columns[1].HeaderText = "نام شرکت / شخص";
            dgvMoshtari.Columns[1].Width = 150;
            dgvMoshtari.Columns[2].HeaderText = "کدملی / اقتصادی";
            dgvMoshtari.Columns[2].Width = 150;
            dgvMoshtari.Columns[3].HeaderText = "شماره تماس 1";
            dgvMoshtari.Columns[4].HeaderText = "شماره تماس 2";
            dgvMoshtari.Columns[5].HeaderText = "آدرس";
            dgvMoshtari.Columns[5].Width = 200;
            dgvMoshtari.Columns[6].HeaderText = "تاریخ تنظیم قرارداد";
            dgvMoshtari.Columns[7].HeaderText = "تاریخ اتمام قرارداد";
            dgvMoshtari.Columns[8].HeaderText = "توضیحات";
            dgvMoshtari.Columns[8].Width = 200;
            dgvMoshtari.Columns[9].HeaderText = "دوره";
            dgvMoshtari.Columns[10].HeaderText = "درصد بستن";
            dgvMoshtari.Columns[11].HeaderText = "درصد باز کردن";
            dgvMoshtari.Columns[12].HeaderText = "درصد بستن و باز کردن";
            dgvMoshtari.Columns[13].HeaderText = "تخفیف";
            dgvMoshtari.Columns[14].HeaderText = "مبنا ارتفاع";
            dgvMoshtari.Columns[15].HeaderText = "هر متر مکعب";
            dgvMoshtari.Columns[16].HeaderText = "هر متر مربع";
            dgvMoshtari.Columns[17].HeaderText = "هر طبقه نورگیر";
            dgvMoshtari.Columns[18].HeaderText = "چهارپایه";
            dgvMoshtari.Columns[19].HeaderText = "چهارپایه چرخ دار";
            dgvMoshtari.Columns[20].HeaderText = "هر طبقه چاله آسانسور";
            dgvMoshtari.Columns[21].HeaderText = "داربست توافقی";
            dgvMoshtari.Columns[22].HeaderText = "حداقل 100متر";
            dgvMoshtari.Columns[23].HeaderText = "کفراژ نخاله";
            dgvMoshtari.Columns[24].HeaderText = "دستمزد هر نفر روز";
            dgvMoshtari.Columns[25].HeaderText = "سرسرا";
            dgvMoshtari.Columns[26].HeaderText = "فروش / کرایه";
            dgvMoshtari.Columns[27].HeaderText = "دیوار برشی";
            dgvMoshtari.Columns[28].HeaderText = "بتن ریزی";
            dgvMoshtari.Columns[29].HeaderText = "مبلغ اضافه ارتفاع";

        }

        private void dgvMoshtari_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int x = Convert.ToInt32(dgvMoshtari.SelectedCells[0].Value);
                cmd.Parameters.Clear();
                cmd.Connection = con;
                cmd.CommandText = "delete from tbl_Moshtari where IdMoshtari=@N";
                cmd.Parameters.AddWithValue("@N", ID.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت حذف شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                Display();

            }
            catch (Exception)
            {

                MessageBoxFarsi.Show("مشکلی رخ داده است", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
        }

        private void dgvMoshtari_MouseUp(object sender, MouseEventArgs e)
        {
            ID.Text = dgvMoshtari[0, dgvMoshtari.CurrentRow.Index].Value.ToString();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //Change
            frmMoshtari frm = new frmMoshtari(true);
            frm.txtId.Text = dgvMoshtari[0, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtNameMoshtari.Text = dgvMoshtari[1, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtKodeMeli.Text = dgvMoshtari[2, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtTel.Text = dgvMoshtari[3, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtMobile.Text = dgvMoshtari[4, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtAddress.Text = dgvMoshtari[5, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtStart.Text = dgvMoshtari[6, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtEnd.Text = dgvMoshtari[7, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtTozihat.Text = dgvMoshtari[8, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtDore.Text = dgvMoshtari[9, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtBastan.Text = dgvMoshtari[10, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtBaz.Text = dgvMoshtari[11, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtBazoBast.Text = dgvMoshtari[12, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtTakhfif.Text = dgvMoshtari[13, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtErtefa.Text = dgvMoshtari[14, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtm3.Text = dgvMoshtari[15, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtm2.Text = dgvMoshtari[16, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtNorgir.Text = dgvMoshtari[17, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txt4paye.Text = dgvMoshtari[18, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtCharkhdar.Text = dgvMoshtari[19, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtAsansor.Text = dgvMoshtari[20, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtTavafoghi.Text = dgvMoshtari[21, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txt100.Text = dgvMoshtari[22, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtNokhale.Text = dgvMoshtari[23, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtNafarRoz.Text = dgvMoshtari[24, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtsarsara.Text = dgvMoshtari[25, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtForosh.Text = dgvMoshtari[26, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtDivar.Text = dgvMoshtari[27, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtBeton.Text = dgvMoshtari[28, dgvMoshtari.CurrentRow.Index].Value.ToString();
            frm.txtMazadErtefa.Text = dgvMoshtari[29, dgvMoshtari.CurrentRow.Index].Value.ToString();
            this.Close();
            frm.ShowDialog();
            frm.buttonX2.Visible = false;
            this.Close();
        }

        private void txtIdmoshtari_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Moshtari where IdMoshtari Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtIdmoshtari.Text + "%");
            adp.Fill(ds, "tbl_Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "tbl_Moshtari";

        }

        private void txtNameMoshtari_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Moshtari where NameMoshtari Like '%' + @S + '%'";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtNameMoshtari.Text + "%");
            adp.Fill(ds, "tbl_Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "tbl_Moshtari";
        }

        private void txtMoileMoshtari_TextChanged(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.SelectCommand = new SqlCommand();
            adp.SelectCommand.Connection = con;
            adp.SelectCommand.CommandText = "select * from tbl_Moshtari where Tel Like '%' + @S + '%' or Mobile Like '%' + @S + '%' ";
            adp.SelectCommand.Parameters.AddWithValue("@S", txtMoileMoshtari.Text + "%");
            adp.Fill(ds, "tbl_Moshtari");
            dgvMoshtari.DataSource = ds;
            dgvMoshtari.DataMember = "tbl_Moshtari";
        }
    }
}
