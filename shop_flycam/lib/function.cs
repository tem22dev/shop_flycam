using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_flycam.lib
{
    class function
    {
        public static SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Workspace\\university\\2023\\LT-WINDOW\\shop_flycam\\shop_flycam\\QLShopFlycam.mdf;Integrated Security=True");
        
        // Mở kết nối CSDL
        public static void connect()
        {
            conn.Open();
        }

        // Đóng kết nối CSDL
        public static void disConnect()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }

        // Lấy dữ liệu từ CSDL
        public static DataTable getData(string sql)
        {
            DataTable table = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter();

            SqlCommand cmGetUser = new SqlCommand(sql, conn);
            dap.SelectCommand = cmGetUser;
            table.Clear();
            dap.Fill(table);
            return table;
        }

        public static string getValue(string sql)
        {
            DataTable table = new DataTable();
            table = getData(sql);
            string str = "";
            if (table.Rows.Count > 0)
            {
                str = table.Rows[0][0].ToString();
            }
            table.Clear();
            return str;
        }

        // Lấy mã màu BackColor
        public static Color getBackColor(int id)
        {
            DataTable table = new DataTable();
            table = getData("SELECT red, green, blue FROM tblBackColor WHERE id = " + id);
            int red = Convert.ToInt32(table.Rows[0][0]);
            int green = Convert.ToInt32(table.Rows[0][1]);
            int blue = Convert.ToInt32(table.Rows[0][2]);

            Color BackGr = new Color();
            BackGr = Color.FromArgb(red, green, blue);
            return BackGr;
        }

        // Kiểm tra key có tồn tại không
        public static bool isExistKey(string sql) 
        {
            DataTable table = new DataTable();
            table = getData(sql);

            if (table.Rows.Count > 0)
                return true;
            return false;
        }

        // Nạp dữ liệu vào compobox
        public static void loadComboBox(string sql, ComboBox combo, string code)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            dap.Fill(table);
            combo.DataSource = table;
            combo.ValueMember = code; //Trường giá trị
            combo.DisplayMember = code; //Trường hiển thị
        }

        // Random mã đơn hàng
        public static string randomCodeOrder(string prefix)
        {
            int second = (int)DateTime.Now.Second;
            int minute = (int)DateTime.Now.Minute;
            int day = (int)DateTime.Now.Day;
            int month = (int)DateTime.Now.Month;
            string str = prefix + second.ToString() + minute.ToString() + day.ToString() + month.ToString();
            return str;
        }
    }
}
