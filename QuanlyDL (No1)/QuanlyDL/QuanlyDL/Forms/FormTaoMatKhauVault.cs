namespace QuanlyDL.Forms
{
    public partial class FormTaoMatKhauVault : Form
    {
        public string MatKhau { get; private set; } = "";

        public FormTaoMatKhauVault()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMk1.Text) || txtMk1.Text.Length < 4)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 4 ký tự.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMk1.Text != txtMk2.Text)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MatKhau = txtMk1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
