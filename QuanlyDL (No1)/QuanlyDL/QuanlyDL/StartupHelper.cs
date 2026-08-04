using Microsoft.Win32;

namespace QuanlyDL
{
    /// <summary>
    /// Quản lý việc bật/tắt tự khởi động ứng dụng cùng Windows,
    /// thông qua khóa Registry Run của người dùng hiện tại.
    /// </summary>
    public static class StartupHelper
    {
        private const string DuongDanKhoa = @"Software\Microsoft\Windows\CurrentVersion\Run";
        private const string TenGiaTri = "QuanlyDL";

        public static bool DangBatCungWindows()
        {
            using var khoa = Registry.CurrentUser.OpenSubKey(DuongDanKhoa, writable: false);
            var giaTri = khoa?.GetValue(TenGiaTri) as string;
            return !string.IsNullOrEmpty(giaTri);
        }

        public static void DatBatCungWindows(bool bat)
        {
            using var khoa = Registry.CurrentUser.OpenSubKey(DuongDanKhoa, writable: true)
                ?? Registry.CurrentUser.CreateSubKey(DuongDanKhoa);

            if (bat)
            {
                string duongDanExe = Application.ExecutablePath;
                khoa.SetValue(TenGiaTri, $"\"{duongDanExe}\"");
            }
            else
            {
                if (khoa.GetValue(TenGiaTri) != null)
                    khoa.DeleteValue(TenGiaTri);
            }
        }
    }
}