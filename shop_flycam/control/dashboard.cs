using shop_flycam.form;
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
using shop_flycam.lib;

namespace shop_flycam.control
{
    public partial class dashboard : UserControl
    {
        DataTable table = new DataTable();

        public void loadData() {
            table = function.getData("SELECT COUNT(username) from tblUser");
            lblQuantityAccount.Text = table.Rows[0][0].ToString();

            table = function.getData("SELECT COUNT(codeSalesman) from tblSalesman");
            lblQuantitySalesman.Text = table.Rows[0][0].ToString();

            table = function.getData("SELECT COUNT(codeBuyer) from tblBuyer");
            lblQuantityBuyer.Text = table.Rows[0][0].ToString();

            table = function.getData("SELECT COUNT(codeOrder) from tblOrder");
            lblQuantityOrder.Text = table.Rows[0][0].ToString();
            
        }

        public void loadBackColor()
        {
            Color color = new Color();
            color = function.getBackColor(0);

            chartRevenue.BackColor = color;
            pnlTopDashboard.BackColor = color;
            pnlCanlendar.BackColor = color;
            pnlChangeBG.BackColor = color;
            tableLayoutPanel.BackColor = color;

            color = function.getBackColor(1);
            pnlContentDashboard.BackColor = color;
        }

        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            // Dữ liệu đồ thị
            chartRevenue.Series["Doanh thu"].Points.AddXY(2023, 40500000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2024, 30900000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2025, 54200000);
            chartRevenue.Series["Doanh thu"].Points.AddXY(2026, 53500000);

            // Lấy dữ liệu số lượng
            loadData();

            // Thay đổi backgr
            loadBackColor();
        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog.Color;

                int red = Convert.ToInt32(color.R);
                int green = Convert.ToInt32(color.G);
                int blue = Convert.ToInt32(color.B);

                function.getData("UPDATE tblBackColor SET red = " + red + ", green = " + green + ", blue = " + blue + " WHERE id = 0");
                MessageBox.Show("Thay Background thành công, bạn hãy thoát và đăng nhập lại!!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnChangeBackColorDown_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog.Color;

                int red = Convert.ToInt32(color.R);
                int green = Convert.ToInt32(color.G);
                int blue = Convert.ToInt32(color.B);

                function.getData("UPDATE tblBackColor SET red = " + red + ", green = " + green + ", blue = " + blue + " WHERE id = 1");
                MessageBox.Show("Thay Background thành công, bạn hãy thoát và đăng nhập lại!!.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
