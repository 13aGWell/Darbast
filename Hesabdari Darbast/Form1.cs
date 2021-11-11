using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hesabdari_Darbast
{

    
    
    /// Testy Taghirat masaln inja kheili taghiiiiirat khoobi ijad kardi m alan mikhaym sabt konim
    /// taghire 2
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTanzimat_Click(object sender, EventArgs e)
        {

        }

        private void btnTanzimat_Click_1(object sender, EventArgs e)
        {
            new frmTanzimat().ShowDialog();

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            new frmKarbar().ShowDialog();
            
        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnTanzimat_Click_2(object sender, EventArgs e)
        {

        }

        private void btnTanzimat_Click_3(object sender, EventArgs e)
        {
            new frmTanzimat().ShowDialog();
        }

        private void buttonX1_Click_1(object sender, EventArgs e)
        {
            new frmKarbar().ShowDialog();
        }

        private void ribbonTabItem3_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            //Change
            new frmMoshtari(false).ShowDialog();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            new frmHazine().ShowDialog();
        }
    }
}
