using QuanlyDL.Data;
using QuanlyDL.Security;

namespace QuanlyDL.Forms
{
    public partial class FormCaiDat : Form
    {
        public FormCaiDat()
        {
            InitializeComponent();
            Load += FormCaiDat_Load;
        }

        private void FormCaiDat_Load(object? sender, EventArgs e)
        {
            nudSoNgay.Value = DbHelper.LaySoNgayBaoTruocHan();
            chkKhoiDongCungWindows.Checked = StartupHelper.DangBatCungWindows();
        }

        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            DbHelper.LuuSoNgayBaoTruocHan((int)nudSoNgay.Value);
            StartupHelper.DatBatCungWindows(chkKhoiDongCungWindows.Checked);

            MessageBox.Show($"Đã lưu: hệ thống sẽ báo trước {(int)nudSoNgay.Value} ngày." +
                (chkKhoiDongCungWindows.Checked ? "\nỨng dụng sẽ tự khởi động cùng Windows." : ""),
                "Đã lưu cài đặt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnDoiMatKhau_Click(object? sender, EventArgs e)
        {
            VaultHelper.DoiMatKhau(this);
        }
    }
}