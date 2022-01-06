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
    public partial class ExportForm : Form
    {
        public ExportForm(string id)
        {

            InitializeComponent();

            if (id != "")
            {
                string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
                SqlConnection conn = new SqlConnection(connectString);
                conn.Open();
                hoaDon.Text = id;
                string infomation = "select * from HOADONXUAT where MaHoaDon = '"+id+"'";
                SqlCommand cmd1 = new SqlCommand(infomation, conn);
                SqlDataReader sdr = cmd1.ExecuteReader();
                sdr.Read();
                daily.Text =sdr["daily"].ToString();
                time.Text = sdr["ngayxuat"].ToString();
                sdr.Close();
                string sqlQuery = "select PRODUCT.MaHang,TenHang,chiTietHoaDon.Soluong from chiTietHoaDon join PRODUCT on chiTietHoaDon.MaHang = PRODUCT.MaHang where MaHoaDon = '" + hoaDon.Text + "';";
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

            private void button1_Click(object sender, EventArgs e)
        {
            string str2 = "insert into HOADONXUAT(daily,MaHoaDon, NgayXuat) values('" + daily.Text + "', '" + hoaDon.Text + "',  '" + time.Value.ToString("yyyy/MM/dd") + "');";
            string str1 = "insert into chiTietHoaDon(MaHang, MaHoaDon,Soluong) values('" + idMatHang.Text + "', '" + hoaDon.Text + "' ," + soLuong.Text + ");";
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            SqlCommand cmd2 = new SqlCommand(str2, conn);
            try
            {
                cmd2.ExecuteNonQuery();
            }
            catch(Exception i)
            {

            }
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch(Exception I)
            {
                string str3 = "update chiTietHoaDon  set Soluong= Soluong + "+soLuong.Text+"   where MaHoaDon = '" + hoaDon.Text + "' and MaHang = '"+ idMatHang.Text + "';";
                SqlCommand cmd3= new SqlCommand(str3, conn);
                cmd3.ExecuteNonQuery();
            }
            

            string sqlQuery = "select PRODUCT.MaHang,TenHang,chiTietHoaDon.Soluong from chiTietHoaDon join PRODUCT on chiTietHoaDon.MaHang = PRODUCT.MaHang where MaHoaDon = '"+hoaDon.Text+"';";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView1.DataSource = d1;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str1 = "DELETE FROM chiTietHoaDon where MaHoaDon = '"+hoaDon.Text+"' and MaHang = '"+ idMatHang.Text+ "'";
            string connectString = "Data Source=HSXONZ\\SQLEXPRESS;Initial Catalog=QLKHO;Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd1 = new SqlCommand(str1, conn);
            cmd1.ExecuteNonQuery();

            string sqlQuery = "select PRODUCT.MaHang,TenHang,chiTietHoaDon.Soluong from chiTietHoaDon join PRODUCT on chiTietHoaDon.MaHang = PRODUCT.MaHang where MaHoaDon = '" + hoaDon.Text + "';";
            SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conn);
            DataTable d1 = new DataTable();
            sqlDa.Fill(d1);
            dataGridView1.DataSource = d1;
            conn.Close();
        }
    }
}
