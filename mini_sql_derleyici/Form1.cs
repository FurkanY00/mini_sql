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


namespace mini_sql_derleyici
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti=new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=minisql;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;

            try
            {
                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter(sorgu, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("sorgunuzu kontrol edin","uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = richTextBox1.Text;
            try
            {
                
                baglanti.Open();
                SqlCommand komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();

                baglanti.Open();
                SqlDataAdapter da = new SqlDataAdapter("Select *from tblkisiler ", baglanti);
                DataTable dt=new DataTable();
                da.Fill(dt);
                baglanti.Close();
            }
            catch (Exception)
            {
               MessageBox.Show("sorgunuzu kontrol edin", "uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
