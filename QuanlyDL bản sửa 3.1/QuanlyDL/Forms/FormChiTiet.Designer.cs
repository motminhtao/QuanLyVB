namespace QuanlyDL.Forms
{
    partial class FormChiTiet
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblTieuDe = null!;
        private Label lblKhoaTrangThai = null!;
        private TableLayoutPanel layout = null!;

        private TextBox txtTen = null!;
        private TextBox txtSoDen = null!;
        private TextBox txtNgayNhan = null!;
        private TextBox txtChuyen = null!;
        private TextBox txtSoKyHieu = null!;
        private TextBox txtNoiDung = null!;
        private TextBox txtCanBo = null!;
        private TextBox txtDoMat = null!;
        private TextBox txtNgayHoanThanh = null!;
        private TextBox txtTrangThaiHoanThanh = null!;
        private Button btnMoTep = null!;
        private Label lblTep = null!;

        private Button btnDanhDauHoanThanh = null!;
        private Button btnDong = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblKhoaTrangThai = new Label();
            layout = new TableLayoutPanel();

            txtTen = TaoOChiDoc();
            txtSoDen = TaoOChiDoc();
            txtNgayNhan = TaoOChiDoc();
            txtChuyen = TaoOChiDoc();
            txtSoKyHieu = TaoOChiDoc();
            txtNoiDung = TaoOChiDoc(); txtNoiDung.Multiline = true; txtNoiDung.ScrollBars = ScrollBars.Vertical;
            txtCanBo = TaoOChiDoc();
            txtDoMat = TaoOChiDoc();
            txtNgayHoanThanh = TaoOChiDoc();
            txtTrangThaiHoanThanh = TaoOChiDoc();

            lblTep = new Label();
            btnMoTep = new Button();

            btnDanhDauHoanThanh = new Button();
            btnDong = new Button();

            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Text = "CHI TIẾT VĂN BẢN";

            lblKhoaTrangThai.AutoSize = true;
            lblKhoaTrangThai.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblKhoaTrangThai.Location = new Point(22, 45);
            lblKhoaTrangThai.ForeColor = Color.DarkRed;

            layout.ColumnCount = 2;
            layout.RowCount = 10;
            layout.Location = new Point(20, 75);
            layout.Size = new Size(560, 400);
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            for (int i = 0; i < 9; i++) layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 32));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));

            void Hang(string nhan, Control ctrl, int row)
            {
                var lbl = new Label { Text = nhan, AutoSize = true, Anchor = AnchorStyles.Left, Margin = new Padding(3, 8, 3, 3) };
                ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                ctrl.Margin = new Padding(3, 3, 3, 3);
                layout.Controls.Add(lbl, 0, row);
                layout.Controls.Add(ctrl, 1, row);
            }

            Hang("Tên văn bản:", txtTen, 0);
            Hang("Số đến:", txtSoDen, 1);
            Hang("Ngày nhận:", txtNgayNhan, 2);
            Hang("Chuyển:", txtChuyen, 3);
            Hang("Số và ký hiệu HS:", txtSoKyHieu, 4);
            Hang("Nội dung:", txtNoiDung, 5);
            Hang("Cán bộ tiếp nhận:", txtCanBo, 6);
            Hang("Độ mật:", txtDoMat, 7);
            Hang("Ngày hoàn thành:", txtNgayHoanThanh, 8);

            var pnlTep = new Panel { Dock = DockStyle.Fill, Margin = new Padding(3) };
            lblTep.AutoSize = true;
            lblTep.Location = new Point(0, 5);
            lblTep.Text = "(không có tệp đính kèm)";
            btnMoTep.Text = "Mở tệp đính kèm";
            btnMoTep.Location = new Point(200, 0);
            btnMoTep.Width = 150;
            btnMoTep.Enabled = false;
            btnMoTep.Click += BtnMoTep_Click;
            pnlTep.Controls.Add(lblTep);
            pnlTep.Controls.Add(btnMoTep);
            Hang("Tệp đính kèm:", pnlTep, 9);

            btnDanhDauHoanThanh.Text = "Đánh dấu đã hoàn thành";
            btnDanhDauHoanThanh.Location = new Point(20, 490);
            btnDanhDauHoanThanh.Size = new Size(190, 34);
            btnDanhDauHoanThanh.Click += BtnDanhDauHoanThanh_Click;

            btnDong.Text = "Đóng";
            btnDong.Location = new Point(500, 490);
            btnDong.Size = new Size(80, 34);
            btnDong.DialogResult = DialogResult.OK;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 545);
            Controls.Add(lblTieuDe);
            Controls.Add(lblKhoaTrangThai);
            Controls.Add(layout);
            Controls.Add(btnDanhDauHoanThanh);
            Controls.Add(btnDong);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết văn bản";
            ResumeLayout(false);
            PerformLayout();
        }

        private static TextBox TaoOChiDoc() => new TextBox { ReadOnly = true, BackColor = Color.WhiteSmoke };
    }
}
