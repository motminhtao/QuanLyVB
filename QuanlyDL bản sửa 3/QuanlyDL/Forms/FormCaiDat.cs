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
            chkHienThongBaoLuuMat.Checked = DbHelper.LayHienThongBaoLuuMat();
            chkTuDongTimTraCuu.Checked = DbHelper.LayTuDongTimTraCuu();
            chkKhoiDongCungWindows.Checked = StartupHelper.DangBatCungWindows();
        }

        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            DbHelper.LuuSoNgayBaoTruocHan((int)nudSoNgay.Value);
            DbHelper.LuuHienThongBaoLuuMat(chkHienThongBaoLuuMat.Checked);
            DbHelper.LuuTuDongTimTraCuu(chkTuDongTimTraCuu.Checked);
            StartupHelper.DatBatCungWindows(chkKhoiDongCungWindows.Checked);

            MessageBox.Show("Đã lưu cài đặt.", "Đã lưu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnDoiMatKhau_Click(object? sender, EventArgs e)
        {
            VaultHelper.DoiMatKhau(this);
        }
    }
}