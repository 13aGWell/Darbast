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
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cp1.Value += 10;
            cp2.Value += 10;

            if(cp1.Value==30 & cp2.Value==30 )
            {
                timer1.Stop();
                new Form1().ShowDialog();
                this.Close();
            }



        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
