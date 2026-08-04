using System.IO;
using QuanlyDL.Data;
using QuanlyDL.Forms;

namespace QuanlyDL.Security
{
    /// <summary>
    /// Điều phối việc mở khóa "Vùng lưu trữ có khóa":
    /// - Nếu chưa từng đặt mật khẩu -> yêu cầu tạo mật khẩu mới.
    /// - Nếu đã có mật khẩu -> yêu cầu nhập mật khẩu để xác thực.
    /// - Nếu trong phiên hiện tại đã mở khóa rồi -> dùng lại luôn.
    /// </summary>
    public static class VaultHelper
    {
        private const string KhoaCaiDatSalt = "VaultSalt";
        private const string KhoaCaiDatCanary = "VaultCanary";
        private const string ChuoiKiemTra = "QUANLYDL_VAULT_OK";

        /// <summary>
        /// Đảm bảo kho đã được mở khóa trong phiên làm việc hiện tại.
        /// Trả về true nếu mở khóa thành công (hoặc đã mở khóa từ trước).
        /// </summary>
        public static bool DamBaoDaMoKhoa(IWin32Window? owner)
        {
            if (VaultSession.DaMoKhoa) return true;

            string? saltB64 = DbHelper.LayCaiDat(KhoaCaiDatSalt);
            string? canaryB64 = DbHelper.LayCaiDat(KhoaCaiDatCanary);

            if (string.IsNullOrEmpty(saltB64) || string.IsNullOrEmpty(canaryB64))
            {
                return TaoMatKhauMoi(owner);
            }
            else
            {
                return XacThucMatKhau(owner, saltB64, canaryB64);
            }
        }

        private static bool TaoMatKhauMoi(IWin32Window? owner)
        {
            using var form = new FormTaoMatKhauVault();
            if (form.ShowDialog(owner) != DialogResult.OK)
                return false;

            byte[] salt = CryptoHelper.TaoSaltMoi();
            byte[] khoa = CryptoHelper.SuyRaKhoa(form.MatKhau, salt);
            string canary = CryptoHelper.MaHoaChuoi(khoa, ChuoiKiemTra);

            DbHelper.LuuCaiDat(KhoaCaiDatSalt, Convert.ToBase64String(salt));
            DbHelper.LuuCaiDat(KhoaCaiDatCanary, canary);

            VaultSession.MoKhoa(khoa);
            return true;
        }

        private static bool XacThucMatKhau(IWin32Window? owner, string saltB64, string canaryB64)
        {
            byte[] salt = Convert.FromBase64String(saltB64);

            for (int lanThu = 0; lanThu < 3; lanThu++)
            {
                using var form = new FormXacThucVault();
                if (form.ShowDialog(owner) != DialogResult.OK)
                    return false;

                byte[] khoa = CryptoHelper.SuyRaKhoa(form.MatKhau, salt);
                try
                {
                    string giaiMa = CryptoHelper.GiaiMaChuoi(khoa, canaryB64);
                    if (giaiMa == ChuoiKiemTra)
                    {
                        VaultSession.MoKhoa(khoa);
                        return true;
                    }
                }
                catch
                {
                    // Sai mật khẩu -> giải mã thất bại, thử lại
                }

                MessageBox.Show("Mật khẩu không đúng. Vui lòng thử lại.", "Xác thực thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }
        /// <summary>
        /// Đổi mật khẩu vùng có khóa: xác thực mật khẩu cũ, sau đó mã hóa lại
        /// toàn bộ văn bản/tệp đính kèm có độ mật bằng mật khẩu mới.
        /// </summary>
        public static bool DoiMatKhau(IWin32Window? owner)
        {
            string? saltB64 = DbHelper.LayCaiDat(KhoaCaiDatSalt);
            string? canaryB64 = DbHelper.LayCaiDat(KhoaCaiDatCanary);

            if (string.IsNullOrEmpty(saltB64) || string.IsNullOrEmpty(canaryB64))
            {
                MessageBox.Show("Chưa thiết lập mật khẩu vùng có khóa. Hãy lưu 1 văn bản có độ mật trước để thiết lập mật khẩu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            using var form = new FormDoiMatKhauVault();
            if (form.ShowDialog(owner) != DialogResult.OK) return false;

            byte[] saltCu = Convert.FromBase64String(saltB64);
            byte[] khoaCu = CryptoHelper.SuyRaKhoa(form.MatKhauHienTai, saltCu);

            try
            {
                string giaiMaThu = CryptoHelper.GiaiMaChuoi(khoaCu, canaryB64);
                if (giaiMaThu != ChuoiKiemTra) throw new Exception();
            }
            catch
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            byte[] saltMoi = CryptoHelper.TaoSaltMoi();
            byte[] khoaMoi = CryptoHelper.SuyRaKhoa(form.MatKhauMoi, saltMoi);

            var dsCoDoMat = DbHelper.LayTatCa().Where(v => v.CoDoMat).ToList();
            foreach (var vb in dsCoDoMat)
            {
                vb.Chuyen = MaHoaLai(khoaCu, khoaMoi, vb.Chuyen);
                vb.SoKyHieuHS = MaHoaLai(khoaCu, khoaMoi, vb.SoKyHieuHS);
                vb.NoiDung = MaHoaLai(khoaCu, khoaMoi, vb.NoiDung);
                vb.CanBoTiepNhan = MaHoaLai(khoaCu, khoaMoi, vb.CanBoTiepNhan);
                DbHelper.CapNhatVanBan(vb);

                if (vb.CoTepDinhKem && vb.DuongDanTepDayDu != null && File.Exists(vb.DuongDanTepDayDu))
                {
                    byte[] noiDungGoc = CryptoHelper.GiaiMaTep(khoaCu, vb.DuongDanTepDayDu);
                    byte[] maMoi = CryptoHelper.MaHoa(khoaMoi, noiDungGoc);
                    File.WriteAllBytes(vb.DuongDanTepDayDu, maMoi);
                }
            }

            string canaryMoi = CryptoHelper.MaHoaChuoi(khoaMoi, ChuoiKiemTra);
            DbHelper.LuuCaiDat(KhoaCaiDatSalt, Convert.ToBase64String(saltMoi));
            DbHelper.LuuCaiDat(KhoaCaiDatCanary, canaryMoi);

            VaultSession.MoKhoa(khoaMoi);

            MessageBox.Show("Đã đổi mật khẩu thành công. Toàn bộ dữ liệu có độ mật đã được mã hóa lại.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }

        private static string? MaHoaLai(byte[] khoaCu, byte[] khoaMoi, string? chuoiMaCu)
        {
            if (string.IsNullOrEmpty(chuoiMaCu)) return chuoiMaCu;
            string banRo = CryptoHelper.GiaiMaChuoi(khoaCu, chuoiMaCu);
            return CryptoHelper.MaHoaChuoi(khoaMoi, banRo);
        }
    }
}
