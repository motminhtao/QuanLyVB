namespace QuanlyDL.Forms
{
    partial class FormXacThucVault
    {
        private System.ComponentModel.IContainer components = null!;
        private Label lblTieuDe = null!;
        private Label lblMk = null!;
        private TextBox txtMk = null!;
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
            lblMk = new Label();
            txtMk = new TextBox();
            btnOk = new Button();
            btnHuy = new Button();
            SuspendLayout();

            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTieuDe.Location = new Point(20, 15);
            lblTieuDe.Text = "Xác thực Vùng lưu trữ có khóa";

            lblMk.AutoSize = true;
            lblMk.Location = new Point(20, 60);
            lblMk.Text = "Nhập mật khẩu:";

            txtMk.Location = new Point(150, 57);
            txtMk.Size = new Size(200, 23);
            txtMk.UseSystemPasswordChar = true;

            btnOk.Text = "Đồng ý";
            btnOk.Location = new Point(175, 100);
            btnOk.Size = new Size(85, 30);
            btnOk.Click += BtnOk_Click;

            btnHuy.Text = "Hủy";
            btnHuy.Location = new Point(265, 100);
            btnHuy.Size = new Size(85, 30);
            btnHuy.DialogResult = DialogResult.Cancel;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 150);
            Controls.Add(lblTieuDe);
            Controls.Add(lblMk);
            Controls.Add(txtMk);
            Controls.Add(btnOk);
            Controls.Add(btnHuy);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Xác thực";
            AcceptButton = btnOk;
            CancelButton = btnHuy;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
