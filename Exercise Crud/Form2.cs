using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exercise_Crud
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-3O1VMEB;Initial Catalog=StoreProcedure_DB;User ID=sa;Password=atharizaki123");
        private void button1_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);
            string nama = textBox2.Text, asal = comboBox1.Text, Jenis_Kelamin = "";
            DateTime TanggalLahir = DateTime.Parse(dateTimePicker1.Text);
            if(radioButton1.Checked==true) { Jenis_Kelamin = "Laki-Laki"; } else { Jenis_Kelamin = "Perempuan"; }
            double umur = double.Parse(textBox3.Text);
            con.Open();
            SqlCommand c = new SqlCommand("exec InsertEMP_SP '" + empid + "','" + nama + "','" + asal + "','" + umur + "','" + Jenis_Kelamin + "','" + TanggalLahir + "' ", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Data Berhasil Di input");
            GetEmpList();
        }

        void GetEmpList()
        {
            SqlCommand c = new SqlCommand("exec ListEmp_SP", con);
            SqlDataAdapter sd = new SqlDataAdapter(c);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GetEmpList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int empid = int.Parse(textBox1.Text);
            string nama = textBox2.Text, asal = comboBox1.Text, Jenis_Kelamin = "";
            DateTime TanggalLahir = DateTime.Parse(dateTimePicker1.Text);
            if (radioButton1.Checked == true) { Jenis_Kelamin = "Laki-Laki"; } else { Jenis_Kelamin = "Perempuan"; }
            double umur = double.Parse(textBox3.Text);
            con.Open();
            SqlCommand c = new SqlCommand("exec UpdateEmp_SP '" + empid + "','" + nama + "','" + asal + "','" + umur + "','" + Jenis_Kelamin + "','" + TanggalLahir + "' ", con);
            c.ExecuteNonQuery();
            MessageBox.Show("Data Berhasil Di Update");
            GetEmpList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Apakah Yakin ingin Dihapus?", "Delete Document", MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                int empid = int.Parse(textBox1.Text);
                con.Open();
                SqlCommand c = new SqlCommand("exec DeleteEmp_SP '" + empid + "' ", con);
                c.ExecuteNonQuery();
                MessageBox.Show("Data Berhasil Di Hapus");
                GetEmpList();
            }
            
        }
    }
}
