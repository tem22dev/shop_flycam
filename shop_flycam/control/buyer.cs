using shop_flycam.lib;
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

namespace shop_flycam.control
{
    public partial class buyer : UserControl
    {
        DataTable table = new DataTable();

        // Load background
        public void loadBackColor()
        {
            Color color = new Color();
            color = function.getBackColor(0);

            panel1.BackColor = color;
            panel2.BackColor = color;
            panel4.BackColor = color;
            panel5.BackColor = color;
            dgvBuyer.BackgroundColor = color;
            pnlMain.BackColor = color;
            tableLayoutPanel.BackColor = color;
        }

        // Load data ra dgv
        public void loadDataGridView()
        {
            dgvBuyer.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            table = function.getData("SELECT * FROM tblBuyer");
            dgvBuyer.DataSource = table;
            dgvBuyer.Columns[0].HeaderText = "Mã khách";
            dgvBuyer.Columns[1].HeaderText = "Tên khách";
            dgvBuyer.Columns[2].HeaderText = "Địa chỉ";
            dgvBuyer.Columns[3].HeaderText = "Điện thoại";
        }

        public void empty()
        {
            txtCodeBuyer.Text = string.Empty;
            txtFullnameBuyer.Text = string.Empty;
            txtPhoneBuyer.Text = string.Empty;
            txtAddressBuyer.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        public buyer()
        {
            InitializeComponent();
        }

        // Load control khách hàng
        private void buyer_Load(object sender, EventArgs e)
        {
            loadBackColor();
            loadDataGridView();
        }

        //Vô hiệu hoá btn
        public void enabledBtn(bool btnA, bool btnDel, bool btnUp, bool btnSv, bool Can)
        {
            btnAddBuyer.Enabled = btnA;
            btnDeleteBuyer.Enabled = btnDel;
            btnUpdateBuyer.Enabled = btnUp;
            btnSaveBuyer.Enabled = btnSv;
            btnCancel.Enabled = Can;
        }

        // Thêm khách hàng
        private void btnAddBuyer_Click(object sender, EventArgs e)
        {
            empty();
            txtCodeBuyer.BackColor = Color.White;
            txtCodeBuyer.Enabled = true;
            txtCodeBuyer.Focus();
            enabledBtn(false, false, false, true, true);
        }

        // Cập nhật khách hàng
        private void btnUpdateBuyer_Click(object sender, EventArgs e)
        {
            string codeBuyer = txtCodeBuyer.Text.Trim();
            string fullname = txtFullnameBuyer.Text.Trim();
            string phone = txtPhoneBuyer.Text.Trim();
            string address = txtAddressBuyer.Text.Trim();

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn khách hàng để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (codeBuyer == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullname == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Họ tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (phone == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (address == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand cm = new SqlCommand("UPDATE tblBuyer SET nameBuyer = N'" + fullname + "', address = N'" + address + "', phone = '" + phone + "' WHERE codeBuyer = '" + codeBuyer + "'", function.conn);
            cm.ExecuteNonQuery();

            loadDataGridView();
            empty();
            btnCancel.Enabled = false;
            btnAddBuyer.Enabled = true;
        }

        // Xoá khách hàng
        private void btnDeleteBuyer_Click(object sender, EventArgs e)
        {
            string codeBuyer = txtCodeBuyer.Text.Trim();
            string fullname = txtFullnameBuyer.Text.Trim();
            string sql = "SELECT codeBuyer FROM tblOrder WHERE codeBuyer = '" + codeBuyer + "'";

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn khách hàng để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (codeBuyer == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn khách hàng để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã khách hàng " + codeBuyer + " đã phát sinh đơn hàng. Nếu bạn muốn xoá khách hàng " + codeBuyer + ", bạn cần phải xoá các hoá đơn do khách hàng " + codeBuyer + " phát sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xoá khách hàng " + fullname + " có mã là: " + codeBuyer + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("DELETE FROM tblBuyer WHERE codeBuyer = '" + codeBuyer + "'", function.conn);
                cm.ExecuteNonQuery();

                loadDataGridView();
                empty();
                enabledBtn(true, true, true, false, false);
            }
        }

        // Huỷ bỏ thao tác
        private void btnCancel_Click(object sender, EventArgs e)
        {
            empty();
            enabledBtn(true, true, true, false, false);
            txtCodeBuyer.BackColor = Color.FromArgb(240, 240, 240);
            txtCodeBuyer.Enabled = false;
            loadDataGridView();
        }

        // Lưu khi thêm khách hàng
        private void btnSaveBuyer_Click(object sender, EventArgs e)
        {
            string codeBuyer = txtCodeBuyer.Text.Trim();
            string fullname = txtFullnameBuyer.Text.Trim();
            string phone = txtPhoneBuyer.Text.Trim();
            string address = txtAddressBuyer.Text.Trim();
            string sql = "SELECT codeBuyer FROM tblBuyer WHERE codeBuyer = '" + codeBuyer + "'";
            if (codeBuyer == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Mã khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullname == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Họ tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (phone == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (address == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã khách hàng " + codeBuyer + " đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand cm = new SqlCommand("INSERT INTO tblBuyer VALUES('" + codeBuyer + "', N'" + fullname + "', N'" + address + "', '" + phone + "')", function.conn);
            cm.ExecuteNonQuery();
            loadDataGridView();
            empty();
            enabledBtn(true, true, true, false, false);
            txtCodeBuyer.BackColor = Color.FromArgb(240, 240, 240);
            txtCodeBuyer.Enabled = false;
        }

        // Double Click dgv
        private void dgvBuyer_DoubleClick(object sender, EventArgs e)
        {
            if (txtCodeBuyer.Enabled) return;
            if (table.Rows.Count == 0) return;

            txtCodeBuyer.Text = dgvBuyer.CurrentRow.Cells["codeBuyer"].Value.ToString();
            txtFullnameBuyer.Text = dgvBuyer.CurrentRow.Cells["nameBuyer"].Value.ToString();
            txtPhoneBuyer.Text = dgvBuyer.CurrentRow.Cells["phone"].Value.ToString();
            txtAddressBuyer.Text = dgvBuyer.CurrentRow.Cells["address"].Value.ToString();
            enabledBtn(false, true, true, false, true);
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã hay tên khách hàng để tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            table = function.getData("SELECT * FROM tblBuyer WHERE codeBuyer LIKE '%" + txtSearch.Text + "%' OR nameBuyer LIKE N'%" + txtSearch.Text + "%'");
            dgvBuyer.DataSource = table;
            dgvBuyer.Columns[0].HeaderText = "Mã khách";
            dgvBuyer.Columns[1].HeaderText = "Tên khách";
            dgvBuyer.Columns[2].HeaderText = "Địa chỉ";
            dgvBuyer.Columns[3].HeaderText = "Điện thoại";
            btnCancel.Enabled = true;
        }
    }
}
