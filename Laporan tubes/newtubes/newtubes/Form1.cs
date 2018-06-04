using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newtubes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Minimized;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            motor tampil = new motor();
            tampil.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            barang tampil = new barang();
            tampil.Show();
            this.Hide();
           
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            surat tampil = new surat();
            tampil.Show();
            this.Hide();

           
        }

        private void btbyrmtr_Click(object sender, EventArgs e)
        {
           
        }

        private void btbyrbrg_Click(object sender, EventArgs e)
        {
            
        }

        private void btbyrsrt_Click(object sender, EventArgs e)
        {

        }

        private void btctmtr_Click(object sender, EventArgs e)
        {
            

        }

        private void btctkbrg_Click(object sender, EventArgs e)
        {
            
        }

        private void btctksrt_Click(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
