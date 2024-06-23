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
    public partial class user : UserControl
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
            pnlMain.BackColor = color;
            dgvUser.BackgroundColor = color;
            tableLayoutPanel.BackColor = color;
        }

        // Load data ra dgv
        public void loadDataGridView()
        {
            dgvUser.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            
            table = function.getData("SELECT * FROM tblUser");
            dgvUser.DataSource = table;
            dgvUser.Columns[0].HeaderText = "Tên đăng nhập";
            dgvUser.Columns[1].HeaderText = "Họ tên";
            dgvUser.Columns[2].HeaderText = "Mật khẩu";
            dgvUser.Columns[3].HeaderText = "Email";
        }

        public void empty()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtFullname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        public user()
        {
            InitializeComponent();
        }

        // Sự kiện load control user
        private void user_Load(object sender, EventArgs e)
        {
            loadBackColor();
            loadDataGridView();
        }

        //Vô hiệu hoá btn
        public void enabledBtn(bool btnAdd, bool btnDelete, bool btnUpdate, bool btnSv, bool Cancel)
        {
            btnAddUser.Enabled = btnAdd;
            btnDeleteUser.Enabled = btnDelete;
            btnUpdateUser.Enabled = btnUpdate;
            btnSave.Enabled = btnSv;
            btnCancel.Enabled = Cancel;
        }

        // Thêm tài khoản
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            empty();
            txtUsername.BackColor = Color.White;
            txtUsername.Enabled = true;
            txtUsername.Focus();
            enabledBtn(false, false, false, true, true);
        }

        // Cập nhật User
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn tài khoản để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (username == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullname == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (email == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (password == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            SqlCommand cm = new SqlCommand("UPDATE tblUser SET fullname = N'" + fullname + "', email = '" + email + "', password = '" + password + "' WHERE username = '" + username + "'" , function.conn);
            cm.ExecuteNonQuery();

            loadDataGridView();
            empty();
            btnCancel.Enabled = false;
            btnAddUser.Enabled = true;
        }

        // Xoá User
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn tài khoản để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (username == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn tài khoản nào để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xoá tài khoản " + username + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("DELETE FROM tblUser WHERE username = '" + username + "'", function.conn);
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
            txtUsername.BackColor = Color.FromArgb(240, 240, 240);
            txtUsername.Enabled = false;
            loadDataGridView();
        }

        // Lưu khi thêm user
        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullname = txtFullname.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
            string sql = "SELECT username FROM tblUser WHERE username = '" + username + "'";
            if (username == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (fullname == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (email == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (password == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Tên đăng nhập " + username + " đã tồn tại, vui lòng nhập tên khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand cm = new SqlCommand("INSERT INTO tblUser VALUES('" + username + "', N'" + fullname + "', '" + password + "', '" + email + "')", function.conn);
            cm.ExecuteNonQuery();
            loadDataGridView();
            empty();
            enabledBtn(true, true, true, false, false);
            txtUsername.BackColor = Color.FromArgb(240, 240, 240);
            txtUsername.Enabled = false;
        }

        // DoubleClick dgv
        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            if (txtUsername.Enabled) return;
            if (table.Rows.Count == 0) return;

            txtUsername.Text = dgvUser.CurrentRow.Cells["username"].Value.ToString();
            txtFullname.Text = dgvUser.CurrentRow.Cells["fullname"].Value.ToString();
            txtEmail.Text = dgvUser.CurrentRow.Cells["email"].Value.ToString();
            txtPassword.Text = dgvUser.CurrentRow.Cells["password"].Value.ToString();
            enabledBtn(false, true, true, false, true);
        }

        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã hay tên user để tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            table = function.getData("SELECT * FROM tblUser WHERE username LIKE '%" + txtSearch.Text + "%' OR fullname LIKE N'%" + txtSearch.Text + "%'");
            dgvUser.DataSource = table;
            dgvUser.Columns[0].HeaderText = "Tên đăng nhập";
            dgvUser.Columns[1].HeaderText = "Họ tên";
            dgvUser.Columns[2].HeaderText = "Mật khẩu";
            dgvUser.Columns[3].HeaderText = "Email";
            btnCancel.Enabled = true;
        }
    }
}
