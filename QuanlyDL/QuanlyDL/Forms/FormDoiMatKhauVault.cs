namespace QuanlyDL.Forms
{
    public partial class FormDoiMatKhauVault : Form
    {
        public string MatKhauHienTai { get; private set; } = "";
        public string MatKhauMoi { get; private set; } = "";

        public FormDoiMatKhauVault()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMkHienTai.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtMkMoi.Text) || txtMkMoi.Text.Length < 4)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMkMoi.Text != txtMkXacNhan.Text)
            {
                MessageBox.Show("Mật khẩu mới nhập lại không khớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MatKhauHienTai = txtMkHienTai.Text;
            MatKhauMoi = txtMkMoi.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}