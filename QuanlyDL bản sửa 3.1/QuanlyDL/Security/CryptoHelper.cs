using System.Security.Cryptography;
using System.Text;

namespace QuanlyDL.Security
{
    /// <summary>
    /// Hàm hỗ trợ mã hóa/giải mã dùng AES-GCM (mã hóa có xác thực).
    /// Khóa mã hóa được suy ra từ mật khẩu kho lưu trữ (vault) bằng PBKDF2,
    /// không lưu mật khẩu hay khóa ra đĩa dưới dạng rõ.
    /// </summary>
    public static class CryptoHelper
    {
        private const int KichThuocSalt = 16;
        private const int KichThuocKhoa = 32;   // 256-bit
        private const int KichThuocNonce = 12;
        private const int KichThuocTag = 16;
        private const int SoVongLap = 100_000;

        public static byte[] TaoSaltMoi() => RandomNumberGenerator.GetBytes(KichThuocSalt);

        public static byte[] SuyRaKhoa(string matKhau, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(matKhau, salt, SoVongLap, HashAlgorithmName.SHA256);
            return pbkdf2.GetBytes(KichThuocKhoa);
        }

        public static byte[] MaHoa(byte[] khoa, byte[] duLieuGoc)
        {
            byte[] nonce = RandomNumberGenerator.GetBytes(KichThuocNonce);
            byte[] duLieuMa = new byte[duLieuGoc.Length];
            byte[] tag = new byte[KichThuocTag];

            using (var aes = new AesGcm(khoa, KichThuocTag))
            {
                aes.Encrypt(nonce, duLieuGoc, duLieuMa, tag);
            }

            byte[] ketQua = new byte[KichThuocNonce + KichThuocTag + duLieuMa.Length];
            Buffer.BlockCopy(nonce, 0, ketQua, 0, KichThuocNonce);
            Buffer.BlockCopy(tag, 0, ketQua, KichThuocNonce, KichThuocTag);
            Buffer.BlockCopy(duLieuMa, 0, ketQua, KichThuocNonce + KichThuocTag, duLieuMa.Length);
            return ketQua;
        }

        /// <summary>
        /// Giải mã. Nếm mật khẩu/khóa sai sẽ ném CryptographicException.
        /// </summary>
        public static byte[] GiaiMa(byte[] khoa, byte[] duLieuMa)
        {
            int doDaiMa = duLieuMa.Length - KichThuocNonce - KichThuocTag;
            if (doDaiMa < 0)
                throw new CryptographicException("Dữ liệu mã hóa không hợp lệ.");

            byte[] nonce = new byte[KichThuocNonce];
            byte[] tag = new byte[KichThuocTag];
            byte[] cipherText = new byte[doDaiMa];

            Buffer.BlockCopy(duLieuMa, 0, nonce, 0, KichThuocNonce);
            Buffer.BlockCopy(duLieuMa, KichThuocNonce, tag, 0, KichThuocTag);
            Buffer.BlockCopy(duLieuMa, KichThuocNonce + KichThuocTag, cipherText, 0, doDaiMa);

            byte[] duLieuGoc = new byte[doDaiMa];
            using (var aes = new AesGcm(khoa, KichThuocTag))
            {
                aes.Decrypt(nonce, cipherText, tag, duLieuGoc);
            }
            return duLieuGoc;
        }

        public static string MaHoaChuoi(byte[] khoa, string? chuoiGoc)
        {
            if (string.IsNullOrEmpty(chuoiGoc)) return "";
            return Convert.ToBase64String(MaHoa(khoa, Encoding.UTF8.GetBytes(chuoiGoc)));
        }

        public static string GiaiMaChuoi(byte[] khoa, string? chuoiMa)
        {
            if (string.IsNullOrEmpty(chuoiMa)) return "";
            return Encoding.UTF8.GetString(GiaiMa(khoa, Convert.FromBase64String(chuoiMa)));
        }

        public static void MaHoaTep(byte[] khoa, string duongDanNguon, string duongDanDich)
        {
            byte[] duLieu = File.ReadAllBytes(duongDanNguon);
            byte[] duLieuMa = MaHoa(khoa, duLieu);
            File.WriteAllBytes(duongDanDich, duLieuMa);
        }

        public static byte[] GiaiMaTep(byte[] khoa, string duongDanTepMa)
        {
            byte[] duLieuMa = File.ReadAllBytes(duongDanTepMa);
            return GiaiMa(khoa, duLieuMa);
        }
    }
}
