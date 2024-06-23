
namespace shop_flycam.form
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.pnlActive = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnSalesman = new System.Windows.Forms.Button();
            this.btnBuyer = new System.Windows.Forms.Button();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnFlycam = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.order = new shop_flycam.control.order();
            this.user = new shop_flycam.control.user();
            this.salesman = new shop_flycam.control.salesman();
            this.buyer = new shop_flycam.control.buyer();
            this.flycam = new shop_flycam.control.flycam();
            this.dashboard = new shop_flycam.control.dashboard();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlCenter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.panelHeader.Controls.Add(this.picClose);
            this.panelHeader.Controls.Add(this.label1);
            this.panelHeader.Controls.Add(this.pictureBox1);
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1200, 47);
            this.panelHeader.TabIndex = 0;
            // 
            // picClose
            // 
            this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
            this.picClose.Location = new System.Drawing.Point(1159, 6);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(35, 33);
            this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picClose.TabIndex = 2;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(62, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(401, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Hệ Thống Quản Lý Bán Flycam | Trang Admin";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panelSidebar
            // 
            this.panelSidebar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.panelSidebar.Controls.Add(this.pnlActive);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Controls.Add(this.btnAccount);
            this.panelSidebar.Controls.Add(this.btnSalesman);
            this.panelSidebar.Controls.Add(this.btnBuyer);
            this.panelSidebar.Controls.Add(this.btnOrder);
            this.panelSidebar.Controls.Add(this.btnFlycam);
            this.panelSidebar.Controls.Add(this.pictureBox3);
            this.panelSidebar.Controls.Add(this.lblName);
            this.panelSidebar.Controls.Add(this.label2);
            this.panelSidebar.Controls.Add(this.picAvatar);
            this.panelSidebar.Controls.Add(this.btnDashboard);
            this.panelSidebar.Location = new System.Drawing.Point(0, 45);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(230, 605);
            this.panelSidebar.TabIndex = 1;
            // 
            // pnlActive
            // 
            this.pnlActive.BackColor = System.Drawing.Color.Salmon;
            this.pnlActive.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlActive.BackgroundImage")));
            this.pnlActive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlActive.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlActive.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlActive.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlActive.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlActive.Location = new System.Drawing.Point(9, 148);
            this.pnlActive.Name = "pnlActive";
            this.pnlActive.Quality = 10;
            this.pnlActive.Size = new System.Drawing.Size(10, 44);
            this.pnlActive.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(25, 548);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(188, 44);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnAccount
            // 
            this.btnAccount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccount.FlatAppearance.BorderSize = 0;
            this.btnAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccount.ForeColor = System.Drawing.Color.White;
            this.btnAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.Image")));
            this.btnAccount.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccount.Location = new System.Drawing.Point(25, 444);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(188, 44);
            this.btnAccount.TabIndex = 7;
            this.btnAccount.Text = "Tài khoản";
            this.btnAccount.UseVisualStyleBackColor = false;
            this.btnAccount.Click += new System.EventHandler(this.btnAccount_Click);
            // 
            // btnSalesman
            // 
            this.btnSalesman.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnSalesman.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalesman.FlatAppearance.BorderSize = 0;
            this.btnSalesman.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalesman.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalesman.ForeColor = System.Drawing.Color.White;
            this.btnSalesman.Image = ((System.Drawing.Image)(resources.GetObject("btnSalesman.Image")));
            this.btnSalesman.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSalesman.Location = new System.Drawing.Point(25, 384);
            this.btnSalesman.Name = "btnSalesman";
            this.btnSalesman.Size = new System.Drawing.Size(188, 44);
            this.btnSalesman.TabIndex = 6;
            this.btnSalesman.Text = "Nhân viên";
            this.btnSalesman.UseVisualStyleBackColor = false;
            this.btnSalesman.Click += new System.EventHandler(this.btnSalesman_Click);
            // 
            // btnBuyer
            // 
            this.btnBuyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnBuyer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuyer.FlatAppearance.BorderSize = 0;
            this.btnBuyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuyer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuyer.ForeColor = System.Drawing.Color.White;
            this.btnBuyer.Image = ((System.Drawing.Image)(resources.GetObject("btnBuyer.Image")));
            this.btnBuyer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuyer.Location = new System.Drawing.Point(25, 324);
            this.btnBuyer.Name = "btnBuyer";
            this.btnBuyer.Size = new System.Drawing.Size(188, 44);
            this.btnBuyer.TabIndex = 5;
            this.btnBuyer.Text = "Khách hàng";
            this.btnBuyer.UseVisualStyleBackColor = false;
            this.btnBuyer.Click += new System.EventHandler(this.btnBuyer_Click);
            // 
            // btnOrder
            // 
            this.btnOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnOrder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOrder.FlatAppearance.BorderSize = 0;
            this.btnOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrder.ForeColor = System.Drawing.Color.White;
            this.btnOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnOrder.Image")));
            this.btnOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOrder.Location = new System.Drawing.Point(25, 264);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(188, 44);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "Hoá đơn";
            this.btnOrder.UseVisualStyleBackColor = false;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnFlycam
            // 
            this.btnFlycam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnFlycam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlycam.FlatAppearance.BorderSize = 0;
            this.btnFlycam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlycam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlycam.ForeColor = System.Drawing.Color.White;
            this.btnFlycam.Image = ((System.Drawing.Image)(resources.GetObject("btnFlycam.Image")));
            this.btnFlycam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFlycam.Location = new System.Drawing.Point(25, 205);
            this.btnFlycam.Name = "btnFlycam";
            this.btnFlycam.Size = new System.Drawing.Size(188, 44);
            this.btnFlycam.TabIndex = 3;
            this.btnFlycam.Text = "Flycam";
            this.btnFlycam.UseVisualStyleBackColor = false;
            this.btnFlycam.Click += new System.EventHandler(this.btnFlycam_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(128, 66);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(38, 34);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(65, 97);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(37, 32);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Emoji", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(51, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Welcome";
            // 
            // picAvatar
            // 
            this.picAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picAvatar.Image = ((System.Drawing.Image)(resources.GetObject("picAvatar.Image")));
            this.picAvatar.Location = new System.Drawing.Point(80, 10);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(60, 60);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 2;
            this.picAvatar.TabStop = false;
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(164)))), ((int)(((byte)(254)))));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(25, 148);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(188, 44);
            this.btnDashboard.TabIndex = 2;
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // pnlCenter
            // 
            this.pnlCenter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.pnlCenter.Controls.Add(this.panel1);
            this.pnlCenter.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F);
            this.pnlCenter.Location = new System.Drawing.Point(230, 45);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(970, 605);
            this.pnlCenter.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.panel1.Controls.Add(this.order);
            this.panel1.Controls.Add(this.user);
            this.panel1.Controls.Add(this.salesman);
            this.panel1.Controls.Add(this.buyer);
            this.panel1.Controls.Add(this.flycam);
            this.panel1.Controls.Add(this.dashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(970, 605);
            this.panel1.TabIndex = 0;
            // 
            // order
            // 
            this.order.Dock = System.Windows.Forms.DockStyle.Fill;
            this.order.Location = new System.Drawing.Point(0, 0);
            this.order.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.order.Name = "order";
            this.order.Size = new System.Drawing.Size(970, 605);
            this.order.TabIndex = 5;
            this.order.Visible = false;
            // 
            // user
            // 
            this.user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.user.Location = new System.Drawing.Point(0, 0);
            this.user.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(970, 605);
            this.user.TabIndex = 4;
            this.user.Visible = false;
            // 
            // salesman
            // 
            this.salesman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.salesman.Location = new System.Drawing.Point(0, 0);
            this.salesman.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.salesman.Name = "salesman";
            this.salesman.Size = new System.Drawing.Size(970, 605);
            this.salesman.TabIndex = 3;
            this.salesman.Visible = false;
            // 
            // buyer
            // 
            this.buyer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buyer.Location = new System.Drawing.Point(0, 0);
            this.buyer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyer.Name = "buyer";
            this.buyer.Size = new System.Drawing.Size(970, 605);
            this.buyer.TabIndex = 2;
            this.buyer.Visible = false;
            // 
            // flycam
            // 
            this.flycam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.flycam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flycam.Location = new System.Drawing.Point(0, 0);
            this.flycam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flycam.Name = "flycam";
            this.flycam.Size = new System.Drawing.Size(970, 605);
            this.flycam.TabIndex = 1;
            this.flycam.Visible = false;
            // 
            // dashboard
            // 
            this.dashboard.AutoSize = true;
            this.dashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dashboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dashboard.Location = new System.Drawing.Point(0, 0);
            this.dashboard.Margin = new System.Windows.Forms.Padding(0);
            this.dashboard.Name = "dashboard";
            this.dashboard.Size = new System.Drawing.Size(970, 605);
            this.dashboard.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1200, 650);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlCenter.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnSalesman;
        private System.Windows.Forms.Button btnBuyer;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnFlycam;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlActive;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.Panel panel1;
        private control.dashboard dashboard;
        private control.flycam flycam;
        private control.buyer buyer;
        private control.salesman salesman;
        private control.user user;
        private control.order order;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}