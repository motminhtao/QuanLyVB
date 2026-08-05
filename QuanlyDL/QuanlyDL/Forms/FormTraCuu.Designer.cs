namespace QuanlyDL.Forms
{
    partial class FormTraCuu
    {
        private System.ComponentModel.IContainer components = null!;

        private ComboBox cboLocDoMat = null!;
        private Button btnLoc = null!;
        private Label lblDemMat = null!;
        private Label lblDemToiMat = null!;
        private Label lblDemTuyetMat = null!;
        private Label lblTongKhoaThuong = null!;

        private Label lblTen = null!;
        private TextBox txtTimTen = null!;
        private Label lblSoDen = null!;
        private TextBox txtTimSoDen = null!;
        private CheckBox chkLocNgay = null!;
        private DateTimePicker dtpTimNgay = null!;
        private Button btnTimKiem = null!;
        private Button btnHienTatCa = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
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
            cboLocDoMat = new ComboBox();
            btnLoc = new Button();
            lblDemMat = new Label();
            lblDemToiMat = new Label();
            lblDemTuyetMat = new Label();
            lblTongKhoaThuong = new Label();
            lblTen = new Label();
            txtTimTen = new TextBox();
            lblSoDen = new Label();
            txtTimSoDen = new TextBox();
            chkLocNgay = new CheckBox();
            dtpTimNgay = new DateTimePicker();
            btnTimKiem = new Button();
            btnHienTatCa = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            chkSapXepNgay = new CheckBox();
            grid = new DataGridView();
            lblGhiChu = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // cboLocDoMat (chữ nhạt "Chọn độ mật..." khi chưa chọn gì)
            // 
            cboLocDoMat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocDoMat.DrawMode = DrawMode.OwnerDrawFixed;
            cboLocDoMat.Items.AddRange(new object[] { "Không", "Mật", "Tuyệt Mật", "Tối Mật" });
            cboLocDoMat.SelectedIndex = -1;
            cboLocDoMat.Location = new Point(23, 20);
            cboLocDoMat.Name = "cboLocDoMat";
            cboLocDoMat.Size = new Size(180, 28);
            cboLocDoMat.TabIndex = 0;
            cboLocDoMat.DrawItem += CboLocDoMat_DrawItem;
            // 
            // btnLoc
            // 
            btnLoc.Location = new Point(211, 17);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(120, 34);
            btnLoc.TabIndex = 1;
            btnLoc.Text = "Lọc theo độ mật";
            btnLoc.Click += BtnLoc_Click;
            // 
            // lblDemMat / lblDemToiMat / lblDemTuyetMat (đặt cạnh nhau)
            // 
            lblDemMat.AutoSize = true;
            lblDemMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDemMat.ForeColor = Color.DarkOrange;
            lblDemMat.Location = new Point(345, 24);
            lblDemMat.Name = "lblDemMat";
            lblDemMat.Text = "Mật: 0";
            // 
            lblDemToiMat.AutoSize = true;
            lblDemToiMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDemToiMat.ForeColor = Color.OrangeRed;
            lblDemToiMat.Location = new Point(440, 24);
            lblDemToiMat.Name = "lblDemToiMat";
            lblDemToiMat.Text = "Tối Mật: 0";
            // 
            lblDemTuyetMat.AutoSize = true;
            lblDemTuyetMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDemTuyetMat.ForeColor = Color.DarkRed;
            lblDemTuyetMat.Location = new Point(555, 24);
            lblDemTuyetMat.Name = "lblDemTuyetMat";
            lblDemTuyetMat.Text = "Tuyệt Mật: 0";
            // 
            // lblTongKhoaThuong
            // 
            lblTongKhoaThuong.AutoSize = true;
            lblTongKhoaThuong.Font = new Font("Segoe UI", 9F);
            lblTongKhoaThuong.ForeColor = Color.DimGray;
            lblTongKhoaThuong.Location = new Point(23, 55);
            lblTongKhoaThuong.Name = "lblTongKhoaThuong";
            lblTongKhoaThuong.Text = "🔒 Đang khóa: 0   |   📄 Thường: 0";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(23, 93);
            lblTen.Name = "lblTen";
            lblTen.Text = "Tên văn bản:";
            // 
            // txtTimTen
            // 
            txtTimTen.Location = new Point(120, 89);
            txtTimTen.Name = "txtTimTen";
            txtTimTen.Size = new Size(228, 27);
            txtTimTen.TabIndex = 2;
            // 
            // lblSoDen
            // 
            lblSoDen.AutoSize = true;
            lblSoDen.Location = new Point(366, 93);
            lblSoDen.Name = "lblSoDen";
            lblSoDen.Text = "Số đến:";
            // 
            // txtTimSoDen
            // 
            txtTimSoDen.Location = new Point(434, 89);
            txtTimSoDen.Name = "txtTimSoDen";
            txtTimSoDen.Size = new Size(159, 27);
            txtTimSoDen.TabIndex = 3;
            // 
            // chkLocNgay
            // 
            chkLocNgay.AutoSize = true;
            chkLocNgay.Location = new Point(23, 137);
            chkLocNgay.Name = "chkLocNgay";
            chkLocNgay.Text = "Lọc theo Ngày nhận:";
            chkLocNgay.CheckedChanged += ChkLocNgay_CheckedChanged;
            // 
            // dtpTimNgay
            // 
            dtpTimNgay.Enabled = false;
            dtpTimNgay.Format = DateTimePickerFormat.Custom;
            dtpTimNgay.CustomFormat = "dd/MM/yyyy";
            dtpTimNgay.Location = new Point(183, 133);
            dtpTimNgay.Name = "dtpTimNgay";
            dtpTimNgay.Size = new Size(148, 27);
            dtpTimNgay.TabIndex = 4;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(434, 129);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(126, 40);
            btnTimKiem.TabIndex = 5;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(571, 129);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(114, 40);
            btnHienTatCa.TabIndex = 6;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.Click += BtnHienTatCa_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new Point(709, 129);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 40);
            btnSua.TabIndex = 7;
            btnSua.Text = "Sửa";
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(800, 129);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(91, 40);
            btnXoa.TabIndex = 8;
            btnXoa.Text = "Xóa";
            btnXoa.Click += BtnXoa_Click;
            // 
            // chkSapXepNgay
            // 
            chkSapXepNgay.AutoSize = true;
            chkSapXepNgay.Location = new Point(23, 182);
            chkSapXepNgay.Name = "chkSapXepNgay";
            chkSapXepNgay.Text = "Sắp xếp theo Ngày nhận (mới nhất lên đầu)";
            chkSapXepNgay.CheckedChanged += ChkSapXepNgay_CheckedChanged;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeight = 29;
            grid.RowHeadersVisible = false;
            grid.Location = new Point(23, 217);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(869, 460);
            grid.TabIndex = 9;
            grid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grid.CellDoubleClick += Grid_CellDoubleClick;
            grid.SelectionChanged += Grid_SelectionChanged;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(23, 687);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblGhiChu.Text = "Nhấp đúp vào 1 dòng để xem chi tiết. Văn bản có độ mật sẽ yêu cầu nhập mật khẩu.";
            // 
            // FormTraCuu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 733);
            Controls.Add(cboLocDoMat);
            Controls.Add(btnLoc);
            Controls.Add(lblDemMat);
            Controls.Add(lblDemToiMat);
            Controls.Add(lblDemTuyetMat);
            Controls.Add(lblTongKhoaThuong);
            Controls.Add(lblTen);
            Controls.Add(txtTimTen);
            Controls.Add(lblSoDen);
            Controls.Add(txtTimSoDen);
            Controls.Add(chkLocNgay);
            Controls.Add(dtpTimNgay);
            Controls.Add(btnTimKiem);
            Controls.Add(btnHienTatCa);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(chkSapXepNgay);
            Controls.Add(grid);
            Controls.Add(lblGhiChu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(930, 770);
            Name = "FormTraCuu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tra cứu văn bản";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}