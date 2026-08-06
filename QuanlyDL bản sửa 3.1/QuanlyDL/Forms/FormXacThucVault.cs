namespace QuanlyDL.Forms
{
    public partial class FormXacThucVault : Form
    {
        public string MatKhau { get; private set; } = "";

        public FormXacThucVault()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMk.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MatKhau = txtMk.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
