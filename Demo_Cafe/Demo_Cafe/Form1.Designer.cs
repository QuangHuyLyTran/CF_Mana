namespace Demo_Cafe
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbQLTU = new System.Windows.Forms.ToolStripButton();
            this.tsbQLNV = new System.Windows.Forms.ToolStripButton();
            this.tsbQLBAN = new System.Windows.Forms.ToolStripButton();
            this.tsbQLHD = new System.Windows.Forms.ToolStripButton();
            this.tsbQLTK = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDangNhap = new System.Windows.Forms.Button();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssLogin = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssLichSuDN = new System.Windows.Forms.ToolStripStatusLabel();
            this.picNV = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNV)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbQLTU,
            this.tsbQLNV,
            this.tsbQLBAN,
            this.tsbQLHD,
            this.tsbQLTK});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(696, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbQLTU
            // 
            this.tsbQLTU.Image = ((System.Drawing.Image)(resources.GetObject("tsbQLTU.Image")));
            this.tsbQLTU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQLTU.Name = "tsbQLTU";
            this.tsbQLTU.Size = new System.Drawing.Size(154, 24);
            this.tsbQLTU.Text = "Quản lý thức uống";
            this.tsbQLTU.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // tsbQLNV
            // 
            this.tsbQLNV.Image = ((System.Drawing.Image)(resources.GetObject("tsbQLNV.Image")));
            this.tsbQLNV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQLNV.Name = "tsbQLNV";
            this.tsbQLNV.Size = new System.Drawing.Size(150, 24);
            this.tsbQLNV.Text = "Quản lý nhân viên";
            this.tsbQLNV.Click += new System.EventHandler(this.tsbQLNV_Click);
            // 
            // tsbQLBAN
            // 
            this.tsbQLBAN.Image = ((System.Drawing.Image)(resources.GetObject("tsbQLBAN.Image")));
            this.tsbQLBAN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQLBAN.Name = "tsbQLBAN";
            this.tsbQLBAN.Size = new System.Drawing.Size(149, 24);
            this.tsbQLBAN.Text = "Quản lý bán hàng";
            this.tsbQLBAN.Click += new System.EventHandler(this.tsbQLBAN_Click);
            // 
            // tsbQLHD
            // 
            this.tsbQLHD.Image = ((System.Drawing.Image)(resources.GetObject("tsbQLHD.Image")));
            this.tsbQLHD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQLHD.Name = "tsbQLHD";
            this.tsbQLHD.Size = new System.Drawing.Size(142, 24);
            this.tsbQLHD.Text = "Quản lý hóa đơn";
            this.tsbQLHD.Click += new System.EventHandler(this.tsbQLHD_Click);
            // 
            // tsbQLTK
            // 
            this.tsbQLTK.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.tsbQLTK.Image = ((System.Drawing.Image)(resources.GetObject("tsbQLTK.Image")));
            this.tsbQLTK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQLTK.Name = "tsbQLTK";
            this.tsbQLTK.Size = new System.Drawing.Size(23, 24);
            this.tsbQLTK.Text = "Quản lý tài khoản";
            this.tsbQLTK.Click += new System.EventHandler(this.tsbQLTK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.LavenderBlush;
            this.label1.Location = new System.Drawing.Point(120, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Phần mềm quản lý bán Cà phê";
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.Image = ((System.Drawing.Image)(resources.GetObject("btnDangNhap.Image")));
            this.btnDangNhap.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangNhap.Location = new System.Drawing.Point(171, 290);
            this.btnDangNhap.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(136, 49);
            this.btnDangNhap.TabIndex = 2;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangNhap.UseVisualStyleBackColor = true;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Image = ((System.Drawing.Image)(resources.GetObject("btnDangXuat.Image")));
            this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangXuat.Location = new System.Drawing.Point(171, 290);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(136, 49);
            this.btnDangXuat.TabIndex = 3;
            this.btnDangXuat.Text = "Đăng Xuất";
            this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDangXuat.UseVisualStyleBackColor = true;
            this.btnDangXuat.Visible = false;
            this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.Location = new System.Drawing.Point(348, 290);
            this.btnThoat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(136, 49);
            this.btnThoat.TabIndex = 4;
            this.btnThoat.Text = "       Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssLogin,
            this.tssLichSuDN});
            this.statusStrip1.Location = new System.Drawing.Point(0, 361);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(696, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "stsTenDN";
            // 
            // tssLogin
            // 
            this.tssLogin.Name = "tssLogin";
            this.tssLogin.Size = new System.Drawing.Size(0, 17);
            // 
            // tssLichSuDN
            // 
            this.tssLichSuDN.Name = "tssLichSuDN";
            this.tssLichSuDN.Size = new System.Drawing.Size(0, 17);
            // 
            // picNV
            // 
            this.picNV.Location = new System.Drawing.Point(212, 109);
            this.picNV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picNV.Name = "picNV";
            this.picNV.Size = new System.Drawing.Size(229, 145);
            this.picNV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNV.TabIndex = 6;
            this.picNV.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(696, 383);
            this.Controls.Add(this.picNV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangXuat);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Cafe";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ToolStripStatusLabel tssLogin;
        private System.Windows.Forms.ToolStripStatusLabel tssLichSuDN;
        public System.Windows.Forms.Button btnDangXuat;
        public System.Windows.Forms.Button btnDangNhap;
        public System.Windows.Forms.ToolStripButton tsbQLTU;
        public System.Windows.Forms.ToolStripButton tsbQLNV;
        public System.Windows.Forms.ToolStripButton tsbQLBAN;
        public System.Windows.Forms.ToolStripButton tsbQLHD;
        public System.Windows.Forms.ToolStripButton tsbQLTK;
        public System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picNV;
    }
}

