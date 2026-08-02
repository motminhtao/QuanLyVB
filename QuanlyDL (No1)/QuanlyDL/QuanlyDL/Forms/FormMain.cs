using QuanlyDL.Data;

namespace QuanlyDL.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            Load += FormMain_Load;
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            KiemTraThongBaoHan();
        }

        /// <summary>
        /// Kiểm tra các văn bản có [Ngày Hoàn Thành] trong vòng X ngày tới
        /// (X do người dùng cấu hình ở mục Cài đặt, mặc định 2 ngày; kể cả
        /// đã quá hạn) mà chưa hoàn thành, hiển thị thông báo nhắc nhở.
        /// </summary>
        private void KiemTraThongBaoHan()
        {
            int soNgayBaoTruoc = DbHelper.LaySoNgayBaoTruocHan();
            var danhSach = DbHelper.LayDanhSachSapDenHan(soNgayBaoTruoc);
            if (danhSach.Count == 0) return;

            var noiDung = new System.Text.StringBuilder();
            noiDung.AppendLine($"Các văn bản sắp đến hạn / đã quá hạn hoàn thành (báo trước {soNgayBaoTruoc} ngày):");
            noiDung.AppendLine();

            foreach (var vb in danhSach)
            {
                var homNay = DateTime.Today;
                int soNgay = (vb.NgayHoanThanh!.Value.Date - homNay).Days;
                string trangThai = soNgay < 0 ? $"ĐÃ QUÁ HẠN {-soNgay} ngày"
                                  : soNgay == 0 ? "HẠN HÔM NAY"
                                  : $"còn {soNgay} ngày";

                noiDung.AppendLine($"• {vb.TenVanBan} (Số đến: {vb.SoDen}) - Hạn: {vb.NgayHoanThanh.Value:dd/MM/yyyy} ({trangThai})");
            }

            MessageBox.Show(noiDung.ToString(), "Nhắc hạn xử lý văn bản",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnNhapVanBan_Click(object? sender, EventArgs e)
        {
            using var form = new FormNhapVanBan();
            form.ShowDialog(this);
        }

        private void BtnTraCuu_Click(object? sender, EventArgs e)
        {
            using var form = new FormTraCuu();
            form.ShowDialog(this);
        }

        private void BtnCaiDat_Click(object? sender, EventArgs e)
        {
            using var form = new FormCaiDat();
            form.ShowDialog(this);
        }
    }
}
