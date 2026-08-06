namespace QuanlyDL.Forms
{
    partial class FormCaiDat
    {
        private System.ComponentModel.IContainer components = null!;
        private Label lblTieuDe = null!;
        private Label lblGhiChu = null!;
        private Label lblSoNgay = null!;
        private NumericUpDown nudSoNgay = null!;
        private CheckBox chkHienThongBaoLuuMat = null!;
        private CheckBox chkTuDongTimTraCuu = null!;
        private CheckBox chkKhoiDongCungWindows = null!;
        private Button btnDoiMatKhau = null!;
        private Button btnLuu = null!;
        private Button btnHuy = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblGhiChu = new Label();
            lblSoNgay = new Label();
            nudSoNgay = new NumericUpDown();
            chkHienThongBaoLuuMat = new CheckBox();
            chkTuDongTimTraCuu = new CheckBox();
            chkKhoiDongCungWindows = new CheckBox();
            btnDoiMatKhau = new Button();
            btnLuu = new Button();
            btnHuy = new Button();
            ((System.ComponentModel.ISupportInitialize)nudSoNgay).BeginInit();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Text = "Cài đặt";

            lblGhiChu.AutoSize = false;
            lblGhiChu.Location = new Point(20, 48);
            lblGhiChu.Size = new Size(360, 40);
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Text = "Hệ thống sẽ thông báo nhắc nhở khi văn bản còn từ 0 đến X ngày " +
                "là tới [Ngày Hoàn Thành] (mỗi lần mở chương trình).";

            lblSoNgay.AutoSize = true;
            lblSoNgay.Location = new Point(20, 100);
            lblSoNgay.Text = "Số ngày báo trước (X):";

            nudSoNgay.Location = new Point(190, 97);
            nudSoNgay.Size = new Size(80, 23);
            nudSoNgay.Minimum = 0;
            nudSoNgay.Maximum = 90;
            nudSoNgay.Value = 2;

            chkHienThongBaoLuuMat.AutoSize = true;
            chkHienThongBaoLuuMat.Location = new Point(20, 140);
            chkHienThongBaoLuuMat.Text = "Hiển thị thông báo khi lưu văn bản Mật";

            chkTuDongTimTraCuu.AutoSize = true;
            chkTuDongTimTraCuu.Location = new Point(20, 170);
            chkTuDongTimTraCuu.Text = "Tự động tìm kiếm khi nhập (Tra cứu)";

            chkKhoiDongCungWindows.AutoSize = true;
            chkKhoiDongCungWindows.Location = new Point(20, 200);
            chkKhoiDongCungWindows.Text = "Khởi động cùng Windows";

            btnDoiMatKhau.Text = "Đổi mật khẩu vùng có khóa...";
            btnDoiMatKhau.Location = new Point(20, 235);
            btnDoiMatKhau.Size = new Size(230, 32);
            btnDoiMatKhau.Click += BtnDoiMatKhau_Click;

            btnLuu.Text = "Lưu";
            btnLuu.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnLuu.Location = new Point(180, 285);
            btnLuu.Size = new Size(90, 34);
            btnLuu.BackColor = Color.FromArgb(0, 120, 215);
            btnLuu.ForeColor = Color.White;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.Click += BtnLuu_Click;

            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(280, 285);
            btnHuy.Size = new Size(90, 34);
            btnHuy.DialogResult = DialogResult.Cancel;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 340);
            Controls.Add(lblTieuDe);
            Controls.Add(lblGhiChu);
            Controls.Add(lblSoNgay);
            Controls.Add(nudSoNgay);
            Controls.Add(chkHienThongBaoLuuMat);
            Controls.Add(chkTuDongTimTraCuu);
            Controls.Add(chkKhoiDongCungWindows);
            Controls.Add(btnDoiMatKhau);
            Controls.Add(btnLuu);
            Controls.Add(btnHuy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cài đặt";
            AcceptButton = btnLuu;
            CancelButton = btnHuy;
            ((System.ComponentModel.ISupportInitialize)nudSoNgay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}