namespace QuanlyDL.Security
{
    /// <summary>
    /// Giữ khóa mã hóa trong bộ nhớ khi người dùng đã nhập đúng mật khẩu
    /// trong phiên làm việc hiện tại, để không phải nhập lại liên tục.
    /// Khóa sẽ mất khi đóng ứng dụng (không lưu ra đĩa).
    /// </summary>
    public static class VaultSession
    {
        public static byte[]? Khoa { get; private set; }

        public static bool DaMoKhoa => Khoa != null;

        public static void MoKhoa(byte[] khoa)
        {
            Khoa = khoa;
        }

        public static void Khoi()
        {
            Khoa = null;
        }
    }
}
