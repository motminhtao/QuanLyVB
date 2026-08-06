using QuanlyDL.Data;
using QuanlyDL.Models;
using QuanlyDL.Security;

namespace QuanlyDL.Forms
{
    public partial class FormTraCuu : Form
    {
        private static bool _nhoSapXepNgay = false;
        private static bool _nhoLocNgay = false;

        private readonly bool _tuDongTim;

        public FormTraCuu()
        {
            InitializeComponent();

            _tuDongTim = DbHelper.LayTuDongTimTraCuu();

            chkSapXepNgay.Checked = _nhoSapXepNgay;
            chkLocNgay.Checked = _nhoLocNgay;

            nudThang.Value = DateTime.Today.Month;
            nudNam.Value = DateTime.Today.Year;
            nudNgay.Value = 0;

            nudNgay.Enabled = chkLocNgay.Checked;
            nudThang.Enabled = chkLocNgay.Checked;
            nudNam.Enabled = chkLocNgay.Checked;

            // Gắn sự kiện tự động tìm SAU khi đã set giá trị ban đầu ở trên,
            // tránh gọi tìm kiếm thừa lúc khởi tạo.
            txtTimTen.TextChanged += (s, e) => { if (_tuDongTim) TaiDuLieu(); };
            txtTimSoDen.TextChanged += (s, e) => { if (_tuDongTim) TaiDuLieu(); };
            nudNgay.ValueChanged += (s, e) => { if (_tuDongTim) TaiDuLieu(); };
            nudThang.ValueChanged += (s, e) => { if (_tuDongTim) TaiDuLieu(); };
            nudNam.ValueChanged += (s, e) => { if (_tuDongTim) TaiDuLieu(); };
            cboLocDoMat.SelectedIndexChanged += (s, e) => { if (_tuDongTim) TaiDuLieu(); };

            Load += (s, e) => TaiDuLieu();
            Shown += FormTraCuu_Shown;
        }

        private void FormTraCuu_Shown(object? sender, EventArgs e)
        {
            ActiveControl = txtTimTen;
            txtTimTen.Focus();
        }

        private void TaiDuLieu()
        {
            var ketQua = DbHelper.TimKiem(txtTimTen.Text, txtTimSoDen.Text, null, chkSapXepNgay.Checked);

            if (chkLocNgay.Checked)
            {
                int ngay = (int)nudNgay.Value;
                int thang = (int)nudThang.Value;
                int nam = (int)nudNam.Value;

                ketQua = ketQua.Where(v =>
                    (ngay == 0 || v.NgayNhan.Day == ngay) &&
                    (thang == 0 || v.NgayNhan.Month == thang) &&
                    (nam == 0 || v.NgayNhan.Year == nam)
                ).ToList();
            }

            if (cboLocDoMat.SelectedIndex >= 0)
            {
                string doMat = cboLocDoMat.SelectedItem!.ToString()!;
                ketQua = ketQua.Where(v => v.MucDoMat == doMat).ToList();
            }

            if (chkChuaHoanThanh.Checked)
            {
                ketQua = ketQua.Where(v => v.NgayHoanThanh.HasValue && !v.DaHoanThanh).ToList();
            }

            bool khongCoBoLoc = string.IsNullOrWhiteSpace(txtTimTen.Text)
                && string.IsNullOrWhiteSpace(txtTimSoDen.Text)
                && !chkLocNgay.Checked
                && cboLocDoMat.SelectedIndex < 0
                && !chkChuaHoanThanh.Checked;

            if (khongCoBoLoc && ketQua.Count > 20)
            {
                ketQua = ketQua.Take(20).ToList();
            }

            NapDuLieu(ketQua);
        }

        private void BtnTimKiem_Click(object sender, EventArgs e) => TaiDuLieu();

        private void ChkChuaHoanThanh_CheckedChanged(object sender, EventArgs e) => TaiDuLieu();

        private void ChkSapXepNgay_CheckedChanged(object sender, EventArgs e)
        {
            _nhoSapXepNgay = chkSapXepNgay.Checked;
            TaiDuLieu();
        }

        private void ChkLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            _nhoLocNgay = chkLocNgay.Checked;
            nudNgay.Enabled = chkLocNgay.Checked;
            nudThang.Enabled = chkLocNgay.Checked;
            nudNam.Enabled = chkLocNgay.Checked;
            if (_tuDongTim) TaiDuLieu();
        }

        private void BtnDatLai_Click(object sender, EventArgs e)
        {
            txtTimTen.Clear();
            txtTimSoDen.Clear();
            chkLocNgay.Checked = false;
            nudNgay.Value = 0;
            nudThang.Value = DateTime.Today.Month;
            nudNam.Value = DateTime.Today.Year;
            cboLocDoMat.SelectedIndex = -1;
            chkChuaHoanThanh.Checked = false;
            TaiDuLieu();
        }

        private void CboLocDoMat_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            string text;
            Color mauChu;

            if (e.Index == -1)
            {
                text = "Chọn độ mật...";
                mauChu = SystemColors.GrayText;
            }
            else
            {
                text = cboLocDoMat.Items[e.Index]?.ToString() ?? "";
                bool dangChon = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                mauChu = dangChon ? SystemColors.HighlightText : SystemColors.ControlText;
            }

            using var brush = new SolidBrush(mauChu);
            e.Graphics.DrawString(text, e.Font ?? cboLocDoMat.Font, brush,
                new PointF(e.Bounds.X + 2, e.Bounds.Y + 3));

