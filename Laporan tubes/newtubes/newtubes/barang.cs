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
    public partial class barang : Form
    {
        public barang()
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
            string query = "SELECT * FROM tb_barang";
            SqlDataAdapter baru2 = new SqlDataAdapter(query, con);
            DataTable br2 = new DataTable();
            baru2.Fill(br2);
            dataGridView1.DataSource = br2;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO tb_barang(tujuan, asal, pengirim, penerima, notlprim, notlpma, jns_brg, kd_brg,berat,total_byr) VALUES ('" + cbtujuan.Text + "','" + cbasal.Text + "','" + textpengirim.Text + "','" + textpenerima.Text + "','" + texttlprim.Text + "','" + texttlpma.Text + "','" + cbjnsbrg.Text + "','" + textkdbrg.Text + "','" + textBerat.Text + "', '" + texttotal.Text + "') ";
            SqlDataAdapter baru2 = new SqlDataAdapter(query, con);
            baru2.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERT SUCCESS!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbjnsbrg.Text == "General")
            {
                double berat = double.Parse(textBerat.Text);
                texttotal.Text = (15000 * berat).ToString();
            }
            else if (cbjnsbrg.Text == "Spesial")
            {
                double berat = double.Parse(textBerat.Text);
                texttotal.Text = (25000 * berat).ToString();
            }
        }

        private void btubah_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE tb_barang SET tujuan='" + cbtujuan.Text + "',asal='" + cbasal.Text + "',pengirim='" + textpengirim.Text + "',penerima='" + textpenerima.Text + "',notlprim='" + texttlprim.Text + "',notlpma='" + texttlpma.Text + "',jns_brg='" + cbjnsbrg.Text + "',berat='" + textBerat.Text + "',total_byr='" + texttotal.Text + "' WHERE kd_brg ='" + textkdbrg.Text + "'";
            SqlDataAdapter baru2 = new SqlDataAdapter(query, con);
            baru2.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("BERHASIL DI UBAH");
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            cbtujuan.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cbasal.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textpengirim.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textpenerima.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            texttlprim.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            texttlpma.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            cbjnsbrg.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textkdbrg.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBerat.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            texttotal.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 kembali = new Form1();
            kembali.Show();
            this.Hide();
           
        }

        private void bthapus_Click(object sender, EventArgs e)
        {

            con.Open();
            string query = "DELETE FROM tb_barang where kd_brg='" + textkdbrg.Text + "'";
            SqlDataAdapter baru2 = new SqlDataAdapter(query, con);
            baru2.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Telah Dihapus !!");

        }
    }
}
