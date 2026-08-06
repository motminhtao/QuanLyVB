namespace QuanlyDL
{
    /// <summary>
    /// Tất cả đường dẫn dữ liệu của ứng dụng đều nằm trong 1 thư mục "Data"
    /// đặt cạnh file .exe, để tiện sao chép nguyên cả thư mục ứng dụng
    /// sang máy khác mà không mất dữ liệu.
    /// </summary>
    public static class AppPaths
    {
        public static string ThuMucGoc => AppContext.BaseDirectory;

        public static string ThuMucDuLieu => Path.Combine(ThuMucGoc, "Data");

        public static string DuongDanCoSoDuLieu => Path.Combine(ThuMucDuLieu, "QuanlyDL.db");

        // Tài liệu không có độ mật (không khóa)
        public static string ThuMucTepKhongKhoa => Path.Combine(ThuMucDuLieu, "Attachments");

        // Tài liệu có độ mật (đã mã hóa)
        public static string ThuMucTepCoKhoa => Path.Combine(ThuMucDuLieu, "AttachmentsLocked");

        // Thư mục tạm dùng khi mở tệp đã giải mã tạm thời để xem
        public static string ThuMucTamGiaiMa => Path.Combine(ThuMucDuLieu, "TempGiaiMa");

        public static void DamBaoThuMucTonTai()
        {
            Directory.CreateDirectory(ThuMucDuLieu);
            Directory.CreateDirectory(ThuMucTepKhongKhoa);
            Directory.CreateDirectory(ThuMucTepCoKhoa);
            Directory.CreateDirectory(ThuMucTamGiaiMa);
        }
    }
}
