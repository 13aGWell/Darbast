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
    public partial class frmMoshtari : Form
    {
        //Changenew
        private readonly bool _isEditMode;
        //Change
        public frmMoshtari(bool isEditMode = false)
        {
            //Change
            _isEditMode = isEditMode;
            InitializeComponent();
            //Change
            buttonX2.Visible = _isEditMode;
        }
        SqlConnection con = new SqlConnection("Data source=EN2\\SQL2019;initial catalog=Hesabdaridb;integrated security=true");
        SqlCommand cmd = new SqlCommand();

        private void frmMoshtari_Load(object sender, EventArgs e)
        {
            txtDore.Items.Add("31");
            txtDore.Items.Add("30");
            txtDore.Items.Add("1");
            txtErtefa.Items.Add("اختلاف");
            txtErtefa.Items.Add("از کل");

        }


        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxX1.Checked == true)
                txtTakhfif.Text = "2";

        }







        private void btnM_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into tbl_Moshtari(StartGH,EndGH,Address,Tozih,NameMoshtari,KodeMeli,Tel,Mobile,Dore,DasradeBast,DarsadeBaz,DarsadeBazoBast,Takhfif,Mabna,M3,M2,Norgir,Chaharpaye,Charkhdar,Asansor,Tavafoghi,SadMetr,NafarRoz,Nokhale,SarSara,Forosh,Divar,Beton,EzafeErtefa)values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s,@t,@u,@v,@w,@x,@y,@z,@aa,@ab,@ac)";
                cmd.Parameters.AddWithValue("@a", txtStart.Text);
                cmd.Parameters.AddWithValue("@b", txtEnd.Text);
                cmd.Parameters.AddWithValue("@c", txtAddress.Text);
                cmd.Parameters.AddWithValue("@d", txtTozihat.Text);
                cmd.Parameters.AddWithValue("@e", txtNameMoshtari.Text);
                cmd.Parameters.AddWithValue("@f", txtKodeMeli.Text);
                cmd.Parameters.AddWithValue("@g", txtTel.Text);
                cmd.Parameters.AddWithValue("@h", txtMobile.Text);
                cmd.Parameters.AddWithValue("@i", txtDore.Text);
                cmd.Parameters.AddWithValue("@j", txtBastan.Text);
                cmd.Parameters.AddWithValue("@k", txtBaz.Text);
                cmd.Parameters.AddWithValue("@l", txtBazoBast.Text);
                cmd.Parameters.AddWithValue("@m", txtTakhfif.Text);
                cmd.Parameters.AddWithValue("@n", txtErtefa.Text);
                cmd.Parameters.AddWithValue("@o", txtm3.Text);
                cmd.Parameters.AddWithValue("@p", txtm2.Text);
                cmd.Parameters.AddWithValue("@q", txtNorgir.Text);
                cmd.Parameters.AddWithValue("@r", txt4paye.Text);
                cmd.Parameters.AddWithValue("@s", txtCharkhdar.Text);
                cmd.Parameters.AddWithValue("@t", txtAsansor.Text);
                cmd.Parameters.AddWithValue("@u", txtTavafoghi.Text);
                cmd.Parameters.AddWithValue("@v", txt100.Text);
                cmd.Parameters.AddWithValue("@w", txtNafarRoz.Text);
                cmd.Parameters.AddWithValue("@x", txtNokhale.Text);
                cmd.Parameters.AddWithValue("@y", txtsarsara.Text);
                cmd.Parameters.AddWithValue("@z", txtForosh.Text);
                cmd.Parameters.AddWithValue("@aa", txtDivar.Text);
                cmd.Parameters.AddWithValue("@ab", txtBeton.Text);
                cmd.Parameters.AddWithValue("@ac", txtMazadErtefa.Text);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
            catch (Exception)
            {

                MessageBoxFarsi.Show("اطلاعات عددی را به صورت عدد وارد نمایید", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

        }

        private void txtm3_Leave(object sender, EventArgs e)
        {

        }

        private void txtm3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNameMoshtari_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            new frmNamayesheMoshtari().ShowDialog();

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd.Connection = con;
                cmd.Parameters.Clear();
                cmd.CommandText = "update tbl_Moshtari set NameMoshtari='" + txtNameMoshtari.Text + "',KodeMeli='" + txtKodeMeli.Text + "',Tel='" + txtTel.Text + "',Mobile='" + txtMobile.Text + "',Address='" + txtAddress.Text + "',StartGH='" + txtStart.Text + "',EndGH='" + txtEnd.Text + "',Tozih='" + txtTozihat.Text + "',Dore='" + txtDore.Text + "',DasradeBast='" + txtBastan.Text + "',DarsadeBaz='" + txtBaz.Text + "',DarsadeBazoBast='" + txtBazoBast.Text + "',Takhfif='" + txtTakhfif.Text + "',Mabna='" + txtErtefa.Text + "',M3='" + txtm3.Text + "',M2='" + txtm2.Text + "',Norgir='" + txtNorgir.Text + "',Chaharpaye='" + txt4paye.Text + "',Charkhdar='" + txtCharkhdar.Text + "',Asansor='" + txtAsansor.Text + "',Tavafoghi='" + txtTavafoghi.Text + "',SadMetr='" + txt100.Text + "',Nokhale='" + txtNokhale.Text + "',NafarRoz='" + txtNafarRoz.Text + "',SarSara='" + txtsarsara.Text + "',Forosh='" + txtForosh.Text + "',Divar='" + txtDivar.Text + "',Beton='" + txtBeton.Text + "',EzafeErtefa='" + txtMazadErtefa.Text + "' where IdMoshtari= " + txtId.Text;

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBoxFarsi.Show("اطلاعات با موفقیت ثبت شد", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
                this.Close();
                new frmNamayesheMoshtari().ShowDialog();
            }
            catch (Exception)
            {

                MessageBoxFarsi.Show("لطفا اطلاعات را صحیح وارد نمایید", "پیغام", MessageBoxFarsiButtons.OK, MessageBoxFarsiIcon.Information, MessageBoxFarsiDefaultButton.Button1);
            }
        }
    }
}

