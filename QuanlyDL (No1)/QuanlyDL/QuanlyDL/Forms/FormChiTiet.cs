using System.Diagnostics;
using QuanlyDL.Data;
using QuanlyDL.Models;
using QuanlyDL.Security;

namespace QuanlyDL.Forms
{
    public partial class FormChiTiet : Form
    {
        private readonly long _id;
        private VanBan? _vanBan;
        private bool _daGiaiMa;

        public FormChiTiet(long id)
        {
            InitializeComponent();
            _id = id;
            Load += FormChiTiet_Load;
        }

        private void FormChiTiet_Load(object? sender, EventArgs e)
        {
            _vanBan = DbHelper.LayTheoId(_id);
            if (_vanBan == null)
            {
                MessageBox.Show("Không tìm thấy văn bản.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Các trường không mã hóa hiển thị luôn
            txtTen.Text = _vanBan.TenVanBan;
            txtSoDen.Text = _vanBan.SoDen;
            txtNgayNhan.Text = _vanBan.NgayNhan.ToString("dd/MM/yyyy");
            txtDoMat.Text = _vanBan.MucDoMat;
            txtNgayHoanThanh.Text = _vanBan.NgayHoanThanh?.ToString("dd/MM/yyyy") ?? "(không có)";

            if (_vanBan.MucDoMat != DoMat.Khong)
            {
                lblKhoaTrangThai.Text = $"🔒 Văn bản thuộc Vùng lưu trữ CÓ KHÓA - Độ mật: {_vanBan.MucDoMat}";

                if (!VaultHelper.DamBaoDaMoKhoa(this))
                {
                    HienThiChuaGiaiMa();
                    return;
                }

                GiaiMaVaHienThi();
            }
            else
            {
                lblKhoaTrangThai.Text = "🔓 Văn bản thuộc Vùng lưu trữ không khóa";
                HienThiKhongMaHoa();
            }

            CapNhatNutHoanThanh();
        }

        private void HienThiKhongMaHoa()
        {
            txtChuyen.Text = _vanBan!.Chuyen ?? "";
            txtSoKyHieu.Text = _vanBan.SoKyHieuHS ?? "";
            txtNoiDung.Text = _vanBan.NoiDung ?? "";
            txtCanBo.Text = _vanBan.CanBoTiepNhan ?? "";
            CapNhatHienThiTep(coTheMo: true);
            _daGiaiMa = true;
        }

        private void GiaiMaVaHienThi()
        {
            try
            {
                var khoa = VaultSession.Khoa!;
                txtChuyen.Text = CryptoHelper.GiaiMaChuoi(khoa, _vanBan!.Chuyen);
                txtSoKyHieu.Text = CryptoHelper.GiaiMaChuoi(khoa, _vanBan.SoKyHieuHS);
                txtNoiDung.Text = CryptoHelper.GiaiMaChuoi(khoa, _vanBan.NoiDung);
                txtCanBo.Text = CryptoHelper.GiaiMaChuoi(khoa, _vanBan.CanBoTiepNhan);
                CapNhatHienThiTep(coTheMo: true);
                _daGiaiMa = true;
            }
            catch
            {
                MessageBox.Show("Không thể giải mã dữ liệu (mật khẩu không đúng hoặc dữ liệu lỗi).",
                    "Lỗi giải mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HienThiChuaGiaiMa();
            }
        }

        private void HienThiChuaGiaiMa()
        {
            string an = "*** Đã mã hóa - cần xác thực mật khẩu để xem ***";
            txtChuyen.Text = an;
            txtSoKyHieu.Text = an;
            txtNoiDung.Text = an;
            txtCanBo.Text = an;
            CapNhatHienThiTep(coTheMo: false);
            _daGiaiMa = false;
        }

        private void CapNhatHienThiTep(bool coTheMo)
        {
            if (_vanBan!.CoTepDinhKem)
            {
                lblTep.Text = _vanBan.TenTepGoc;
                btnMoTep.Enabled = coTheMo;
            }
            else
            {
                lblTep.Text = "(không có tệp đính kèm)";
                btnMoTep.Enabled = false;
            }
        }

        private void CapNhatNutHoanThanh()
        {
            if (!_vanBan!.NgayHoanThanh.HasValue)
            {
                btnDanhDauHoanThanh.Visible = false;
                txtTrangThaiHoanThanh.Text = "";
                return;
            }

            btnDanhDauHoanThanh.Visible = !_vanBan.DaHoanThanh;
            txtNgayHoanThanh.Text += _vanBan.DaHoanThanh ? "  (Đã hoàn thành)" : "  (Chưa hoàn thành)";
        }

        private void BtnMoTep_Click(object? sender, EventArgs e)
        {
            if (_vanBan == null || !_vanBan.CoTepDinhKem) return;

            try
            {
                string duongDanMo;

                if (_vanBan.CoDoMat)
                {
                    if (!_daGiaiMa || VaultSession.Khoa == null)
                    {
                        MessageBox.Show("Cần xác thực mật khẩu trước khi mở tệp.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    byte[] duLieuGoc = CryptoHelper.GiaiMaTep(VaultSession.Khoa, _vanBan.DuongDanTepDayDu!);

                    AppPaths.DamBaoThuMucTonTai();
                    string tenTamThoi = Guid.NewGuid().ToString("N") + Path.GetExtension(_vanBan.TenTepGoc);
                    duongDanMo = Path.Combine(AppPaths.ThuMucTamGiaiMa, tenTamThoi);
                    File.WriteAllBytes(duongDanMo, duLieuGoc);
                }
                else
                {
                    duongDanMo = _vanBan.DuongDanTepDayDu!;
                }

                var psi = new ProcessStartInfo(duongDanMo) { UseShellExecute = true };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể mở tệp đính kèm: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDanhDauHoanThanh_Click(object? sender, EventArgs e)
        {
            if (_vanBan == null) return;

            DbHelper.DanhDauHoanThanh(_vanBan.Id, true);
            _vanBan.DaHoanThanh = true;
            MessageBox.Show("Đã đánh dấu văn bản là hoàn thành.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnDanhDauHoanThanh.Visible = false;
        }
    }
}
