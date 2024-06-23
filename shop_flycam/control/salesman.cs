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
    public partial class salesman : UserControl
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
            panel6.BackColor = color;
            panel8.BackColor = color;
            pnlMain.BackColor = color;
            dgvSalesman.BackgroundColor = color;
            tableLayoutPanel.BackColor = color;
        }

        // Load data ra dgv
        public void loadDataGridView()
        {
            dgvSalesman.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            table = function.getData("SELECT * FROM tblSalesman");
            dgvSalesman.DataSource = table;
            dgvSalesman.Columns[0].HeaderText = "Mã nhân viên";
            dgvSalesman.Columns[1].HeaderText = "Tên nhân viên";
            dgvSalesman.Columns[2].HeaderText = "Giới tính";
            dgvSalesman.Columns[3].HeaderText = "Địa chỉ";
            dgvSalesman.Columns[4].HeaderText = "Số điện thoại";
            dgvSalesman.Columns[5].HeaderText = "Ngày sinh";
            dgvSalesman.Columns[6].HeaderText = "Tình trạng";
        }

        // Set các textbox rỗng
        public void empty()
        {
            txtCodeSalesman.Text = string.Empty;
            txtFullname.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtBirthday.Text = string.Empty;
            comBoxGender.Text = string.Empty;
            comBoxStatus.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        public salesman()
        {
            InitializeComponent();
        }

        private void salesman_Load(object sender, EventArgs e)
        {
            loadBackColor();
            loadDataGridView();
        }

        // Vô hiệu hoá btn
        public void enabledBtn(bool btnAdd, bool btnDelete, bool btnUpdate, bool btnSv, bool Cancel)
        {
            btnAddSalesman.Enabled = btnAdd;
            btnDeleteSalesman.Enabled = btnDelete;
            btnUpdateSalesman.Enabled = btnUpdate;
            btnSave.Enabled = btnSv;
            btnCancel.Enabled = Cancel;
        }

        // Thêm nhân viên
        private void btnAddSalesman_Click(object sender, EventArgs e)
        {
            empty();
            txtCodeSalesman.BackColor = Color.White;
            txtCodeSalesman.Enabled = true;
            txtCodeSalesman.Focus();
            enabledBtn(false, false, false, true, true);
        }

        // Cập nhật nhân viên
        private void btnUpdateSalesman_Click(object sender, EventArgs e)
        {
            string codeSalesman = txtCodeSalesman.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string gender = comBoxGender.Text.Trim();
            //MessageBox.Show(gender);
            string status = comBoxStatus.Text.Trim();
            //MessageBox.Show(status);
            string birthdayString = txtBirthday.Text.Trim();
            
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn nhân viên để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (codeSalesman == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullname == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Họ tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (phone == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (address == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gender == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn giới tính của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (birthdayString == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn tình trạng làm việc của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //DateTime birthday = DateTime.Parse(birthdayString);
            //birthday = DateTime.Parse(birthday.ToString("dd/MM/yyyy"));

            SqlCommand cm = new SqlCommand("UPDATE tblSalesman SET nameSalesman = N'" + fullname + "', gender = N'" + gender + "', address = N'" + address + "', phone = '" + phone + "', birthday = '" + birthdayString + "', workStatus = '" + status + "' WHERE codeSalesman = '" + codeSalesman + "'", function.conn);
            cm.ExecuteNonQuery();

            loadDataGridView();
            empty();
            btnCancel.Enabled = false;
            btnAddSalesman.Enabled = true;
        }

        // Xoá nhân viên
        private void btnDeleteSalesman_Click(object sender, EventArgs e)
        {
            string codeSalesman = txtCodeSalesman.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string sql = "SELECT codeSalesman FROM tblOrder WHERE codeSalesman = '" + codeSalesman + "'";

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn nhân viên để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (codeSalesman == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn nhân viên nào để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã nhân viên " + codeSalesman + " đã phát sinh đơn hàng. Nếu bạn muốn xoá nhân viên " + codeSalesman + ", bạn cần phải xoá các hoá đơn do nhân viên " + codeSalesman + " phát sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xoá nhân viên " + fullname + " có mã là: " + codeSalesman + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("DELETE FROM tblSalesman WHERE codeSalesman = '" + codeSalesman + "'", function.conn);
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
            txtCodeSalesman.BackColor = Color.FromArgb(240, 240, 240);
            txtCodeSalesman.Enabled = false;
            loadDataGridView();
        }

        // Lưu khi thêm nhân viên
        private void btnSave_Click(object sender, EventArgs e)
        {
            string codeSalesman = txtCodeSalesman.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string gender = comBoxGender.Text.Trim();
            string birthdayString = txtBirthday.Text.Trim();
            string status = comBoxStatus.Text.Trim();
            string sql = "SELECT codeSalesman FROM tblSalesman WHERE codeSalesman = '" + codeSalesman + "'";

            if (codeSalesman == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullname == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Họ tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (phone == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (address == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (gender == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn giới tính của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (birthdayString == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập ngày sinh của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn tình trạng làm việc của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã nhân viên " + codeSalesman + " đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand cm = new SqlCommand("INSERT INTO tblSalesman VALUES('" + codeSalesman + "', N'" + fullname + "', N'" + gender + "', N'" + address + "', '" + phone + "', '" + birthdayString + "', '" + status + "')", function.conn);
            cm.ExecuteNonQuery();
            loadDataGridView();
            empty();
            enabledBtn(true, true, true, false, false);
            txtCodeSalesman.BackColor = Color.FromArgb(240, 240, 240);
            txtCodeSalesman.Enabled = false;
        }

        // Double Click dgv
        private void dgvSalesman_DoubleClick(object sender, EventArgs e)
        {
            if (txtCodeSalesman.Enabled) return;
            if (table.Rows.Count == 0) return;

            txtCodeSalesman.Text = dgvSalesman.CurrentRow.Cells["codeSalesman"].Value.ToString();
            txtFullname.Text = dgvSalesman.CurrentRow.Cells["nameSalesman"].Value.ToString();
            txtAddress.Text = dgvSalesman.CurrentRow.Cells["address"].Value.ToString();
            txtPhone.Text = dgvSalesman.CurrentRow.Cells["phone"].Value.ToString();
            comBoxStatus.Text = dgvSalesman.CurrentRow.Cells["workStatus"].Value.ToString();
            comBoxGender.Text = dgvSalesman.CurrentRow.Cells["gender"].Value.ToString();
            //DateTime birthday = DateTime.Parse(dgvSalesman.CurrentRow.Cells["birthday"].Value.ToString());
            //txtBirthday.Text = birthday.ToString("dd/MM/yyyy");
            txtBirthday.Text = dgvSalesman.CurrentRow.Cells["birthday"].Value.ToString();
            enabledBtn(false, true, true, false, true);
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã hay tên nhân viên để tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            table = function.getData("SELECT * FROM tblSalesman WHERE codeSalesman LIKE '%" + txtSearch.Text + "%' OR nameSalesman LIKE N'%" + txtSearch.Text + "%'");
            dgvSalesman.DataSource = table;
            dgvSalesman.Columns[0].HeaderText = "Mã nhân viên";
            dgvSalesman.Columns[1].HeaderText = "Tên nhân viên";
            dgvSalesman.Columns[2].HeaderText = "Giới tính";
            dgvSalesman.Columns[3].HeaderText = "Địa chỉ";
            dgvSalesman.Columns[4].HeaderText = "Số điện thoại";
            dgvSalesman.Columns[5].HeaderText = "Ngày sinh";
            dgvSalesman.Columns[6].HeaderText = "Tình trạng";
            btnCancel.Enabled = true;
        }
    }
}
