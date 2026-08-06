namespace QuanlyDL.Forms
{
    partial class FormNhapVanBan
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblTieuDe = null!;
        private Label lblGhiChuBatBuoc = null!;
        private TableLayoutPanel layout = null!;

        private Label lblTen = null!;
        private TextBox txtTen = null!;
        private Label lblSoDen = null!;
        private TextBox txtSoDen = null!;
        private Label lblNgayNhan = null!;
        private DateTimePicker dtpNgayNhan = null!;
        private Label lblChuyen = null!;
        private TextBox txtChuyen = null!;
        private Label lblSoKyHieu = null!;
        private TextBox txtSoKyHieu = null!;
        private Label lblNoiDung = null!;
        private TextBox txtNoiDung = null!;
        private Label lblCanBo = null!;
        private TextBox txtCanBo = null!;
        private Label lblDoMat = null!;
        private ComboBox cboDoMat = null!;

        private Label lblNhanNgayHT = null!;
        private Panel pnlHan = null!;
        private CheckBox chkCoHan = null!;
        private DateTimePicker dtpNgayHoanThanh = null!;

        private Label lblNhanTep = null!;
        private Panel pnlTep = null!;
        private TextBox txtTenTepChon = null!;
        private Button btnChonTep = null!;

        private Button btnLuu = null!;
        private Button btnHuy = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNhapVanBan));
            lblTieuDe = new Label();
            lblGhiChuBatBuoc = new Label();
            layout = new TableLayoutPanel();
            lblTen = new Label();
            txtTen = new TextBox();
            lblSoDen = new Label();
            txtSoDen = new TextBox();
            lblNgayNhan = new Label();
            dtpNgayNhan = new DateTimePicker();
            lblChuyen = new Label();
            txtChuyen = new TextBox();
            lblSoKyHieu = new Label();
            txtSoKyHieu = new TextBox();
            lblNoiDung = new Label();
            txtNoiDung = new TextBox();
            lblCanBo = new Label();
            txtCanBo = new TextBox();
            lblDoMat = new Label();
            cboDoMat = new ComboBox();
            lblNhanNgayHT = new Label();
            pnlHan = new Panel();
            chkCoHan = new CheckBox();
            dtpNgayHoanThanh = new DateTimePicker();
            lblNhanTep = new Label();
            pnlTep = new Panel();
            txtTenTepChon = new TextBox();
            btnChonTep = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            layout.SuspendLayout();
            pnlHan.SuspendLayout();
            pnlTep.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTieuDe.Location = new Point(23, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(280, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "NHẬP VĂN BẢN LƯU TRỮ";
            // 
            // lblGhiChuBatBuoc
            // 
            lblGhiChuBatBuoc.AutoSize = true;
            lblGhiChuBatBuoc.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGhiChuBatBuoc.ForeColor = Color.Red;
            lblGhiChuBatBuoc.Location = new Point(25, 60);
            lblGhiChuBatBuoc.Name = "lblGhiChuBatBuoc";
            lblGhiChuBatBuoc.Size = new Size(271, 20);
            lblGhiChuBatBuoc.TabIndex = 1;
            lblGhiChuBatBuoc.Text = "(*) Các mục có dấu sao là bắt buộc nhập";
            // 
            // layout
            // 
            layout.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 183F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.Controls.Add(lblTen, 0, 0);
            layout.Controls.Add(txtTen, 1, 0);
            layout.Controls.Add(lblSoDen, 0, 1);
            layout.Controls.Add(txtSoDen, 1, 1);
            layout.Controls.Add(lblNgayNhan, 0, 2);
            layout.Controls.Add(dtpNgayNhan, 1, 2);
            layout.Controls.Add(lblChuyen, 0, 3);
            layout.Controls.Add(txtChuyen, 1, 3);
            layout.Controls.Add(lblSoKyHieu, 0, 4);
            layout.Controls.Add(txtSoKyHieu, 1, 4);
            layout.Controls.Add(lblNoiDung, 0, 5);
            layout.Controls.Add(txtNoiDung, 1, 5);
            layout.Controls.Add(lblCanBo, 0, 6);
            layout.Controls.Add(txtCanBo, 1, 6);
            layout.Controls.Add(lblDoMat, 0, 7);
            layout.Controls.Add(cboDoMat, 1, 7);
            layout.Controls.Add(lblNhanNgayHT, 0, 8);
            layout.Controls.Add(pnlHan, 1, 8);
            layout.Controls.Add(lblNhanTep, 0, 9);
            layout.Controls.Add(pnlTep, 1, 9);
            layout.Location = new Point(23, 100);
            layout.Margin = new Padding(3, 4, 3, 4);
            layout.Name = "layout";
            layout.RowCount = 10;
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 53F));
            layout.Size = new Size(640, 573);
            layout.TabIndex = 2;
            // 
            // lblTen
            // 
            lblTen.Anchor = AnchorStyles.Left;
            lblTen.AutoSize = true;
            lblTen.Location = new Point(3, 16);
            lblTen.Margin = new Padding(3, 11, 3, 4);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(128, 20);
            lblTen.TabIndex = 0;
            lblTen.Text = "1. Số công văn (*):";
            // 
            // txtTen
            // 
            txtTen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTen.Location = new Point(186, 9);
            txtTen.Margin = new Padding(3, 4, 3, 4);
            txtTen.Name = "txtTen";
            txtTen.Size = new Size(451, 27);
            txtTen.TabIndex = 1;
            // 
            // lblSoDen
            // 
            lblSoDen.Anchor = AnchorStyles.Left;
            lblSoDen.AutoSize = true;
            lblSoDen.Location = new Point(3, 61);
            lblSoDen.Margin = new Padding(3, 11, 3, 4);
            lblSoDen.Name = "lblSoDen";
            lblSoDen.Size = new Size(93, 20);
            lblSoDen.TabIndex = 2;
            lblSoDen.Text = "2. Số đến (*):";
            // 
            // txtSoDen
            // 
            txtSoDen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSoDen.Location = new Point(186, 54);
            txtSoDen.Margin = new Padding(3, 4, 3, 4);
            txtSoDen.Name = "txtSoDen";
            txtSoDen.Size = new Size(451, 27);
            txtSoDen.TabIndex = 3;
            // 
            // lblNgayNhan
            // 
            lblNgayNhan.Anchor = AnchorStyles.Left;
            lblNgayNhan.AutoSize = true;
            lblNgayNhan.Location = new Point(3, 106);
            lblNgayNhan.Margin = new Padding(3, 11, 3, 4);
            lblNgayNhan.Name = "lblNgayNhan";
            lblNgayNhan.Size = new Size(118, 20);
            lblNgayNhan.TabIndex = 4;
            lblNgayNhan.Text = "3. Ngày nhận (*):";
            // 
            // dtpNgayNhan
            // 
            dtpNgayNhan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dtpNgayNhan.CustomFormat = "dd/MM/yyyy";
            dtpNgayNhan.Format = DateTimePickerFormat.Custom;
            dtpNgayNhan.Location = new Point(186, 99);
            dtpNgayNhan.Margin = new Padding(3, 4, 3, 4);
            dtpNgayNhan.Name = "dtpNgayNhan";
            dtpNgayNhan.Size = new Size(451, 27);
            dtpNgayNhan.TabIndex = 5;
            // 
            // lblChuyen
            // 
            lblChuyen.Anchor = AnchorStyles.Left;
            lblChuyen.AutoSize = true;
            lblChuyen.Location = new Point(3, 151);
            lblChuyen.Margin = new Padding(3, 11, 3, 4);
            lblChuyen.Name = "lblChuyen";
            lblChuyen.Size = new Size(75, 20);
            lblChuyen.TabIndex = 6;
            lblChuyen.Text = "4. Chuyển:";
            // 
            // txtChuyen
            // 
            txtChuyen.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtChuyen.Location = new Point(186, 144);
            txtChuyen.Margin = new Padding(3, 4, 3, 4);
            txtChuyen.Name = "txtChuyen";
            txtChuyen.Size = new Size(451, 27);
            txtChuyen.TabIndex = 7;
            // 
            // lblSoKyHieu
            // 
            lblSoKyHieu.Anchor = AnchorStyles.Left;
            lblSoKyHieu.AutoSize = true;
            lblSoKyHieu.Location = new Point(3, 196);
            lblSoKyHieu.Margin = new Padding(3, 11, 3, 4);
            lblSoKyHieu.Name = "lblSoKyHieu";
            lblSoKyHieu.Size = new Size(91, 20);
            lblSoKyHieu.TabIndex = 8;
            lblSoKyHieu.Text = "5. Lưu hồ sơ:";
            // 
            // txtSoKyHieu
            // 
            txtSoKyHieu.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtSoKyHieu.Location = new Point(186, 189);
            txtSoKyHieu.Margin = new Padding(3, 4, 3, 4);
            txtSoKyHieu.Name = "txtSoKyHieu";
            txtSoKyHieu.Size = new Size(451, 27);
            txtSoKyHieu.TabIndex = 9;
            // 
            // lblNoiDung
            // 
            lblNoiDung.AutoSize = true;
            lblNoiDung.Location = new Point(3, 236);
            lblNoiDung.Margin = new Padding(3, 11, 3, 4);
            lblNoiDung.Name = "lblNoiDung";
            lblNoiDung.Size = new Size(85, 20);
            lblNoiDung.TabIndex = 10;
            lblNoiDung.Text = "6. Trích yếu:";
            // 
            // txtNoiDung
            // 
            txtNoiDung.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtNoiDung.Location = new Point(186, 229);
            txtNoiDung.Margin = new Padding(3, 4, 3, 4);
            txtNoiDung.Multiline = true;
            txtNoiDung.Name = "txtNoiDung";
            txtNoiDung.ScrollBars = ScrollBars.Vertical;
            txtNoiDung.Size = new Size(451, 152);
            txtNoiDung.TabIndex = 11;
            // 
            // lblCanBo
            // 
            lblCanBo.Anchor = AnchorStyles.Left;
            lblCanBo.AutoSize = true;
            lblCanBo.Location = new Point(3, 401);
            lblCanBo.Margin = new Padding(3, 11, 3, 4);
            lblCanBo.Name = "lblCanBo";
            lblCanBo.Size = new Size(108, 20);
            lblCanBo.TabIndex = 12;
            lblCanBo.Text = "7. Cán bộ sử lý:";
            // 
            // txtCanBo
            // 
            txtCanBo.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCanBo.Location = new Point(186, 394);
            txtCanBo.Margin = new Padding(3, 4, 3, 4);
            txtCanBo.Name = "txtCanBo";
            txtCanBo.Size = new Size(451, 27);
            txtCanBo.TabIndex = 13;
            // 
            // lblDoMat
            // 
            lblDoMat.Anchor = AnchorStyles.Left;
            lblDoMat.AutoSize = true;
            lblDoMat.Location = new Point(3, 446);
            lblDoMat.Margin = new Padding(3, 11, 3, 4);
            lblDoMat.Name = "lblDoMat";
            lblDoMat.Size = new Size(77, 20);
            lblDoMat.TabIndex = 14;
            lblDoMat.Text = "8. Độ mật:";
            // 
            // cboDoMat
            // 
            cboDoMat.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cboDoMat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoMat.Items.AddRange(new object[] { "Không", "Mật", "Tuyệt Mật", "Tối Mật" });
            cboDoMat.Location = new Point(186, 438);
            cboDoMat.Margin = new Padding(3, 4, 3, 4);
            cboDoMat.Name = "cboDoMat";
            cboDoMat.Size = new Size(451, 28);
            cboDoMat.TabIndex = 15;
            // 
            // lblNhanNgayHT
            // 
            lblNhanNgayHT.Anchor = AnchorStyles.Left;
            lblNhanNgayHT.AutoSize = true;
            lblNhanNgayHT.Location = new Point(3, 491);
            lblNhanNgayHT.Margin = new Padding(3, 11, 3, 4);
            lblNhanNgayHT.Name = "lblNhanNgayHT";
            lblNhanNgayHT.Size = new Size(140, 20);
            lblNhanNgayHT.TabIndex = 16;
            lblNhanNgayHT.Text = "9. Ngày hoàn thành:";
            // 
            // pnlHan
            // 
            pnlHan.Controls.Add(chkCoHan);
            pnlHan.Controls.Add(dtpNgayHoanThanh);
            pnlHan.Dock = DockStyle.Fill;
            pnlHan.Location = new Point(186, 479);
            pnlHan.Margin = new Padding(3, 4, 3, 4);
            pnlHan.Name = "pnlHan";
            pnlHan.Size = new Size(451, 37);
            pnlHan.TabIndex = 17;
            // 
            // chkCoHan
            // 
            chkCoHan.AutoSize = true;
            chkCoHan.Location = new Point(0, 7);
            chkCoHan.Margin = new Padding(3, 4, 3, 4);
            chkCoHan.Name = "chkCoHan";
            chkCoHan.Size = new Size(49, 24);
            chkCoHan.TabIndex = 0;
            chkCoHan.Text = "Có";
            chkCoHan.CheckedChanged += ChkCoHan_CheckedChanged;
            // 
            // dtpNgayHoanThanh
            // 
            dtpNgayHoanThanh.CustomFormat = "dd/MM/yyyy";
            dtpNgayHoanThanh.Enabled = false;
            dtpNgayHoanThanh.Format = DateTimePickerFormat.Custom;
            dtpNgayHoanThanh.Location = new Point(63, 1);
            dtpNgayHoanThanh.Margin = new Padding(3, 4, 3, 4);
            dtpNgayHoanThanh.Name = "dtpNgayHoanThanh";
            dtpNgayHoanThanh.Size = new Size(171, 27);
            dtpNgayHoanThanh.TabIndex = 1;
            // 
            // lblNhanTep
            // 
            lblNhanTep.Anchor = AnchorStyles.Left;
            lblNhanTep.AutoSize = true;
            lblNhanTep.Location = new Point(3, 540);
            lblNhanTep.Margin = new Padding(3, 11, 3, 4);
            lblNhanTep.Name = "lblNhanTep";
            lblNhanTep.Size = new Size(102, 20);
            lblNhanTep.TabIndex = 18;
            lblNhanTep.Text = "Tệp đính kèm:";
            // 
            // pnlTep
            // 
            pnlTep.Controls.Add(txtTenTepChon);
            pnlTep.Controls.Add(btnChonTep);
            pnlTep.Dock = DockStyle.Fill;
            pnlTep.Location = new Point(186, 524);
            pnlTep.Margin = new Padding(3, 4, 3, 4);
            pnlTep.Name = "pnlTep";
            pnlTep.Size = new Size(451, 45);
            pnlTep.TabIndex = 19;
            // 
            // txtTenTepChon
            // 
            txtTenTepChon.Location = new Point(0, 1);
            txtTenTepChon.Margin = new Padding(3, 4, 3, 4);
            txtTenTepChon.Name = "txtTenTepChon";
            txtTenTepChon.ReadOnly = true;
            txtTenTepChon.Size = new Size(342, 27);
            txtTenTepChon.TabIndex = 0;
            // 
            // btnChonTep
            // 
            btnChonTep.Location = new Point(349, 0);
            btnChonTep.Margin = new Padding(3, 4, 3, 4);
            btnChonTep.Name = "btnChonTep";
            btnChonTep.Size = new Size(126, 31);
            btnChonTep.TabIndex = 1;
            btnChonTep.Text = "Đính kèm tệp...";
            btnChonTep.Click += BtnChonTep_Click;
            // 
            // btnLuu
            // 
            btnLuu.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuu.BackColor = Color.FromArgb(0, 120, 215);
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(423, 693);
            btnLuu.Margin = new Padding(3, 4, 3, 4);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(126, 48);
            btnLuu.TabIndex = 3;
            btnLuu.Text = "Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += BtnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnHuy.BackColor = Color.IndianRed;
            btnHuy.DialogResult = DialogResult.Cancel;
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(560, 693);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(103, 48);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            // 
            // FormNhapVanBan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 767);
            Controls.Add(lblTieuDe);
            Controls.Add(lblGhiChuBatBuoc);
            Controls.Add(layout);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(683, 751);
            Name = "FormNhapVanBan";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập văn bản mới";
            layout.ResumeLayout(false);
            layout.PerformLayout();
            pnlHan.ResumeLayout(false);
            pnlHan.PerformLayout();
            pnlTep.ResumeLayout(false);
            pnlTep.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}