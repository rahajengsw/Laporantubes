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
    public partial class surat : Form
    {
        public surat()
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
            string query = "SELECT * FROM surat";
            SqlDataAdapter baru3 = new SqlDataAdapter(query, con);
            DataTable br3 = new DataTable();
            baru3.Fill(br3);
            dataGridView1.DataSource = br3;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO surat(id_surat,tujuan, asal, penerima, pengirim, notlprim, notlpma, jns_surat, total_byr) VALUES ('" + textidsurat.Text + "','" + cbtujuan.Text + "','" + cbasal.Text + "','" + textpenerima.Text + "','" + textpengirim.Text + "','" + texttlprim.Text + "','" + texttlpma.Text + "','" + cbjnssurat.Text + "','" + texttotal.Text + "') ";
            SqlDataAdapter baru3 = new SqlDataAdapter(query, con);
            baru3.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERT SUCCESS!!");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (cbjnssurat.Text == "Rahasia")
            {
                texttotal.Text = "40000";
            }
            else if (cbjnssurat.Text == "Umum")
            {
                texttotal.Text = "30000";
            }
        }

        private void btubah_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "UPDATE surat SET tujuan='" + cbtujuan.Text + "',asal='" + cbasal.Text + "',penerima='" + textpenerima.Text + "',pengirim='" + textpengirim.Text + "',notlprim='" + texttlprim.Text + "',notlpma='" + texttlpma.Text + "',jns_surat='" + cbjnssurat.Text + "',total_byr='" + texttotal.Text + "' WHERE id_surat ='" + textidsurat.Text + "'";
            SqlDataAdapter baru3 = new SqlDataAdapter(query, con);
            baru3.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("BERHASIL DI UBAH");

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textidsurat.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            cbtujuan.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            cbasal.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textpenerima.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textpengirim.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            texttlprim.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            texttlpma.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            cbjnssurat.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            texttotal.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();

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
            string query = "DELETE FROM surat where id_surat='" + textidsurat.Text + "'";
            SqlDataAdapter baru3 = new SqlDataAdapter(query, con);
            baru3.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Telah Dihapus !!");

        }
    }
}
