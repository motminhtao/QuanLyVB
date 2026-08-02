namespace QuanlyDL.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null!;
        private Panel pnlTieuDe = null!;
        private Label lblTieuDe = null!;
        private Label lblPhuDe = null!;
        private Button btnNhapVanBan = null!;
        private Button btnTraCuu = null!;
        private Button btnCaiDat = null!;
        private Button btnThoat = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            pnlTieuDe = new Panel();
            lblTieuDe = new Label();
            lblPhuDe = new Label();
            btnNhapVanBan = new Button();
            btnTraCuu = new Button();
            btnCaiDat = new Button();
            btnThoat = new Button();
            pnlTieuDe.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTieuDe
            // 
            pnlTieuDe.BackColor = Color.FromArgb(0, 90, 158);
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Controls.Add(lblPhuDe);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Margin = new Padding(3, 4, 3, 4);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(526, 107);
            pnlTieuDe.TabIndex = 5;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(29, 16);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(505, 37);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "QUẢN LÝ VĂN BẢN, TÀI LIỆU LƯU TRỮ";
            // 
            // lblPhuDe
            // 
            lblPhuDe.AutoSize = true;
            lblPhuDe.Font = new Font("Segoe UI", 9F);
            lblPhuDe.ForeColor = Color.Gainsboro;
            lblPhuDe.Location = new Point(32, 64);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Size = new Size(463, 20);
            lblPhuDe.TabIndex = 1;
            lblPhuDe.Text = "Modun 1: Quản lý, lưu trữ tài liệu, văn bản, hình ảnh có khóa bảo mật";
            // 
            // btnNhapVanBan
            // 
            btnNhapVanBan.BackColor = Color.FromArgb(0, 120, 215);
            btnNhapVanBan.FlatAppearance.BorderSize = 0;
            btnNhapVanBan.FlatStyle = FlatStyle.Flat;
            btnNhapVanBan.Font = new Font("Segoe UI", 12F);
            btnNhapVanBan.ForeColor = Color.White;
            btnNhapVanBan.Location = new Point(69, 173);
            btnNhapVanBan.Margin = new Padding(3, 4, 3, 4);
            btnNhapVanBan.Name = "btnNhapVanBan";
            btnNhapVanBan.Size = new Size(389, 80);
            btnNhapVanBan.TabIndex = 4;
            btnNhapVanBan.Text = "📝  Nhập văn bản mới";
            btnNhapVanBan.UseVisualStyleBackColor = false;
            btnNhapVanBan.Click += BtnNhapVanBan_Click;
            // 
            // btnTraCuu
            // 
            btnTraCuu.BackColor = Color.FromArgb(0, 150, 136);
            btnTraCuu.FlatAppearance.BorderSize = 0;
            btnTraCuu.FlatStyle = FlatStyle.Flat;
            btnTraCuu.Font = new Font("Segoe UI", 12F);
            btnTraCuu.ForeColor = Color.White;
            btnTraCuu.Location = new Point(69, 273);
            btnTraCuu.Margin = new Padding(3, 4, 3, 4);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(389, 80);
            btnTraCuu.TabIndex = 3;
            btnTraCuu.Text = "🔍  Tra cứu văn bản";
            btnTraCuu.UseVisualStyleBackColor = false;
            btnTraCuu.Click += BtnTraCuu_Click;
            // 
            // btnCaiDat
            // 
            btnCaiDat.Font = new Font("Segoe UI", 10F);
            btnCaiDat.Location = new Point(69, 373);
            btnCaiDat.Margin = new Padding(3, 4, 3, 4);
            btnCaiDat.Name = "btnCaiDat";
            btnCaiDat.Size = new Size(389, 56);
            btnCaiDat.TabIndex = 2;
            btnCaiDat.Text = "⚙️  Cài đặt (số ngày báo trước hạn)";
            btnCaiDat.Click += BtnCaiDat_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10F);
            btnThoat.Location = new Point(69, 447);
            btnThoat.Margin = new Padding(3, 4, 3, 4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(389, 53);
            btnThoat.TabIndex = 1;
            btnThoat.Text = "Thoát";
            btnThoat.Click += (s, e) => Close();

            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(526, 587);
            Controls.Add(btnThoat);
            Controls.Add(btnCaiDat);
            Controls.Add(btnTraCuu);
            Controls.Add(btnNhapVanBan);
            Controls.Add(pnlTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuanlyDL - Quản lý văn bản, tài liệu lưu trữ";
            pnlTieuDe.ResumeLayout(false);
            pnlTieuDe.PerformLayout();
            ResumeLayout(false);
        }
    }
}
