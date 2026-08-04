namespace QuanlyDL.Forms
{
    partial class FormTraCuu
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblTieuDe = null!;
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
            lblTieuDe = new Label();
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
            grid = new DataGridView();
            lblGhiChu = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.Location = new Point(611, 72);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(100, 23);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Visible = false;
            // 
            // cboLocDoMat
            // 
            cboLocDoMat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocDoMat.Items.AddRange(new object[] { "Tất cả độ mật", "Không", "Mật", "Tuyệt Mật", "Tối Mật" });
            cboLocDoMat.Location = new Point(23, 20);
            cboLocDoMat.Name = "cboLocDoMat";
            cboLocDoMat.Size = new Size(160, 28);
            cboLocDoMat.TabIndex = 0;
            // 
            // btnLoc
            // 
            btnLoc.Location = new Point(191, 17);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new Size(130, 34);
            btnLoc.TabIndex = 20;
            btnLoc.Text = "Lọc theo độ mật";
            btnLoc.Click += BtnLoc_Click;
            // 
            // lblDemMat
            // 
            lblDemMat.AutoSize = true;
            lblDemMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDemMat.ForeColor = Color.DarkOrange;
            lblDemMat.Location = new Point(330, 25);
            lblDemMat.Name = "lblDemMat";
            lblDemMat.Size = new Size(54, 20);
            lblDemMat.TabIndex = 21;
            lblDemMat.Text = "Mật: 0";
            // 
            // lblDemToiMat
            // 
            lblDemToiMat.AutoSize = true;
            lblDemToiMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDemToiMat.ForeColor = Color.OrangeRed;
            lblDemToiMat.Location = new Point(420, 25);
            lblDemToiMat.Name = "lblDemToiMat";
            lblDemToiMat.Size = new Size(80, 20);
            lblDemToiMat.TabIndex = 22;
            lblDemToiMat.Text = "Tối Mật: 0";
            // 
            // lblDemTuyetMat
            // 
            lblDemTuyetMat.AutoSize = true;
            lblDemTuyetMat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDemTuyetMat.ForeColor = Color.DarkRed;
            lblDemTuyetMat.Location = new Point(530, 25);
            lblDemTuyetMat.Name = "lblDemTuyetMat";
            lblDemTuyetMat.Size = new Size(97, 20);
            lblDemTuyetMat.TabIndex = 23;
            lblDemTuyetMat.Text = "Tuyệt Mật: 0";
            // 
            // lblTongKhoaThuong
            // 
            lblTongKhoaThuong.AutoSize = true;
            lblTongKhoaThuong.Font = new Font("Segoe UI", 9F);
            lblTongKhoaThuong.ForeColor = Color.DimGray;
            lblTongKhoaThuong.Location = new Point(659, 25);
            lblTongKhoaThuong.Name = "lblTongKhoaThuong";
            lblTongKhoaThuong.Size = new Size(232, 20);
            lblTongKhoaThuong.TabIndex = 24;
            lblTongKhoaThuong.Text = "🔒 Đang khóa: 0   |   📄 Thường: 0";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(23, 73);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(91, 20);
            lblTen.TabIndex = 1;
            lblTen.Text = "Tên văn bản:";
            // 
            // txtTimTen
            // 
            txtTimTen.Location = new Point(120, 69);
            txtTimTen.Margin = new Padding(3, 4, 3, 4);
            txtTimTen.Name = "txtTimTen";
            txtTimTen.Size = new Size(228, 27);
            txtTimTen.TabIndex = 2;
            // 
            // lblSoDen
            // 
            lblSoDen.AutoSize = true;
            lblSoDen.Location = new Point(366, 73);
            lblSoDen.Name = "lblSoDen";
            lblSoDen.Size = new Size(58, 20);
            lblSoDen.TabIndex = 3;
            lblSoDen.Text = "Số đến:";
            // 
            // txtTimSoDen
            // 
            txtTimSoDen.Location = new Point(434, 69);
            txtTimSoDen.Margin = new Padding(3, 4, 3, 4);
            txtTimSoDen.Name = "txtTimSoDen";
            txtTimSoDen.Size = new Size(159, 27);
            txtTimSoDen.TabIndex = 4;
            // 
            // chkLocNgay
            // 
            chkLocNgay.AutoSize = true;
            chkLocNgay.Location = new Point(23, 117);
            chkLocNgay.Margin = new Padding(3, 4, 3, 4);
            chkLocNgay.Name = "chkLocNgay";
            chkLocNgay.Size = new Size(166, 24);
            chkLocNgay.TabIndex = 5;
            chkLocNgay.Text = "Lọc theo Ngày nhận:";
            chkLocNgay.CheckedChanged += ChkLocNgay_CheckedChanged;
            // 
            // dtpTimNgay
            // 
            dtpTimNgay.Enabled = false;
            dtpTimNgay.Format = DateTimePickerFormat.Short;
            dtpTimNgay.Location = new Point(183, 113);
            dtpTimNgay.Margin = new Padding(3, 4, 3, 4);
            dtpTimNgay.Name = "dtpTimNgay";
            dtpTimNgay.Size = new Size(148, 27);
            dtpTimNgay.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(434, 109);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(126, 40);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(571, 109);
            btnHienTatCa.Margin = new Padding(3, 4, 3, 4);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(114, 40);
            btnHienTatCa.TabIndex = 8;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.Click += BtnHienTatCa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = SystemColors.ButtonShadow;
            btnSua.Enabled = false;
            btnSua.Location = new Point(709, 109);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 40);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.IndianRed;
            btnXoa.Enabled = false;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(800, 109);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(91, 40);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += BtnXoa_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeight = 29;
            grid.Location = new Point(23, 171);
            grid.Margin = new Padding(3, 4, 3, 4);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(869, 507);
            grid.TabIndex = 11;
            grid.CellDoubleClick += Grid_CellDoubleClick;
            grid.SelectionChanged += Grid_SelectionChanged;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(23, 687);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(565, 20);
            lblGhiChu.TabIndex = 12;
            lblGhiChu.Text = "Nhấp đúp vào 1 dòng để xem chi tiết. Văn bản có độ mật sẽ yêu cầu nhập mật khẩu.";
            // 
            // FormTraCuu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 733);
            Controls.Add(lblTieuDe);
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
            Controls.Add(grid);
            Controls.Add(lblGhiChu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
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