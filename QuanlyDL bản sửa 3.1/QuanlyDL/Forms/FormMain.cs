using QuanlyDL.Data;
using QuanlyDL.Security;

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
            int soNgayBaoTruoc = DbHelper.LaySoNgayBaoTruocHan();
            var danhSach = DbHelper.LayDanhSachSapDenHan(soNgayBaoTruoc);

            if (danhSach.Count == 0)
            {
                gridThongBao.DataSource = null;
                gridThongBao.Visible = false;
                lblKhongCoThongBao.Visible = true;
                return;
            }

            gridThongBao.Visible = true;
            lblKhongCoThongBao.Visible = false;

            var homNay = DateTime.Today;
            var duLieuHienThi = danhSach.Select(vb =>
            {
                int soNgay = (vb.NgayHoanThanh!.Value.Date - homNay).Days;
                string conLai = soNgay < 0 ? $"Quá hạn {-soNgay} ngày" : $"Còn {soNgay} ngày";
                return new
                {
                    SoCongVan = vb.TenVanBan,
                    CanBoSuLy = LayCanBoSuLyDeHienThi(vb),
                    Han = vb.NgayHoanThanh.Value.ToString("dd/MM/yyyy"),
                    ConLai = conLai,
                    SoNgay = soNgay
                };
            }).ToList();

            gridThongBao.DataSource = duLieuHienThi;

            if (gridThongBao.Columns["SoNgay"] != null)
                gridThongBao.Columns["SoNgay"]!.Visible = false;

            CanhChinhCotThongBao("SoCongVan", "Số công văn", inDam: true);
            CanhChinhCotThongBao("CanBoSuLy", "Cán bộ sử lý", inDam: true);
            CanhChinhCotThongBao("Han", "Hạn hoàn thành", inDam: false);
            CanhChinhCotThongBao("ConLai", "Còn lại", inDam: false);

            foreach (DataGridViewRow row in gridThongBao.Rows)
            {
                if (row.Cells["SoNgay"]?.Value is int soNgay)
                {
                    row.DefaultCellStyle.ForeColor = soNgay < 0 ? Color.Red
                        : (soNgay == 0 ? Color.DarkOrange : Color.Black);
                }
            }
        }

        private void CanhChinhCotThongBao(string ten, string tieuDe, bool inDam)
        {
            if (gridThongBao.Columns[ten] == null) return;
            gridThongBao.Columns[ten]!.HeaderText = tieuDe;
            if (inDam)
                gridThongBao.Columns[ten]!.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }

        private static string LayCanBoSuLyDeHienThi(Models.VanBan vb)
        {
            if (!vb.CoDoMat)
                return string.IsNullOrEmpty(vb.CanBoTiepNhan) ? "" : vb.CanBoTiepNhan;

            if (VaultSession.Khoa == null)
                return "🔒 (Cần mật khẩu)";

            try
            {
                string giaiMa = CryptoHelper.GiaiMaChuoi(VaultSession.Khoa, vb.CanBoTiepNhan);
                return string.IsNullOrEmpty(giaiMa) ? "" : giaiMa;
            }
            catch
            {
                return "🔒 (Lỗi giải mã)";
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
        private void GridThongBao_SelectionChanged(object? sender, EventArgs e)
        {
            // Bảng này chỉ để xem, không cho chọn/bôi xanh
            if (gridThongBao.SelectedCells.Count > 0 || gridThongBao.SelectedRows.Count > 0)
            {
                gridThongBao.ClearSelection();
            }
        }
    }
}