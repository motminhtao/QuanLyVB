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
            NapLaiThongBao();
        }

        private void NapLaiThongBao()
        {
            lvThongBao.Items.Clear();

            int soNgayBaoTruoc = DbHelper.LaySoNgayBaoTruocHan();
            var danhSach = DbHelper.LayDanhSachSapDenHan(soNgayBaoTruoc);

            if (danhSach.Count == 0)
            {
                var itemTrong = new ListViewItem(new[] { "(Không có văn bản nào sắp hoặc quá hạn)", "", "", "" });
                itemTrong.ForeColor = Color.Gray;
                lvThongBao.Items.Add(itemTrong);
                return;
            }

            var homNay = DateTime.Today;
            foreach (var vb in danhSach)
            {
                int soNgay = (vb.NgayHoanThanh!.Value.Date - homNay).Days;
                string trangThai = soNgay < 0 ? $"ĐÃ QUÁ HẠN {-soNgay} ngày"
                                  : soNgay == 0 ? "HẠN HÔM NAY"
                                  : $"Còn {soNgay} ngày";

                var item = new ListViewItem(new[]
                {
                    vb.TenVanBan,
                    vb.SoDen,
                    vb.NgayHoanThanh.Value.ToString("dd/MM/yyyy"),
                    trangThai
                });

                item.ForeColor = soNgay < 0 ? Color.Red : (soNgay == 0 ? Color.DarkOrange : Color.Black);
                lvThongBao.Items.Add(item);
            }
        }

        private void BtnNhapVanBan_Click(object? sender, EventArgs e)
        {
            using var form = new FormNhapVanBan();
            form.ShowDialog(this);
            NapLaiThongBao();
        }

        private void BtnTraCuu_Click(object? sender, EventArgs e)
        {
            using var form = new FormTraCuu();
            form.ShowDialog(this);
            NapLaiThongBao();
        }

        private void BtnCaiDat_Click(object? sender, EventArgs e)
        {
            using var form = new FormCaiDat();
            form.ShowDialog(this);
            NapLaiThongBao();
        }
    }
}