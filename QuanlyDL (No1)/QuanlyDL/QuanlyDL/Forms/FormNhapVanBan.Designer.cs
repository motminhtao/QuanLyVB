namespace QuanlyDL.Forms
{
    partial class FormNhapVanBan
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblTieuDe = null!;
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
        private CheckBox chkCoHan = null!;
        private DateTimePicker dtpNgayHoanThanh = null!;
        private Label lblTep = null!;
        private TextBox txtTenTepChon = null!;
        private Button btnChonTep = null!;

        private Button btnLuu = null!;
        private Button btnHuy = null!;
        private Label lblGhiChuBatBuoc = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            layout = new TableLayoutPanel();

            lblTen = new Label(); txtTen = new TextBox();
            lblSoDen = new Label(); txtSoDen = new TextBox();
            lblNgayNhan = new Label(); dtpNgayNhan = new DateTimePicker();
            lblChuyen = new Label(); txtChuyen = new TextBox();
            lblSoKyHieu = new Label(); txtSoKyHieu = new TextBox();
            lblNoiDung = new Label(); txtNoiDung = new TextBox();
            lblCanBo = new Label(); txtCanBo = new TextBox();
            lblDoMat = new Label(); cboDoMat = new ComboBox();
            chkCoHan = new CheckBox(); dtpNgayHoanThanh = new DateTimePicker();
            lblTep = new Label(); txtTenTepChon = new TextBox(); btnChonTep = new Button();

            btnLuu = new Button();
            btnHuy = new Button();
            lblGhiChuBatBuoc = new Label();

            SuspendLayout();

            // Tiêu đề
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Text = "NHẬP VĂN BẢN LƯU TRỮ";

            lblGhiChuBatBuoc.AutoSize = true;
            lblGhiChuBatBuoc.ForeColor = Color.Red;
            lblGhiChuBatBuoc.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblGhiChuBatBuoc.Location = new Point(22, 45);
            lblGhiChuBatBuoc.Text = "(*) Các mục có dấu sao là bắt buộc nhập";

            // ------- layout dạng lưới 2 cột: nhãn - control -------
            layout.ColumnCount = 2;
            layout.RowCount = 11;
            layout.Location = new Point(20, 75);
            layout.Size = new Size(560, 430);
            layout.AutoSize = false;
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < 10; i++) layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 90)); // dòng Nội dung cao hơn

            void ThemHang(Label lbl, Control ctrl, string text, int row)
            {
                lbl.Text = text;
                lbl.AutoSize = true;
                lbl.Anchor = AnchorStyles.Left;
                lbl.Margin = new Padding(3, 8, 3, 3);
                ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                ctrl.Margin = new Padding(3, 3, 3, 3);
                layout.Controls.Add(lbl, 0, row);
                layout.Controls.Add(ctrl, 1, row);
            }

            ThemHang(lblTen, txtTen, "1. Số công văn (*):", 0);
            ThemHang(lblSoDen, txtSoDen, "2. Số đến (*):", 1);

            dtpNgayNhan.Format = DateTimePickerFormat.Short;
            ThemHang(lblNgayNhan, dtpNgayNhan, "3. Ngày nhận (*):", 2);

            ThemHang(lblChuyen, txtChuyen, "4. Chuyển:", 3);
            ThemHang(lblSoKyHieu, txtSoKyHieu, "5. lưu hồ sơ:", 4);

            txtNoiDung.Multiline = true;
            txtNoiDung.ScrollBars = ScrollBars.Vertical;
            lblNoiDung.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            lblNoiDung.Margin = new Padding(3, 8, 3, 3);
            lblNoiDung.AutoSize = true;
            lblNoiDung.Text = "6. Trích yếu:";
            txtNoiDung.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            layout.Controls.Add(lblNoiDung, 0, 5);
            layout.Controls.Add(txtNoiDung, 1, 5);

            ThemHang(lblCanBo, txtCanBo, "7. Cán bộ sử lý:", 6);

            cboDoMat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboDoMat.Items.AddRange(Models.DoMat.TatCa);
            cboDoMat.SelectedIndex = 0;
            ThemHang(lblDoMat, cboDoMat, "8. Độ mật:", 7);

            var pnlHan = new Panel { Dock = DockStyle.Fill, Margin = new Padding(3) };
            chkCoHan.Text = "Có";
            chkCoHan.AutoSize = true;
            chkCoHan.Location = new Point(0, 5);
            chkCoHan.CheckedChanged += ChkCoHan_CheckedChanged;
            dtpNgayHoanThanh.Format = DateTimePickerFormat.Short;
            dtpNgayHoanThanh.Location = new Point(55, 1);
            dtpNgayHoanThanh.Width = 150;
            dtpNgayHoanThanh.Enabled = false;
            pnlHan.Controls.Add(chkCoHan);
            pnlHan.Controls.Add(dtpNgayHoanThanh);
            ThemHang(new Label(), pnlHan, "9. Ngày hoàn thành:", 8);

            var pnlTep = new Panel { Dock = DockStyle.Fill, Margin = new Padding(3) };
            txtTenTepChon.ReadOnly = true;
            txtTenTepChon.Location = new Point(0, 1);
            txtTenTepChon.Width = 300;
            btnChonTep.Text = "Đính kèm tệp...";
            btnChonTep.Location = new Point(305, 0);
            btnChonTep.Width = 110;
            btnChonTep.Click += BtnChonTep_Click;
            pnlTep.Controls.Add(txtTenTepChon);
            pnlTep.Controls.Add(btnChonTep);
            ThemHang(new Label(), pnlTep, "Tệp đính kèm:", 9);

            // Nút Lưu / Hủy
            btnLuu.Text = "Lưu";
            btnLuu.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLuu.Size = new Size(110, 36);
            btnLuu.Location = new Point(370, 520);
            btnLuu.BackColor = Color.FromArgb(0, 120, 215);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Click += BtnLuu_Click;

            btnHuy.Text = "Hủy";
            btnHuy.Size = new Size(90, 36);
            btnHuy.Location = new Point(490, 520);
            btnHuy.DialogResult = DialogResult.Cancel;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 575);
            Controls.Add(lblTieuDe);
            Controls.Add(lblGhiChuBatBuoc);
            Controls.Add(layout);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nhập văn bản mới";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
