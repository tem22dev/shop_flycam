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
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        // Đóng chương trình
        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Sử lý cấp lại password
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Tên đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Bạn phải nhập Email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DataTable table = new DataTable();
                table = function.getData("SELECT COUNT(*) FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "' AND email = '" + txtEmail.Text.Trim() + "'");

                if (table.Rows[0][0].ToString() == "1")
                {
                    table = function.getData("SELECT password FROM tblUser WHERE username = '" + txtUsername.Text.Trim() + "' AND email = '" + txtEmail.Text.Trim() + "'");
                    
                    MessageBox.Show("Mật khẩu của bạn là: " + table.Rows[0][0], "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc email không đúng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
    }
}
