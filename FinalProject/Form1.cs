using FinalProject.View;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTable1();
            UpdateTable2();

        }
      
        public void UpdateTable1()
        {
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string sqlQuery = "select Distinct MaHoaDon,NgayNhap from HOADON";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView1.DataSource = d1;
            conn.Close();
        }
        public void UpdateTable2()
        {
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string sqlQuery = "select Distinct MaHoaDon,NgayXuat,daily from HOADONXUAT";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView2.DataSource = d1;
            conn.Close();
        }
      

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            receivedForm f = new receivedForm("");
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thêm id vào");
                return;
            }
            receivedForm fr = new receivedForm(textBox1.Text);
            this.Hide();
            fr.ShowDialog();
            this.Show();
            //Data Source=HSXONZ\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True

        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            string str1 = "DELETE FROM HOADON WHERE MaHoaDon='" + textBox1.Text + "'";
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            UpdateTable1();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thêm id vào");
                return;
            }
            ExportForm fr = new ExportForm(textBox2.Text);
            this.Hide();
            fr.ShowDialog();
            this.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ExportForm f = new ExportForm("");
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            string str1 = "DELETE FROM HOADONXUAT WHERE MaHoaDon='" + textBox2.Text + "'";
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            conn.Open();
            cmd1.ExecuteNonQuery();
            conn.Close();
            UpdateTable2();
        }
    }
}
