using QuanlyDL.Data;
using QuanlyDL.Forms;

namespace QuanlyDL
{
    internal static class Program
    {
        /// <summary>
        /// Điểm bắt đầu của chương trình.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Bắt mọi lỗi không được xử lý và hiện thông báo rõ ràng,
            // thay vì để chương trình thoát im lặng không hiện gì.
            Application.ThreadException += (s, e) => HienLoi(e.Exception);
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
                HienLoi(e.ExceptionObject as Exception ?? new Exception("Lỗi không xác định."));

            try
            {
                // Đảm bảo thư mục dữ liệu và cơ sở dữ liệu đã sẵn sàng trước khi mở giao diện.
                DbHelper.EnsureDatabase();

                Application.Run(new FormMain());
            }
            catch (Exception ex)
            {
                HienLoi(ex);
            }
        }

        private static void HienLoi(Exception ex)
        {
            MessageBox.Show(
                "Chương trình gặp lỗi khi khởi động và không thể tiếp tục:\n\n" +
                ex + "\n\n" +
                "Vui lòng chụp lại nội dung này để được hỗ trợ khắc phục.",
                "Lỗi khởi động QuanlyDL",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
