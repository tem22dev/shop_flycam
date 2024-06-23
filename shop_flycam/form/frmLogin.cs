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

namespace shop_flycam.form
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void empty()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        // Đóng chương trình
        private void picClose_Click(object sender, EventArgs e)
        {
            function.disConnect();
            Close();
        }

        // Hiển mật khẩu
        private void picShow_Click(object sender, EventArgs e)
        {
            if (picShow.Visible)
            {
                txtPassword.UseSystemPasswordChar = false;
                picShow.Visible = false;
                picHide.Visible = true;
            }
        }

        // Ẩn mật khẩu
        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible)
            {
                txtPassword.UseSystemPasswordChar = true;
                picShow.Visible = true;
                picHide.Visible = false;
            }
        }

        // Xử lý đăng nhập
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            } else
            {
                DataTable table = new DataTable();
                table = function.getData("SELECT COUNT(*) FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "' AND password = '" + txtPassword.Text.Trim() + "'");
                
                if (table.Rows[0][0].ToString() == "1")
                {
                    table = function.getData("SELECT fullname FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "'");
                    
                    frmMain formMain = new frmMain();
                    Color color = new Color();
                    color = function.getBackColor(1);
                    formMain.name = table.Rows[0][0].ToString();
                    formMain.BackColor = color;
                    formMain.ShowDialog();


                    empty();

                } else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        // Show form khôi phục mật khẩu
        private void lblForgotPassword_Click(object sender, EventArgs e)
        {
            empty();
            frmForgotPassword frmForPass = new frmForgotPassword();
            frmForPass.ShowDialog();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            function.connect();
        }
    }
}
