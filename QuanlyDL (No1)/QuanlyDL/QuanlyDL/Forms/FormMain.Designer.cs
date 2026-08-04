namespace QuanlyDL.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null!;
        private Panel pnlTieuDe = null!;
        private Label lblTieuDe = null!;
        private Label lblPhuDe = null!;
        private Button btnCaiDat = null!;
        private Panel pnlThongBao = null!;
        private Label lblThongBaoTieuDe = null!;
        private ListView lvThongBao = null!;
        private ColumnHeader colSoCongVan = null!;
        private ColumnHeader colSoDen = null!;
        private ColumnHeader colHan = null!;
        private ColumnHeader colTrangThai = null!;
        private Button btnNhapVanBan = null!;
        private Button btnTraCuu = null!;
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
            btnCaiDat = new Button();
            pnlThongBao = new Panel();
            lblThongBaoTieuDe = new Label();
            lvThongBao = new ListView();
            colSoCongVan = new ColumnHeader();
            colSoDen = new ColumnHeader();
            colHan = new ColumnHeader();
            colTrangThai = new ColumnHeader();
            btnNhapVanBan = new Button();
            btnTraCuu = new Button();
            btnThoat = new Button();
            pnlTieuDe.SuspendLayout();
            pnlThongBao.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTieuDe
            // 
            pnlTieuDe.BackColor = Color.FromArgb(0, 90, 158);
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Controls.Add(lblPhuDe);
            pnlTieuDe.Controls.Add(btnCaiDat);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(700, 100);
            pnlTieuDe.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(29, 14);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "QUẢN LÝ VĂN BẢN, TÀI LIỆU LƯU TRỮ";
            // 
            // lblPhuDe
            // 
            lblPhuDe.AutoSize = true;
            lblPhuDe.Font = new Font("Segoe UI", 9F);
            lblPhuDe.ForeColor = Color.Gainsboro;
            lblPhuDe.Location = new Point(32, 60);
            lblPhuDe.Name = "lblPhuDe";
            lblPhuDe.Text = "Modun 1: Quản lý, lưu trữ tài liệu, văn bản, hình ảnh có khóa bảo mật";
            // 
            // btnCaiDat (thu nhỏ, đặt góc trên-phải)
            // 
            btnCaiDat.Font = new Font("Segoe UI", 13F);
            btnCaiDat.Location = new Point(640, 15);
            btnCaiDat.Name = "btnCaiDat";
            btnCaiDat.Size = new Size(45, 45);
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnCaiDat.BackColor = Color.FromArgb(0, 90, 158);
            btnCaiDat.ForeColor = Color.White;
            btnCaiDat.TabIndex = 1;
            btnCaiDat.Text = "⚙️";
            btnCaiDat.Click += BtnCaiDat_Click;
            // 
            // pnlThongBao
            // 
            pnlThongBao.Controls.Add(lblThongBaoTieuDe);
            pnlThongBao.Controls.Add(lvThongBao);
            pnlThongBao.Location = new Point(20, 115);
            pnlThongBao.Name = "pnlThongBao";
            pnlThongBao.Size = new Size(660, 300);
            pnlThongBao.TabIndex = 2;
            // 
            // lblThongBaoTieuDe
            // 
            lblThongBaoTieuDe.AutoSize = true;
            lblThongBaoTieuDe.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblThongBaoTieuDe.ForeColor = Color.DarkRed;
            lblThongBaoTieuDe.Location = new Point(0, 0);
            lblThongBaoTieuDe.Name = "lblThongBaoTieuDe";
            lblThongBaoTieuDe.Text = "🔔 Thông báo: Văn bản sắp / đã đến hạn hoàn thành";
            // 
            // lvThongBao
            // 
            lvThongBao.Columns.Add(colSoCongVan);
            lvThongBao.Columns.Add(colSoDen);
            lvThongBao.Columns.Add(colHan);
            lvThongBao.Columns.Add(colTrangThai);
            lvThongBao.FullRowSelect = true;
            lvThongBao.GridLines = true;
            lvThongBao.HideSelection = false;
            lvThongBao.Location = new Point(0, 28);
            lvThongBao.MultiSelect = false;
            lvThongBao.Name = "lvThongBao";
            lvThongBao.Size = new Size(660, 272);
            lvThongBao.TabIndex = 0;
            lvThongBao.UseCompatibleStateImageBehavior = false;
            lvThongBao.View = View.Details;
            // 
            // colSoCongVan
            // 
            colSoCongVan.Text = "Số công văn";
            colSoCongVan.Width = 220;
            // 
            // colSoDen
            // 
            colSoDen.Text = "Số đến";
            colSoDen.Width = 100;
            // 
            // colHan
            // 
            colHan.Text = "Hạn hoàn thành";
            colHan.Width = 130;
            // 
            // colTrangThai
            // 
            colTrangThai.Text = "Trạng thái";
            colTrangThai.Width = 200;
            // 
            // btnNhapVanBan
            // 
            btnNhapVanBan.BackColor = Color.FromArgb(0, 120, 215);
            btnNhapVanBan.FlatAppearance.BorderSize = 0;
            btnNhapVanBan.FlatStyle = FlatStyle.Flat;
            btnNhapVanBan.Font = new Font("Segoe UI", 12F);
            btnNhapVanBan.ForeColor = Color.White;
            btnNhapVanBan.Location = new Point(20, 430);
            btnNhapVanBan.Name = "btnNhapVanBan";
            btnNhapVanBan.Size = new Size(660, 55);
            btnNhapVanBan.TabIndex = 3;
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
            btnTraCuu.Location = new Point(20, 495);
            btnTraCuu.Name = "btnTraCuu";
            btnTraCuu.Size = new Size(660, 55);
            btnTraCuu.TabIndex = 4;
            btnTraCuu.Text = "🔍  Tra cứu văn bản";
            btnTraCuu.UseVisualStyleBackColor = false;
            btnTraCuu.Click += BtnTraCuu_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI", 10F);
            btnThoat.Location = new Point(20, 560);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(660, 45);
            btnThoat.TabIndex = 5;
            btnThoat.Text = "Thoát";
            btnThoat.Click += BtnThoat_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 625);
            Controls.Add(btnThoat);
            Controls.Add(btnTraCuu);
            Controls.Add(btnNhapVanBan);
            Controls.Add(pnlThongBao);
            Controls.Add(pnlTieuDe);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuanlyDL - Quản lý văn bản, tài liệu lưu trữ";
            pnlTieuDe.ResumeLayout(false);
            pnlTieuDe.PerformLayout();
            pnlThongBao.ResumeLayout(false);
            pnlThongBao.PerformLayout();
            ResumeLayout(false);
        }
    }
}