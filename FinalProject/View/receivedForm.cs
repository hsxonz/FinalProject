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

namespace FinalProject.View
{
    public partial class receivedForm : Form
    {
        public receivedForm(string id)
        {
            
            InitializeComponent();

            if(id != "")
            {
                string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                hoaDon.Text = id;
                string infomation = "select * from HOADON where MaHoaDon = '" + id + "'";
                SqlCommand cmd1 = new SqlCommand(infomation, conn);
                SqlDataReader sdr = cmd1.ExecuteReader();
                sdr.Read();
                time.Text = sdr["NgayNhap"].ToString();
                sdr.Close();
                string sqlQuery = "select * from PRODUCT where PRODUCT.MaHang in (select MaHang from HOADON where MaHoaDon = '" + id + "')";
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
                DataTable d1 = new DataTable();
                sqlDa.Fill(d1);
                dataGridView1.DataSource = d1;
                conn.Close();

            }
            else
            {
                DateTime aDate = DateTime.Now;
                time.Value = aDate;
            }
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string str1 = "insert into PRODUCT(MaHang, TenHang, Soluong,  DonGiaNhap, DonGiaBan) values('" + idMatHang.Text + "', '"+NameMatHang.Text+ "' ,"+ soLuong.Text+ ","+ giaNhap.Text+","+giaXuat.Text+");";
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            string str2 = "insert into HOADON(MaHang, MaHoaDon, NgayNhap) values( '" + idMatHang.Text + "', '"+ hoaDon.Text + "' ,'" + time.Value.ToString("yyyy/MM/dd") + "');";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            SqlCommand cmd2 = new SqlCommand(str2, conn);
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch(Exception loi)
            {
                string str3 = " UPDATE PRODUCT SET Soluong = Soluong +"+ soLuong.Text + "WHERE MaHang = '"+ idMatHang.Text + "'; ";
                SqlCommand cmd3 = new SqlCommand(str3, conn);
                cmd3.ExecuteNonQuery();
            }
            try
            {
                cmd2.ExecuteNonQuery();
            } catch(Exception i)
            {
                
            }
            
            string sqlQuery = "select * from PRODUCT where PRODUCT.MaHang in (select MaHang from HOADON where MaHoaDon = '"+ hoaDon.Text + "')";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView1.DataSource = d1;
            conn.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string str1 = "UPDATE PRODUCT SET TenHang='"+NameMatHang.Text+"',Soluong = "+soLuong.Text+", DonGiaBan ="+giaXuat.Text+" , DonGiaNhap="+giaNhap.Text+ "WHERE MaHang in (select MaHang from HOADON WHERE MaHang = '" + idMatHang.Text+"' and MaHoaDon = '"+hoaDon.Text+"'); ";
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            cmd1.ExecuteNonQuery();
            string sqlQuery = "select * from PRODUCT where PRODUCT.MaHang in (select MaHang from HOADON where MaHoaDon = '" + hoaDon.Text + "')";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView1.DataSource = d1;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str1 = "DELETE FROM HOADON WHERE MaHang in (select MaHang from HOADON WHERE MaHang = '" + idMatHang.Text + "' and MaHoaDon = '" + hoaDon.Text + "'); ";
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            cmd1.ExecuteNonQuery();
            string sqlQuery = "select * from PRODUCT where PRODUCT.MaHang in (select MaHang from HOADON where MaHoaDon = '" + hoaDon.Text + "')";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView1.DataSource = d1;
            conn.Close();
        }
    }
}
