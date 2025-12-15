using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    internal class DataProvider
    {
        private static string connectionString = "Data Source=localhost;Initial Catalog=QuanLyKhachSan1;Integrated Security=True";

        // Hàm thực thi câu lệnh SELECT, trả về DataTable
        public static DataTable ThucThiTruyVan(string query)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi thực thi truy vấn: " + ex.Message);
                }
            }
            return dataTable;
        }

        // Hàm thực thi các câu lệnh không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public static int ThucThiLenh(string query)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi thực thi lệnh: " + ex.Message);
                    throw; // Ném lỗi lên để caller có thể bắt
                }
            }
            return result;
        }

        // Hàm thực thi câu lệnh trả về giá trị đơn (ExecuteScalar)
        public static object ThucThiScalar(string query)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    result = command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi thực thi scalar: " + ex.Message);
                }
            }
            return result;
        }
    }
}
