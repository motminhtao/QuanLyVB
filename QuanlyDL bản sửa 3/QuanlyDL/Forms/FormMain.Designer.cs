namespace QuanlyDL.Forms
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null!;
        private Panel pnlTieuDe = null!;
        private Label lblTieuDe = null!;
        private Button btnCaiDat = null!;
        private Panel pnlThongBao = null!;
        private Label lblThongBaoTieuDe = null!;
        private DataGridView gridThongBao = null!;
        private Label lblKhongCoThongBao = null!;
        private Button btnNhapVanBan = null!;
        private Button btnTraCuu = null!;

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
            btnCaiDat = new Button();
            pnlThongBao = new Panel();
            lblThongBaoTieuDe = new Label();
            gridThongBao = new DataGridView();
            lblKhongCoThongBao = new Label();
            btnNhapVanBan = new Button();
            btnTraCuu = new Button();
            pnlTieuDe.SuspendLayout();
            pnlThongBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridThongBao).BeginInit();
            SuspendLayout();
            // 
            // pnlTieuDe
            // 
            pnlTieuDe.BackColor = Color.FromArgb(0, 90, 158);
            pnlTieuDe.Controls.Add(lblTieuDe);
            pnlTieuDe.Controls.Add(btnCaiDat);
            pnlTieuDe.Dock = DockStyle.Top;
            pnlTieuDe.Location = new Point(0, 0);
            pnlTieuDe.Name = "pnlTieuDe";
            pnlTieuDe.Size = new Size(700, 70);
            pnlTieuDe.TabIndex = 0;
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.White;
            lblTieuDe.Location = new Point(29, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Text = "QUẢN LÝ VĂN BẢN, TÀI LIỆU LƯU TRỮ";
            // 
            // btnCaiDat
            // 
            btnCaiDat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCaiDat.BackColor = Color.FromArgb(0, 90, 158);
            btnCaiDat.FlatAppearance.BorderSize = 0;
            btnCaiDat.FlatStyle = FlatStyle.Flat;
            btnCaiDat.Font = new Font("Segoe UI", 13F);
            btnCaiDat.ForeColor = Color.White;
            btnCaiDat.Location = new Point(640, 13);
            btnCaiDat.Name = "btnCaiDat";
            btnCaiDat.Size = new Size(45, 45);
            btnCaiDat.TabIndex = 1;
            btnCaiDat.Text = "⚙️";
            btnCaiDat.UseVisualStyleBackColor = false;
            btnCaiDat.Click += BtnCaiDat_Click;
            // 
            // pnlThongBao
            // 
            pnlThongBao.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlThongBao.Controls.Add(gridThongBao);
            pnlThongBao.Controls.Add(lblKhongCoThongBao);
            pnlThongBao.Controls.Add(lblThongBaoTieuDe);
            pnlThongBao.Location = new Point(20, 85);
            pnlThongBao.Name = "pnlThongBao";
            pnlThongBao.Size = new Size(660, 330);
            pnlThongBao.TabIndex = 2;
            // 
            // lblThongBaoTieuDe
            // 
            lblThongBaoTieuDe.Dock = DockStyle.Top;
            lblThongBaoTieuDe.Height = 28;
            lblThongBaoTieuDe.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblThongBaoTieuDe.ForeColor = Color.DarkRed;
            lblThongBaoTieuDe.Name = "lblThongBaoTieuDe";
            lblThongBaoTieuDe.Text = "🔔 Thông báo: Văn bản sắp / đã đến hạn hoàn thành";
            // 
            // gridThongBao
            // 
            gridThongBao.AllowUserToAddRows = false;
            gridThongBao.AllowUserToDeleteRows = false;
            gridThongBao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gridThongBao.BackgroundColor = Color.White;
            gridThongBao.BorderStyle = BorderStyle.FixedSingle;
            gridThongBao.GridColor = Color.Gainsboro;
            gridThongBao.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            gridThongBao.EnableHeadersVisualStyles = false;
            gridThongBao.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            gridThongBao.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            gridThongBao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            gridThongBao.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            gridThongBao.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 251);
            gridThongBao.ColumnHeadersHeight = 32;
            gridThongBao.RowTemplate.Height = 28;
            gridThongBao.RowHeadersVisible = false;
            gridThongBao.ReadOnly = true;
            gridThongBao.MultiSelect = false;
            gridThongBao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridThongBao.ScrollBars = ScrollBars.Both;
            gridThongBao.Dock = DockStyle.Fill;
            gridThongBao.Name = "gridThongBao";
            gridThongBao.TabIndex = 0;
            // 
            // lblKhongCoThongBao
            // 
            lblKhongCoThongBao.Dock = DockStyle.Fill;
            lblKhongCoThongBao.TextAlign = ContentAlignment.MiddleCenter;
            lblKhongCoThongBao.ForeColor = Color.Gray;
            lblKhongCoThongBao.Name = "lblKhongCoThongBao";
            lblKhongCoThongBao.Text = "(Không có văn bản nào sắp hoặc quá hạn)";
            lblKhongCoThongBao.Visible = false;
            // 
            // btnNhapVanBan
            // 
            btnNhapVanBan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            btnTraCuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
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
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 565);
            Controls.Add(btnTraCuu);
            Controls.Add(btnNhapVanBan);
            Controls.Add(pnlThongBao);
            Controls.Add(pnlTieuDe);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(700, 565);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QuanlyDL - Quản lý văn bản, tài liệu lưu trữ";
            pnlTieuDe.ResumeLayout(false);
            pnlTieuDe.PerformLayout();
            pnlThongBao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridThongBao).EndInit();
            ResumeLayout(false);
        }
    }
}