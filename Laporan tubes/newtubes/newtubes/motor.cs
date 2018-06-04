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

namespace newtubes
{
    public partial class motor : Form
    {
        public motor()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-SUM094B\SQLEXPRESS;Initial Catalog=Transaksi;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bttampil_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "SELECT * FROM motor";
            SqlDataAdapter baru1 = new SqlDataAdapter(query, con);
            DataTable br1 = new DataTable();
            baru1.Fill(br1);
            dataGridView1.DataSource = br1;
            con.Close();
        }

        private void btubah_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE motor SET tujuan='" + cbtujuan.Text + "',asal='" + cbasal.Text + "',pengirim='" + textpengirim.Text + "',penerima='" + textpenerima.Text + "',notlprim='" + texttlprim.Text + "',notlpma='" + texttlpma.Text + "',jns_mtr='" + cbmotor.Text + "',total_bayar='" + texttotal.Text + "' WHERE id_mtr ='"+textidmotor.Text+"'";
            SqlDataAdapter baru1 = new SqlDataAdapter(query, con);
            baru1.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("BERHASIL DI UBAH");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textidmotor.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cbtujuan.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cbasal.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textpengirim.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textpenerima.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            texttlprim.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            texttlpma.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cbmotor.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            texttotal.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();


        }

        private void btbyrmtr_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO motor(id_mtr,tujuan, asal, pengirim, penerima, notlprim, notlpma, jns_mtr,total_bayar) VALUES ('" + textidmotor.Text + "','" + cbtujuan.Text + "','" + cbasal.Text + "','" + textpengirim.Text + "','" + textpenerima.Text + "','" + texttlprim.Text + "','" + texttlpma.Text + "','" + cbmotor.Text + "','" + texttotal.Text + "') ";
            SqlDataAdapter baru1 = new SqlDataAdapter(query, con);
            baru1.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERT SUCCESS!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbmotor.Text == "Moge")
            {
                texttotal.Text = (1000000).ToString();
            }
            else if (cbmotor.Text == "Bebek")
            {
                texttotal.Text = (650000).ToString();
            }
            else if (cbmotor.Text == "Sekutik")
            {
                texttotal.Text = (800000).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 kembali = new Form1();
            kembali.Show();
            this.Hide();
        }

        private void bthapus_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "DELETE FROM motor where id_mtr='" + textidmotor.Text + "'";
            SqlDataAdapter baru1 = new SqlDataAdapter(query, con);
            baru1.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Telah Dihapus !!");



        }
    }
}