            e.DrawFocusRectangle();
        }

        private void NapDuLieu(List<VanBan> danhSach)
        {
            grid.DataSource = danhSach.Select((v, idx) => new
            {
                STT = danhSach.Count - idx,
                v.Id,
                TenVanBan = v.TenVanBan,
                SoDen = v.SoDen,
                NgayNhan = v.NgayNhan.ToString("dd/MM/yyyy"),
                DoMat = v.MucDoMat,
                NgayHoanThanh = v.NgayHoanThanh?.ToString("dd/MM/yyyy") ?? "",
                TrangThai = !v.NgayHoanThanh.HasValue ? "" : (v.DaHoanThanh ? "Đã hoàn thành" : "Chưa hoàn thành"),
                TepDinhKem = v.CoTepDinhKem ? "Có" : "",
            }).ToList();

            if (grid.Columns["Id"] != null)
                grid.Columns["Id"]!.Visible = false;

            CanhChinhCot("STT", "STT", 50);
            CanhChinhCot("TenVanBan", "Số công văn", 190);
            CanhChinhCot("SoDen", "Số đến", 90);
            CanhChinhCot("NgayNhan", "Ngày nhận", 100);
            CanhChinhCot("DoMat", "Độ mật", 90);
            CanhChinhCot("NgayHoanThanh", "Ngày hoàn thành", 130);
            CanhChinhCot("TrangThai", "Trạng thái", 120);
            CanhChinhCot("TepDinhKem", "Tệp đính kèm", 100);

            if (grid.Rows.Count > 0)
            {
                grid.ClearSelection();
                try
                {
                    int colIndex = 0;
                    for (int i = 0; i < grid.Columns.Count; i++)
                    {
                        if (grid.Columns[i].Visible) { colIndex = i; break; }
                    }
                    grid.CurrentCell = grid.Rows[0].Cells[colIndex];
                }
                catch
                {
                    grid.Rows[0].Selected = true;
                }
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            CapNhatSoLuongMatToanBo();
            CapNhatThongKeHienThi(danhSach);
        }

        private void CanhChinhCot(string ten, string tieuDe, int doRong)
        {
            if (grid.Columns[ten] == null) return;
            grid.Columns[ten]!.HeaderText = tieuDe;
            grid.Columns[ten]!.Width = doRong;
        }

        private void CapNhatSoLuongMatToanBo()
        {
            var dem = DbHelper.DemTheoTungDoMat();
            int soMat = dem[DoMat.Mat];
            int soToiMat = dem[DoMat.ToiMat];
            int soTuyetMat = dem[DoMat.TuyetMat];
            int soKhong = dem[DoMat.Khong];
            int tongKhoa = soMat + soToiMat + soTuyetMat;

            lblThongKeToanBo.Text =
                $"Mật: {soMat}    Tối Mật: {soToiMat}    Tuyệt Mật: {soTuyetMat}        🔒 Đang khóa: {tongKhoa}   |   📄 Thường: {soKhong}";
        }

        private void CapNhatThongKeHienThi(List<VanBan> danhSachHienThi)
        {
            int khong = danhSachHienThi.Count(v => v.MucDoMat == DoMat.Khong);
            int mat = danhSachHienThi.Count(v => v.MucDoMat == DoMat.Mat);
            int toiMat = danhSachHienThi.Count(v => v.MucDoMat == DoMat.ToiMat);
            int tuyetMat = danhSachHienThi.Count(v => v.MucDoMat == DoMat.TuyetMat);

            lblThongKeHienThi.Text =
                $"Đang hiển thị {danhSachHienThi.Count} văn bản — Không: {khong}, Mật: {mat}, Tối Mật: {toiMat}, Tuyệt Mật: {tuyetMat}";
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = grid.Rows[e.RowIndex];
            if (row.Cells["Id"]?.Value == null) return;

            long id = Convert.ToInt64(row.Cells["Id"]!.Value);
            using var form = new FormChiTiet(id);
            form.ShowDialog(this);

            TaiDuLieu();
        }

        private void Grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count == 1)
            {
                var row = grid.SelectedRows[0];
                btnSua.Enabled = row.Cells["Id"]?.Value != null;
                btnXoa.Enabled = row.Cells["Id"]?.Value != null;
            }
            else
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count != 1) return;
            var row = grid.SelectedRows[0];
            if (row.Cells["Id"]?.Value == null) return;

            long id = Convert.ToInt64(row.Cells["Id"]!.Value);
            var vb = DbHelper.LayTheoId(id);
            if (vb == null) return;

            if (vb.CoDoMat)
            {
                if (!VaultHelper.DamBaoDaMoKhoa(this))
                {
                    MessageBox.Show("Cần xác thực mật khẩu để sửa văn bản có độ mật.", "Chưa xác thực",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            using var form = new FormNhapVanBan(id);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                TaiDuLieu();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count != 1) return;
            var row = grid.SelectedRows[0];
            if (row.Cells["Id"]?.Value == null) return;

            long id = Convert.ToInt64(row.Cells["Id"]!.Value);
            var vb = DbHelper.LayTheoId(id);
            if (vb == null) return;

            if (vb.CoDoMat)
            {
                if (!VaultHelper.DamBaoDaMoKhoa(this))
                {
                    MessageBox.Show("Cần xác thực mật khẩu để xóa văn bản có độ mật.", "Chưa xác thực",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var confirm = MessageBox.Show(
                vb.CoDoMat
                    ? $"Văn bản \"{vb.TenVanBan}\" thuộc Vùng lưu trữ CÓ KHÓA (Độ mật: {vb.MucDoMat}).\nBạn có chắc muốn xóa? Không thể hoàn tác."
                    : "Bạn có chắc muốn xóa văn bản này? Hành động này không thể hoàn tác.",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            DbHelper.XoaVanBan(id);
            MessageBox.Show("Đã xóa văn bản.", "Đã xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TaiDuLieu();
        }
    }
}