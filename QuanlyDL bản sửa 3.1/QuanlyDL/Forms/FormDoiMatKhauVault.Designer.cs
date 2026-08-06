namespace QuanlyDL.Forms
{
    partial class FormDoiMatKhauVault
    {
        private System.ComponentModel.IContainer components = null!;
        private Label lblTieuDe = null!;
        private Label lblGhiChu = null!;
        private Label lblMkHienTai = null!;
        private TextBox txtMkHienTai = null!;
        private Label lblMkMoi = null!;
        private TextBox txtMkMoi = null!;
        private Label lblMkXacNhan = null!;
        private TextBox txtMkXacNhan = null!;
        private Button btnOk = null!;
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
            lblMkHienTai = new Label();
            txtMkHienTai = new TextBox();
            lblMkMoi = new Label();
            txtMkMoi = new TextBox();
            lblMkXacNhan = new Label();
            txtMkXacNhan = new TextBox();
            btnOk = new Button();
            btnHuy = new Button();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Text = "Đổi mật khẩu Vùng lưu trữ có khóa";

            lblGhiChu.AutoSize = false;
            lblGhiChu.Location = new Point(20, 45);
            lblGhiChu.Size = new Size(360, 40);
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Text = "Toàn bộ văn bản có độ mật sẽ được mã hóa lại bằng mật khẩu mới. Quá trình có thể mất chút thời gian nếu có nhiều văn bản.";

            lblMkHienTai.AutoSize = true;
            lblMkHienTai.Location = new Point(20, 95);
            lblMkHienTai.Text = "Mật khẩu hiện tại:";

            txtMkHienTai.Location = new Point(170, 92);
            txtMkHienTai.Size = new Size(200, 23);
            txtMkHienTai.UseSystemPasswordChar = true;

            lblMkMoi.AutoSize = true;
            lblMkMoi.Location = new Point(20, 128);
            lblMkMoi.Text = "Mật khẩu mới:";

            txtMkMoi.Location = new Point(170, 125);
            txtMkMoi.Size = new Size(200, 23);
            txtMkMoi.UseSystemPasswordChar = true;

            lblMkXacNhan.AutoSize = true;
            lblMkXacNhan.Location = new Point(20, 161);
            lblMkXacNhan.Text = "Nhập lại mật khẩu mới:";

            txtMkXacNhan.Location = new Point(170, 158);
            txtMkXacNhan.Size = new Size(200, 23);
            txtMkXacNhan.UseSystemPasswordChar = true;

            btnOk.Text = "Đồng ý";
            btnOk.Location = new Point(195, 200);
            btnOk.Size = new Size(85, 32);
            btnOk.Click += BtnOk_Click;

            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(285, 200);
            btnHuy.Size = new Size(85, 32);
            btnHuy.DialogResult = DialogResult.Cancel;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 250);
            Controls.Add(lblTieuDe);
            Controls.Add(lblGhiChu);
            Controls.Add(lblMkHienTai);
            Controls.Add(txtMkHienTai);
            Controls.Add(lblMkMoi);
            Controls.Add(txtMkMoi);
            Controls.Add(lblMkXacNhan);
            Controls.Add(txtMkXacNhan);
            Controls.Add(btnOk);
            Controls.Add(btnHuy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Đổi mật khẩu";
            AcceptButton = btnOk;
            CancelButton = btnHuy;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}