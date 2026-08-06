namespace QuanlyDL.Forms
{
    partial class FormTaoMatKhauVault
    {
        private System.ComponentModel.IContainer components = null!;
        private Label lblTieuDe = null!;
        private Label lblMk1 = null!;
        private Label lblMk2 = null!;
        private TextBox txtMk1 = null!;
        private TextBox txtMk2 = null!;
        private Button btnOk = null!;
        private Button btnHuy = null!;
        private Label lblGhiChu = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTieuDe = new Label();
            lblMk1 = new Label();
            lblMk2 = new Label();
            txtMk1 = new TextBox();
            txtMk2 = new TextBox();
            btnOk = new Button();
            btnHuy = new Button();
            lblGhiChu = new Label();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Text = "Thiết lập mật khẩu Vùng lưu trữ có khóa";

            lblGhiChu.AutoSize = false;
            lblGhiChu.Location = new Point(20, 45);
            lblGhiChu.Size = new Size(360, 40);
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Text = "Mật khẩu này dùng để mã hóa/giải mã văn bản có độ mật. " +
                "Vui lòng ghi nhớ kỹ, nếu mất mật khẩu sẽ không thể khôi phục dữ liệu đã mã hóa.";

            lblMk1.AutoSize = true;
            lblMk1.Location = new Point(20, 95);
            lblMk1.Text = "Mật khẩu mới:";

            txtMk1.Location = new Point(150, 92);
            txtMk1.Size = new Size(220, 23);
            txtMk1.UseSystemPasswordChar = true;

            lblMk2.AutoSize = true;
            lblMk2.Location = new Point(20, 128);
            lblMk2.Text = "Nhập lại mật khẩu:";

            txtMk2.Location = new Point(150, 125);
            txtMk2.Size = new Size(220, 23);
            txtMk2.UseSystemPasswordChar = true;

            btnOk.Text = "Đồng ý";
            btnOk.Location = new Point(195, 170);
            btnOk.Size = new Size(85, 30);
            btnOk.Click += BtnOk_Click;

            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(285, 170);
            btnHuy.Size = new Size(85, 30);
            btnHuy.DialogResult = DialogResult.Cancel;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 220);
            Controls.Add(lblTieuDe);
            Controls.Add(lblGhiChu);
            Controls.Add(lblMk1);
            Controls.Add(txtMk1);
            Controls.Add(lblMk2);
            Controls.Add(txtMk2);
            Controls.Add(btnOk);
            Controls.Add(btnHuy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tạo mật khẩu";
            AcceptButton = btnOk;
            CancelButton = btnHuy;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
