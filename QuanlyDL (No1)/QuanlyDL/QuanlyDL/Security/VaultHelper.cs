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
    }
}
