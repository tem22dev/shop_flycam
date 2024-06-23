using shop_flycam.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop_flycam.control
{
    public partial class flycam : UserControl
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
            dgvFlycam.BackgroundColor = color;
            tableLayoutPanel.BackColor = color;
        }

        // Load data ra dgv
        public void loadDataGridView()
        {
            dgvFlycam.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

            table = function.getData("SELECT * FROM tblProduct");
            dgvFlycam.DataSource = table;
            dgvFlycam.Columns[0].HeaderText = "Mã flycam";
            dgvFlycam.Columns[1].HeaderText = "Tên flycam";
            dgvFlycam.Columns[2].HeaderText = "Số lượng";
            dgvFlycam.Columns[3].HeaderText = "Giá nhập";
            dgvFlycam.Columns[4].HeaderText = "Giá bán";
            dgvFlycam.Columns[5].HeaderText = "Ghi chú";
            dgvFlycam.Columns[6].HeaderText = "Ảnh";
            dgvFlycam.Columns[7].HeaderText = "Thông tin";
        }

        // Set các textbox rỗng
        public void empty()
        {
            txtCodeProduct.Text = string.Empty;
            txtNameProduct.Text = string.Empty;
            txtConment.Text = string.Empty;
            txtInfoFlycam.Text = string.Empty;
            txtPriceInput.Text = string.Empty;
            txtPriceOutput.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            picBoxProduct.Image = null;
            txtPathPhoto.Text = string.Empty;
            txtSearch.Text = string.Empty;
        }

        public flycam()
        {
            InitializeComponent();
        }

        private void flycam_Load(object sender, EventArgs e)
        {
            loadBackColor();
            loadDataGridView();
        }

        // Vô hiệu hoá btn
        public void enabledBtn(bool btnAdd, bool btnDelete, bool btnUpdate, bool btnSv, bool Cancel, bool upload)
        {
            btnAddProduct.Enabled = btnAdd;
            btnUpdateProduct.Enabled = btnDelete;
            btnDeleteProduct.Enabled = btnUpdate;
            btnSave.Enabled = btnSv;
            btnCancel.Enabled = Cancel;
            btnUploadImg.Enabled = upload;
        }

        // Thêm sản phẩm
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            empty();
            txtCodeProduct.BackColor = Color.White;
            txtCodeProduct.Enabled = true;
            txtCodeProduct.Focus();
            enabledBtn(false, false, false, true, true, true);
        }

        // Cập nhật sản phẩm
        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            string codeProduct = txtCodeProduct.Text.Trim();
            string nameProduct = txtNameProduct.Text.Trim();
            string quantity = txtQuantity.Text.Trim();
            string priceInput = txtPriceInput.Text.Trim();
            string priceOutput = txtPriceOutput.Text.Trim();
            string comment = txtConment.Text.Trim();
            string info = txtInfoFlycam.Text.Trim();
            string pathPhoto = txtPathPhoto.Text.Trim();
            
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn flycam để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (codeProduct == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn flycam nào để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nameProduct == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập tên flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (quantity == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số lượng flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (priceInput == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập giá nhập flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pathPhoto == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn ảnh flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (priceOutput == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập giá bán flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (info == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập thông tin flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand cm = new SqlCommand("UPDATE tblProduct SET nameProduct = N'" + nameProduct + "', quantity = " + quantity + ", inputPrice = " + priceInput + ", outPrice = " + priceOutput + ", comment = N'" + comment + "', image = '" + pathPhoto + "', infoFlycam = N'" + info + "' WHERE codeProduct = '" + codeProduct + "'", function.conn);
            cm.ExecuteNonQuery();

            loadDataGridView();
            empty();
            btnCancel.Enabled = false;
            btnAddProduct.Enabled = true;
            btnUploadImg.Enabled = false;
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            string codeProduct = txtCodeProduct.Text.Trim();
            string nameProduct = txtNameProduct.Text.Trim();
            string sql = "SELECT codeProduct FROM tblOrderDetails WHERE codeProduct = '" + codeProduct + "'";

            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Không còn flycam để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (codeProduct == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn flycam nào để xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã sản phẩm " + codeProduct + " đã có trong đơn hàng đơn hàng. Nếu bạn muốn xoá flycam {codeProduct}, bạn cần phải xoá các hoá đơn có flycam {codeProduct} phát sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Bạn chắc chắn muốn xoá sản phẩm" + nameProduct + " có mã là: " + codeProduct + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                SqlCommand cm = new SqlCommand("DELETE FROM tblProduct WHERE codeProduct = '" + codeProduct + "'", function.conn);
                cm.ExecuteNonQuery();

                loadDataGridView();
                empty();
                enabledBtn(true, true, true, false, false, false);
            }
        }

        // Huỷ thao tác
        private void btnCancel_Click(object sender, EventArgs e)
        {
            empty();
            enabledBtn(true, true, true, false, false, false);
            txtCodeProduct.BackColor = Color.FromArgb(240, 240, 240);
            txtCodeProduct.Enabled = false;
            loadDataGridView();
        }

        // Lưu khi thêm sản phẩm
        private void btnSave_Click(object sender, EventArgs e)
        {
            string codeProduct = txtCodeProduct.Text.Trim();
            string nameProduct = txtNameProduct.Text.Trim();
            string quantity = txtQuantity.Text.Trim();
            string priceInput = txtPriceInput.Text.Trim();
            string priceOutput = txtPriceOutput.Text.Trim();
            string comment = txtConment.Text.Trim();
            string info = txtInfoFlycam.Text.Trim();
            string pathPhoto = txtPathPhoto.Text.Trim();
            string sql = "SELECT codeProduct FROM tblProduct WHERE codeProduct = '" + codeProduct + "'";
            
            if (codeProduct == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (nameProduct == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập tên flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (quantity == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập số lượng flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (priceInput == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập giá nhập flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (priceOutput == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập giá bán flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (pathPhoto == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn ảnh flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (info == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập thông tin flycam.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (function.isExistKey(sql))
            {
                MessageBox.Show("Mã flycam " + codeProduct + " đã tồn tại, vui lòng nhập mã khác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SqlCommand cm = new SqlCommand("INSERT INTO tblProduct VALUES('" + codeProduct + "', N'" + nameProduct + "', " + quantity + ", " + priceInput + ", " + priceOutput + ", N'" + comment + "', '" + pathPhoto + "', N'" + info + "')", function.conn);
            cm.ExecuteNonQuery();
            loadDataGridView();
            empty();
            enabledBtn(true, true, true, false, false, false);
            txtCodeProduct.BackColor = Color.FromArgb(240, 240, 240);
            txtCodeProduct.Enabled = false;
        }

        // Double Click dgv
        private void dgvProduct_DoubleClick(object sender, EventArgs e)
        {
            if (txtCodeProduct.Enabled) return;
            if (table.Rows.Count == 0) return;

            txtCodeProduct.Text = dgvFlycam.CurrentRow.Cells["codeProduct"].Value.ToString();
            txtNameProduct.Text = dgvFlycam.CurrentRow.Cells["nameProduct"].Value.ToString();
            txtQuantity.Text = dgvFlycam.CurrentRow.Cells["quantity"].Value.ToString();
            txtPriceInput.Text = dgvFlycam.CurrentRow.Cells["inputPrice"].Value.ToString();
            txtPriceOutput.Text = dgvFlycam.CurrentRow.Cells["outPrice"].Value.ToString();
            txtConment.Text = dgvFlycam.CurrentRow.Cells["comment"].Value.ToString();
            txtPathPhoto.Text = dgvFlycam.CurrentRow.Cells["image"].Value.ToString();
            txtInfoFlycam.Text = dgvFlycam.CurrentRow.Cells["infoFlycam"].Value.ToString();
            //MessageBox.Show(dgvProduct.CurrentRow.Cells["image"].Value.ToString());
            picBoxProduct.Image = Image.FromFile(txtPathPhoto.Text);
            enabledBtn(false, true, true, false, true, true);
        }

        // Upload img sản phẩm
        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image File(*.jpg; *.jpeg; *.png) | *.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        txtPathPhoto.Text = openFileDialog.FileName;

                        if (myStream.Length > 512000)
                        {
                            MessageBox.Show("Ảnh quá lớn, vui lòng chọn ảnh nhỏ hơn.");
                        }
                        else
                        {
                            picBoxProduct.Image = Image.FromFile(txtPathPhoto.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        // Tìm kiếm flycam
        private void pictureBoxSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập mã hay tên flycam để tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            table = function.getData("SELECT * FROM tblProduct WHERE codeProduct LIKE '%" + txtSearch.Text + "%' OR nameProduct LIKE '%" + txtSearch.Text + "%'");
            dgvFlycam.DataSource = table;
            dgvFlycam.Columns[0].HeaderText = "Mã flycam";
            dgvFlycam.Columns[1].HeaderText = "Tên flycam";
            dgvFlycam.Columns[2].HeaderText = "Số lượng";
            dgvFlycam.Columns[3].HeaderText = "Giá nhập";
            dgvFlycam.Columns[4].HeaderText = "Giá bán";
            dgvFlycam.Columns[5].HeaderText = "Ghi chú";
            dgvFlycam.Columns[6].HeaderText = "Ảnh";
            dgvFlycam.Columns[7].HeaderText = "Thông tin";
            btnCancel.Enabled = true;
        }
    }
}
