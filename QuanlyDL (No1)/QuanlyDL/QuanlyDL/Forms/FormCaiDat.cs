using QuanlyDL.Data;

namespace QuanlyDL.Forms
{
    public partial class FormCaiDat : Form
    {
        public FormCaiDat()
        {
            InitializeComponent();
            Load += (s, e) => nudSoNgay.Value = DbHelper.LaySoNgayBaoTruocHan();
        }

        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            DbHelper.LuuSoNgayBaoTruocHan((int)nudSoNgay.Value);
            MessageBox.Show($"Đã lưu: hệ thống sẽ báo trước {(int)nudSoNgay.Value} ngày.",
                "Đã lưu cài đặt", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
