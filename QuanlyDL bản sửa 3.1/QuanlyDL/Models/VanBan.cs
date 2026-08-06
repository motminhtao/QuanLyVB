namespace QuanlyDL.Models
{
    /// <summary>
    /// Các mức độ mật của văn bản.
    /// </summary>
    public static class DoMat
    {
        public const string Khong = "Không";
        public const string Mat = "Mật";
        public const string TuyetMat = "Tuyệt Mật";
        public const string ToiMat = "Tối Mật";

        public static readonly string[] TatCa = { Khong, Mat, TuyetMat, ToiMat };
    }

    /// <summary>
    /// Đại diện cho 1 bản ghi văn bản lưu trữ.
    /// Nếu DoMat khác "Không" thì các trường NoiDung, Chuyen, SoKyHieuHS,
    /// CanBoTiepNhan được LƯU DƯỚI DẠNG ĐÃ MÃ HÓA (chuỗi base64) trong CSDL,
    /// và tệp đính kèm (nếu có) cũng được mã hóa trên đĩa.
    /// </summary>
    public class VanBan
    {
        public long Id { get; set; }

        public string TenVanBan { get; set; } = "";   // bắt buộc
        public string SoDen { get; set; } = "";        // bắt buộc
        public DateTime NgayNhan { get; set; }          // bắt buộc

        public string? Chuyen { get; set; }
        public string? SoKyHieuHS { get; set; }
        public string? NoiDung { get; set; }
        public string? CanBoTiepNhan { get; set; }

        public string MucDoMat { get; set; } = DoMat.Khong;

        public DateTime? NgayHoanThanh { get; set; }
        public bool DaHoanThanh { get; set; }

        // Tên tệp lưu trên đĩa (đã đổi tên duy nhất) và tên tệp gốc do người dùng chọn
        public string? TenTepLuu { get; set; }
        public string? TenTepGoc { get; set; }

        public DateTime NgayTao { get; set; } = DateTime.Now;

        public bool CoDoMat => !string.IsNullOrEmpty(MucDoMat) && MucDoMat != DoMat.Khong;

        public bool CoTepDinhKem => !string.IsNullOrEmpty(TenTepLuu);

        /// <summary>
        /// Đường dẫn đầy đủ tới tệp đính kèm trên đĩa (tệp gốc nếu không khóa,
        /// hoặc tệp .enc nếu có khóa).
        /// </summary>
        public string? DuongDanTepDayDu
        {
            get
            {
                if (string.IsNullOrEmpty(TenTepLuu)) return null;
                var thuMuc = CoDoMat ? AppPaths.ThuMucTepCoKhoa : AppPaths.ThuMucTepKhongKhoa;
                return Path.Combine(thuMuc, TenTepLuu);
            }
        }
    }
}
