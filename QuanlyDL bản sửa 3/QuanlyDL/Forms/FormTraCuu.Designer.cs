namespace QuanlyDL.Forms
{
    partial class FormTraCuu
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblDemMat = null!;
        private Label lblDemToiMat = null!;
        private Label lblDemTuyetMat = null!;
        private Label lblTongKhoaThuong = null!;

        private Label lblSoCongVanTim = null!;
        private TextBox txtTimTen = null!;
        private Label lblSoDen = null!;
        private TextBox txtTimSoDen = null!;

        private CheckBox chkLocNgay = null!;
        private Label lblNgayNho = null!;
        private NumericUpDown nudNgay = null!;
        private Label lblThangNho = null!;
        private NumericUpDown nudThang = null!;
        private Label lblNamNho = null!;
        private NumericUpDown nudNam = null!;
        private Label lblGhiChuLocNgay = null!;

        private Label lblDoMatNho = null!;
        private ComboBox cboLocDoMat = null!;
        private CheckBox chkChuaHoanThanh = null!;

        private Button btnTimKiem = null!;
        private Button btnDatLai = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;

        private Label lblThongKeHienThi = null!;
        private CheckBox chkSapXepNgay = null!;

        private DataGridView grid = null!;
        private Label lblGhiChu = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraCuu));
            lblDemMat = new Label();
            lblDemToiMat = new Label();
            lblDemTuyetMat = new Label();
            lblTongKhoaThuong = new Label();
            lblSoCongVanTim = new Label();
            txtTimTen = new TextBox();
            lblSoDen = new Label();
            txtTimSoDen = new TextBox();
            chkLocNgay = new CheckBox();
            lblNgayNho = new Label();
            nudNgay = new NumericUpDown();
            lblThangNho = new Label();
            nudThang = new NumericUpDown();
            lblNamNho = new Label();
            nudNam = new NumericUpDown();
            lblGhiChuLocNgay = new Label();
            lblDoMatNho = new Label();
            cboLocDoMat = new ComboBox();
            chkChuaHoanThanh = new CheckBox();
            btnTimKiem = new Button();
            btnDatLai = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            lblThongKeHienThi = new Label();
            chkSapXepNgay = new CheckBox();
            grid = new DataGridView();
            lblGhiChu = new Label();
            ((System.ComponentModel.ISupportInitialize)nudNgay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).BeginInit();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();

            Font = new Font("Segoe UI", 11F);

            // 
            // lblDemMat / lblDemToiMat / lblDemTuyetMat
            // 
            lblDemMat.AutoSize = true;
            lblDemMat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDemMat.ForeColor = Color.DarkOrange;
            lblDemMat.Location = new Point(23, 18);
            lblDemMat.Name = "lblDemMat";
            lblDemMat.Text = "Mật: 0";
            // 
            lblDemToiMat.AutoSize = true;
            lblDemToiMat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDemToiMat.ForeColor = Color.OrangeRed;
            lblDemToiMat.Location = new Point(120, 18);
            lblDemToiMat.Name = "lblDemToiMat";
            lblDemToiMat.Text = "Tối Mật: 0";
            // 
            lblDemTuyetMat.AutoSize = true;
            lblDemTuyetMat.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDemTuyetMat.ForeColor = Color.DarkRed;
            lblDemTuyetMat.Location = new Point(245, 18);
            lblDemTuyetMat.Name = "lblDemTuyetMat";
            lblDemTuyetMat.Text = "Tuyệt Mật: 0";
            // 
            // lblTongKhoaThuong
            // 
            lblTongKhoaThuong.AutoSize = true;
            lblTongKhoaThuong.Font = new Font("Segoe UI", 10F);
            lblTongKhoaThuong.ForeColor = Color.DimGray;
            lblTongKhoaThuong.Location = new Point(23, 46);
            lblTongKhoaThuong.Name = "lblTongKhoaThuong";
            lblTongKhoaThuong.Text = "🔒 Đang khóa: 0   |   📄 Thường: 0";
            // 
            // lblSoCongVanTim
            // 
            lblSoCongVanTim.AutoSize = true;
            lblSoCongVanTim.Location = new Point(23, 88);
            lblSoCongVanTim.Name = "lblSoCongVanTim";
            lblSoCongVanTim.Text = "Số công văn:";
            // 
            // txtTimTen
            // 
            txtTimTen.Location = new Point(150, 84);
            txtTimTen.Name = "txtTimTen";
            txtTimTen.Size = new Size(230, 29);
            txtTimTen.TabIndex = 0;
            // 
            // lblSoDen
            // 
            lblSoDen.AutoSize = true;
            lblSoDen.Location = new Point(400, 88);
            lblSoDen.Name = "lblSoDen";
            lblSoDen.Text = "Số đến:";
            // 
            // txtTimSoDen
            // 
            txtTimSoDen.Location = new Point(470, 84);
            txtTimSoDen.Name = "txtTimSoDen";
            txtTimSoDen.Size = new Size(160, 29);
            txtTimSoDen.TabIndex = 1;
            // 
            // chkLocNgay
            // 
            chkLocNgay.AutoSize = true;
            chkLocNgay.Location = new Point(23, 132);
            chkLocNgay.Name = "chkLocNgay";
            chkLocNgay.Text = "Lọc theo Ngày nhận:";
            chkLocNgay.TabIndex = 2;
            chkLocNgay.CheckedChanged += ChkLocNgay_CheckedChanged;
            // 
            // lblNgayNho
            // 
            lblNgayNho.AutoSize = true;
            lblNgayNho.Location = new Point(230, 132);
            lblNgayNho.Name = "lblNgayNho";
            lblNgayNho.Text = "Ngày:";
            // 
            // nudNgay
            // 
            nudNgay.Location = new Point(280, 128);
            nudNgay.Name = "nudNgay";
            nudNgay.Size = new Size(55, 29);
            nudNgay.Minimum = 0;
            nudNgay.Maximum = 31;
            nudNgay.Enabled = false;
            nudNgay.TabIndex = 3;
            // 
            // lblThangNho
            // 
            lblThangNho.AutoSize = true;
            lblThangNho.Location = new Point(345, 132);
            lblThangNho.Name = "lblThangNho";
            lblThangNho.Text = "Tháng:";
            // 
            // nudThang
            // 
            nudThang.Location = new Point(400, 128);
            nudThang.Name = "nudThang";
            nudThang.Size = new Size(55, 29);
            nudThang.Minimum = 0;
            nudThang.Maximum = 12;
            nudThang.Enabled = false;
            nudThang.TabIndex = 4;
            // 
            // lblNamNho
            // 
            lblNamNho.AutoSize = true;
            lblNamNho.Location = new Point(465, 132);
            lblNamNho.Name = "lblNamNho";
            lblNamNho.Text = "Năm:";
            // 
            // nudNam
            // 
            nudNam.Location = new Point(515, 128);
            nudNam.Name = "nudNam";
            nudNam.Size = new Size(75, 29);
            nudNam.Minimum = 0;
            nudNam.Maximum = 2100;
            nudNam.Enabled = false;
            nudNam.TabIndex = 5;
            // 
            // lblGhiChuLocNgay
            // 
            lblGhiChuLocNgay.AutoSize = true;
            lblGhiChuLocNgay.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGhiChuLocNgay.ForeColor = Color.Gray;
            lblGhiChuLocNgay.Location = new Point(600, 134);
            lblGhiChuLocNgay.Name = "lblGhiChuLocNgay";
            lblGhiChuLocNgay.Text = "(để 0 = không lọc theo mục đó)";
            // 
            // lblDoMatNho
            // 
            lblDoMatNho.AutoSize = true;
            lblDoMatNho.Location = new Point(23, 176);
            lblDoMatNho.Name = "lblDoMatNho";
            lblDoMatNho.Text = "Độ mật:";
            // 
            // cboLocDoMat (chữ nhạt "Chọn độ mật..." khi chưa chọn gì, cùng cỡ với ô Ngày/Tháng/Năm)
            // 
            cboLocDoMat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocDoMat.DrawMode = DrawMode.OwnerDrawFixed;
            cboLocDoMat.ItemHeight = 24;
            cboLocDoMat.Items.AddRange(new object[] { "Không", "Mật", "Tuyệt Mật", "Tối Mật" });
            cboLocDoMat.SelectedIndex = -1;
            cboLocDoMat.Location = new Point(90, 172);
            cboLocDoMat.Name = "cboLocDoMat";
            cboLocDoMat.Size = new Size(150, 30);
            cboLocDoMat.TabIndex = 6;
            cboLocDoMat.DrawItem += CboLocDoMat_DrawItem;
            // 
            // chkChuaHoanThanh
            // 
            chkChuaHoanThanh.AutoSize = true;
            chkChuaHoanThanh.Location = new Point(280, 176);
            chkChuaHoanThanh.Name = "chkChuaHoanThanh";
            chkChuaHoanThanh.Text = "Chỉ hiện văn bản CHƯA hoàn thành";
            chkChuaHoanThanh.TabIndex = 7;
            chkChuaHoanThanh.CheckedChanged += ChkChuaHoanThanh_CheckedChanged;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(23, 216);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(130, 42);
            btnTimKiem.TabIndex = 8;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // btnDatLai
            // 
            btnDatLai.Location = new Point(163, 216);
            btnDatLai.Name = "btnDatLai";
            btnDatLai.Size = new Size(110, 42);
            btnDatLai.TabIndex = 9;
            btnDatLai.Text = "Đặt lại";
            btnDatLai.Click += BtnDatLai_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new Point(283, 216);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 42);
            btnSua.TabIndex = 10;
            btnSua.Text = "Sửa";
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(383, 216);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 42);
            btnXoa.TabIndex = 11;
            btnXoa.Text = "Xóa";
            btnXoa.Click += BtnXoa_Click;
            // 
            // lblThongKeHienThi
            // 
            lblThongKeHienThi.AutoSize = true;
            lblThongKeHienThi.Font = new Font("Segoe UI", 9.5F);
            lblThongKeHienThi.ForeColor = Color.SteelBlue;
            lblThongKeHienThi.Location = new Point(23, 270);
            lblThongKeHienThi.Name = "lblThongKeHienThi";
            lblThongKeHienThi.Text = "Đang hiển thị 0 văn bản";
            // 
            // chkSapXepNgay
            // 
            chkSapXepNgay.AutoSize = true;
            chkSapXepNgay.Location = new Point(23, 298);
            chkSapXepNgay.Name = "chkSapXepNgay";
            chkSapXepNgay.Text = "Sắp xếp theo Ngày nhận (mới nhất lên đầu)";
            chkSapXepNgay.TabIndex = 12;
            chkSapXepNgay.CheckedChanged += ChkSapXepNgay_CheckedChanged;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ScrollBars = ScrollBars.Both;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.GridColor = Color.Gainsboro;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.ColumnHeadersHeight = 46;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 11F);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 251);
            grid.RowTemplate.Height = 32;
            grid.RowHeadersVisible = false;
            grid.Location = new Point(23, 330);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(890, 400);
            grid.TabIndex = 13;
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.CellDoubleClick += Grid_CellDoubleClick;
            grid.SelectionChanged += Grid_SelectionChanged;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Font = new Font("Segoe UI", 9F);
            lblGhiChu.Location = new Point(23, 760);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblGhiChu.Text = "Nhấp đúp vào 1 dòng để xem chi tiết. Văn bản có độ mật sẽ yêu cầu nhập mật khẩu.";
            // 
            // FormTraCuu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(940, 800);
            Controls.Add(lblDemMat);
            Controls.Add(lblDemToiMat);
            Controls.Add(lblDemTuyetMat);
            Controls.Add(lblTongKhoaThuong);
            Controls.Add(lblSoCongVanTim);
            Controls.Add(txtTimTen);
            Controls.Add(lblSoDen);
            Controls.Add(txtTimSoDen);
            Controls.Add(chkLocNgay);
            Controls.Add(lblNgayNho);
            Controls.Add(nudNgay);
            Controls.Add(lblThangNho);
            Controls.Add(nudThang);
            Controls.Add(lblNamNho);
            Controls.Add(nudNam);
            Controls.Add(lblGhiChuLocNgay);
            Controls.Add(lblDoMatNho);
            Controls.Add(cboLocDoMat);
            Controls.Add(chkChuaHoanThanh);
            Controls.Add(btnTimKiem);
            Controls.Add(btnDatLai);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(lblThongKeHienThi);
            Controls.Add(chkSapXepNgay);
            Controls.Add(grid);
            Controls.Add(lblGhiChu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(960, 820);
            Name = "FormTraCuu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tra cứu văn bản";
            ((System.ComponentModel.ISupportInitialize)nudNgay).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudNam).EndInit();
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}