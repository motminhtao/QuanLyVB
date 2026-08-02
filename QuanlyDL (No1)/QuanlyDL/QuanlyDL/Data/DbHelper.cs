using System.IO;
using Microsoft.Data.Sqlite;
using QuanlyDL.Models;

namespace QuanlyDL.Data
{
    /// <summary>
    /// Lớp thao tác trực tiếp với cơ sở dữ liệu SQLite (1 tệp .db duy nhất
    /// nằm trong thư mục Data cạnh file .exe).
    /// </summary>
    public static class DbHelper
    {
        private static string ChuoiKetNoi => $"Data Source={AppPaths.DuongDanCoSoDuLieu}";

        public static void EnsureDatabase()
        {
            AppPaths.DamBaoThuMucTonTai();

            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS VanBan (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TenVanBan TEXT NOT NULL,
                    SoDen TEXT NOT NULL,
                    NgayNhan TEXT NOT NULL,
                    Chuyen TEXT,
                    SoKyHieuHS TEXT,
                    NoiDung TEXT,
                    CanBoTiepNhan TEXT,
                    MucDoMat TEXT NOT NULL DEFAULT 'Không',
                    NgayHoanThanh TEXT,
                    DaHoanThanh INTEGER NOT NULL DEFAULT 0,
                    TenTepLuu TEXT,
                    TenTepGoc TEXT,
                    NgayTao TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS CaiDat (
                    Khoa TEXT PRIMARY KEY,
                    GiaTri TEXT
                );

                CREATE INDEX IF NOT EXISTS IX_VanBan_TimKiem
                    ON VanBan (TenVanBan, SoDen, NgayNhan);
            ";
            cmd.ExecuteNonQuery();
        }

        // ---------------- CaiDat (Settings) ----------------

        public static string? LayCaiDat(string khoa)
        {
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT GiaTri FROM CaiDat WHERE Khoa = $khoa";
            cmd.Parameters.AddWithValue("$khoa", khoa);
            var ketQua = cmd.ExecuteScalar();
            return ketQua as string;
        }

        public static void LuuCaiDat(string khoa, string giaTri)
        {
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO CaiDat (Khoa, GiaTri) VALUES ($khoa, $giaTri)
                ON CONFLICT(Khoa) DO UPDATE SET GiaTri = $giaTri";
            cmd.Parameters.AddWithValue("$khoa", khoa);
            cmd.Parameters.AddWithValue("$giaTri", giaTri);
            cmd.ExecuteNonQuery();
        }

        // ---------------- VanBan ----------------

        public static long ThemVanBan(VanBan vb)
        {
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO VanBan
                    (TenVanBan, SoDen, NgayNhan, Chuyen, SoKyHieuHS, NoiDung, CanBoTiepNhan,
                     MucDoMat, NgayHoanThanh, DaHoanThanh, TenTepLuu, TenTepGoc, NgayTao)
                VALUES
                    ($ten, $soDen, $ngayNhan, $chuyen, $soKyHieu, $noiDung, $canBo,
                     $mucDoMat, $ngayHT, $daHT, $tenTepLuu, $tenTepGoc, $ngayTao);
                SELECT last_insert_rowid();";

            GanThamSo(cmd, vb);
            var id = (long)cmd.ExecuteScalar()!;
            return id;
        }

        public static void CapNhatVanBan(VanBan vb)
        {
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE VanBan SET
                    TenVanBan = $ten, SoDen = $soDen, NgayNhan = $ngayNhan,
                    Chuyen = $chuyen, SoKyHieuHS = $soKyHieu, NoiDung = $noiDung,
                    CanBoTiepNhan = $canBo, MucDoMat = $mucDoMat,
                    NgayHoanThanh = $ngayHT, DaHoanThanh = $daHT,
                    TenTepLuu = $tenTepLuu, TenTepGoc = $tenTepGoc
                WHERE Id = $id";
            GanThamSo(cmd, vb);
            cmd.Parameters.AddWithValue("$id", vb.Id);
            cmd.ExecuteNonQuery();
        }

        public static void DanhDauHoanThanh(long id, bool hoanThanh)
        {
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE VanBan SET DaHoanThanh = $ht WHERE Id = $id";
            cmd.Parameters.AddWithValue("$ht", hoanThanh ? 1 : 0);
            cmd.Parameters.AddWithValue("$id", id);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Xóa một văn bản theo Id, đồng thời xóa tệp đính kèm trên đĩa nếu có.
        /// </summary>
        public static void XoaVanBan(long id)
        {
            // Lấy thông tin trước để biết có tệp đính kèm không
            var vb = LayTheoId(id);

            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM VanBan WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", id);
            cmd.ExecuteNonQuery();

            // Xóa tệp đính kèm trên đĩa (nếu có)
            try
            {
                if (vb != null && !string.IsNullOrEmpty(vb.TenTepLuu))
                {
                    var duongDan = vb.DuongDanTepDayDu;
                    if (!string.IsNullOrEmpty(duongDan) && File.Exists(duongDan))
                    {
                        File.Delete(duongDan);
                    }
                }
            }
            catch
            {
                // Không ném lỗi cho caller — xóa DB là quan trọng nhất.
            }
        }

        private static void GanThamSo(SqliteCommand cmd, VanBan vb)
        {
            cmd.Parameters.AddWithValue("$ten", vb.TenVanBan);
            cmd.Parameters.AddWithValue("$soDen", vb.SoDen);
            cmd.Parameters.AddWithValue("$ngayNhan", vb.NgayNhan.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("$chuyen", (object?)vb.Chuyen ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$soKyHieu", (object?)vb.SoKyHieuHS ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$noiDung", (object?)vb.NoiDung ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$canBo", (object?)vb.CanBoTiepNhan ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$mucDoMat", vb.MucDoMat);
            cmd.Parameters.AddWithValue("$ngayHT", (object?)vb.NgayHoanThanh?.ToString("yyyy-MM-dd") ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$daHT", vb.DaHoanThanh ? 1 : 0);
            cmd.Parameters.AddWithValue("$tenTepLuu", (object?)vb.TenTepLuu ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$tenTepGoc", (object?)vb.TenTepGoc ?? DBNull.Value);
            cmd.Parameters.AddWithValue("$ngayTao", vb.NgayTao.ToString("yyyy-MM-dd HH:mm:ss"));
        }

        public static VanBan? LayTheoId(long id)
        {
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VanBan WHERE Id = $id";
            cmd.Parameters.AddWithValue("$id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read()) return DocTuReader(reader);
            return null;
        }

        public static List<VanBan> LayTatCa()
        {
            var ds = new List<VanBan>();
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM VanBan ORDER BY NgayNhan DESC, Id DESC";
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) ds.Add(DocTuReader(reader));
            return ds;
        }

        /// <summary>
        /// Tìm kiếm theo Tên văn bản, Số đến, Ngày nhận (mỗi tiêu chí có thể để trống).
        /// </summary>
        public static List<VanBan> TimKiem(string? ten, string? soDen, DateTime? ngayNhan)
        {
            var ds = new List<VanBan>();
            using var conn = new SqliteConnection(ChuoiKetNoi);
            conn.Open();
            using var cmd = conn.CreateCommand();

            var dieuKien = new List<string>();
            if (!string.IsNullOrWhiteSpace(ten))
            {
                dieuKien.Add("TenVanBan LIKE $ten");
                cmd.Parameters.AddWithValue("$ten", $"%{ten.Trim()}%");
            }
            if (!string.IsNullOrWhiteSpace(soDen))
            {
                dieuKien.Add("SoDen LIKE $soDen");
                cmd.Parameters.AddWithValue("$soDen", $"%{soDen.Trim()}%");
            }
            if (ngayNhan.HasValue)
            {
                dieuKien.Add("NgayNhan = $ngayNhan");
                cmd.Parameters.AddWithValue("$ngayNhan", ngayNhan.Value.ToString("yyyy-MM-dd"));
            }

            cmd.CommandText = "SELECT * FROM VanBan"
                + (dieuKien.Count > 0 ? " WHERE " + string.Join(" AND ", dieuKien) : "")
                + " ORDER BY NgayNhan DESC, Id DESC";

            using var reader = cmd.ExecuteReader();
            while (reader.Read()) ds.Add(DocTuReader(reader));
            return ds;
        }

        /// <summary>
        /// Lấy danh sách văn bản sắp đến hạn hoàn thành (còn từ 0 đến
        /// soNgayBaoTruoc ngày, kể cả đã quá hạn) và chưa được đánh dấu hoàn thành.
        /// </summary>
        public static List<VanBan> LayDanhSachSapDenHan(int soNgayBaoTruoc)
        {
            var tatCa = LayTatCa();
            var homNay = DateTime.Today;
            return tatCa.Where(v =>
                    v.NgayHoanThanh.HasValue &&
                    !v.DaHoanThanh &&
                    (v.NgayHoanThanh.Value.Date - homNay).TotalDays <= soNgayBaoTruoc)
                .OrderBy(v => v.NgayHoanThanh)
                .ToList();
        }

        // ---------------- Cài đặt riêng: số ngày báo trước hạn (X) ----------------

        private const string KhoaCaiDatSoNgayBaoTruoc = "SoNgayBaoTruocHan";
        private const int MacDinhSoNgayBaoTruoc = 2;

        public static int LaySoNgayBaoTruocHan()
        {
            var giaTri = LayCaiDat(KhoaCaiDatSoNgayBaoTruoc);
            if (int.TryParse(giaTri, out int soNgay) && soNgay >= 0) return soNgay;
            return MacDinhSoNgayBaoTruoc;
        }

        public static void LuuSoNgayBaoTruocHan(int soNgay)
        {
            LuuCaiDat(KhoaCaiDatSoNgayBaoTruoc, soNgay.ToString());
        }

        private static VanBan DocTuReader(SqliteDataReader reader)
        {
            return new VanBan
            {
                Id = reader.GetInt64(reader.GetOrdinal("Id")),
                TenVanBan = reader.GetString(reader.GetOrdinal("TenVanBan")),
                SoDen = reader.GetString(reader.GetOrdinal("SoDen")),
                NgayNhan = DateTime.Parse(reader.GetString(reader.GetOrdinal("NgayNhan"))),
                Chuyen = DocChuoiKoNull(reader, "Chuyen"),
                SoKyHieuHS = DocChuoiKoNull(reader, "SoKyHieuHS"),
                NoiDung = DocChuoiKoNull(reader, "NoiDung"),
                CanBoTiepNhan = DocChuoiKoNull(reader, "CanBoTiepNhan"),
                MucDoMat = reader.GetString(reader.GetOrdinal("MucDoMat")),
                NgayHoanThanh = DocChuoiKoNull(reader, "NgayHoanThanh") is string s ? DateTime.Parse(s) : null,
                DaHoanThanh = reader.GetInt32(reader.GetOrdinal("DaHoanThanh")) == 1,
                TenTepLuu = DocChuoiKoNull(reader, "TenTepLuu"),
                TenTepGoc = DocChuoiKoNull(reader, "TenTepGoc"),
                NgayTao = DateTime.Parse(reader.GetString(reader.GetOrdinal("NgayTao"))),
            };
        }

        private static string? DocChuoiKoNull(SqliteDataReader reader, string tenCot)
        {
            int i = reader.GetOrdinal(tenCot);
            return reader.IsDBNull(i) ? null : reader.GetString(i);
        }
    }
}