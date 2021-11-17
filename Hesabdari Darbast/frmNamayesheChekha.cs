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
    public partial class frmNamayesheChekha : Form
    {
        public frmNamayesheChekha()
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
            dgvNamayesheChekha.DataSource = ds;
            dgvNamayesheChekha.DataMember = "tbl_Chek";
        }

        private void frmNamayesheChekha_Load(object sender, EventArgs e)
        {
            Display();
            dgvNamayesheChekha.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvNamayesheChekha.Columns[0].HeaderText = "شماره رسید";
            dgvNamayesheChekha.Columns[0].Width = 90;
            dgvNamayesheChekha.Columns[1].HeaderText = "تاریخ صدور";
            dgvNamayesheChekha.Columns[1].Width = 90;
            dgvNamayesheChekha.Columns[2].HeaderText = "ماهیت";
            dgvNamayesheChekha.Columns[2].Width = 90;
            dgvNamayesheChekha.Columns[3].HeaderText = "تاریخ سر رسید";
            dgvNamayesheChekha.Columns[3].Width = 90;
            dgvNamayesheChekha.Columns[4].HeaderText = "مبلغ(ريال)";
            dgvNamayesheChekha.Columns[4].Width = 90;
            dgvNamayesheChekha.Columns[5].HeaderText = "شماره چک";
            dgvNamayesheChekha.Columns[5].Width = 90;
            dgvNamayesheChekha.Columns[6].HeaderText = "گیرنده";
            dgvNamayesheChekha.Columns[6].Width = 90;
            dgvNamayesheChekha.Columns[7].HeaderText = "وضعیت";
            dgvNamayesheChekha.Columns[7].Width = 90;
            dgvNamayesheChekha.Columns[8].HeaderText = "بانک";
            dgvNamayesheChekha.Columns[8].Width = 90;
            dgvNamayesheChekha.Columns[9].HeaderText = "در وجه";
            dgvNamayesheChekha.Columns[9].Width = 90;
            dgvNamayesheChekha.Columns[10].HeaderText = "ثبت صیاد";
            dgvNamayesheChekha.Columns[10].Width = 90;
            dgvNamayesheChekha.Columns[11].HeaderText = "بابت";
            dgvNamayesheChekha.Columns[11].Width = 200;

        }

        private void btnVirayeshChek_Click(object sender, EventArgs e)
        {
            frmSabtechek frm = new frmSabtechek(true);
            frm.txtIdChek.Text = dgvNamayesheChekha[0, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtTarikheSodor.Text = dgvNamayesheChekha[1, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.cmbMahiyat.Text = dgvNamayesheChekha[2, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtTarikheSarResid.Text = dgvNamayesheChekha[3, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtMablaghChek.Text = dgvNamayesheChekha[4, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtShomareChek.Text = dgvNamayesheChekha[5, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtGirandeChek.Text = dgvNamayesheChekha[6, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.cmbVaziyat.Text = dgvNamayesheChekha[7, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtBank.Text = dgvNamayesheChekha[8, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtDarVajh.Text = dgvNamayesheChekha[9, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.cmbSayad.Text = dgvNamayesheChekha[10, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.txtBabat.Text = dgvNamayesheChekha[11, dgvNamayesheChekha.CurrentRow.Index].Value.ToString();
            frm.BtnSaveChek.Enabled = false;
            frm.ShowDialog();
            this.Close();


        }
    }
}
