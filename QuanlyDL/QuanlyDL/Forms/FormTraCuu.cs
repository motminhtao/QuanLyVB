using QuanlyDL.Data;
using QuanlyDL.Models;
using QuanlyDL.Security;

namespace QuanlyDL.Forms
{
    public partial class FormTraCuu : Form
    {
        public FormTraCuu()
        {
            InitializeComponent();
            Load += (s, e) => TaiDuLieu();
        }

        /// <summary>
        /// Nạp lại dữ liệu theo đúng bộ lọc (tên/số đến/ngày, độ mật) và
        /// tuỳ chọn sắp xếp hiện tại.
        /// </summary>
        private void TaiDuLieu()
        {
            var ketQua = DbHelper.TimKiem(
                txtTimTen.Text,
                txtTimSoDen.Text,
                chkLocNgay.Checked ? dtpTimNgay.Value.Date : (DateTime?)null,
                chkSapXepNgay.Checked);

            if (cboLocDoMat.SelectedIndex >= 0)
            {
                string doMat = cboLocDoMat.SelectedItem!.ToString()!;
                ketQua = ketQua.Where(v => v.MucDoMat == doMat).ToList();
            }

            NapDuLieu(ketQua);
        }

        private void BtnTimKiem_Click(object sender, EventArgs e) => TaiDuLieu();

        private void BtnLoc_Click(object sender, EventArgs e) => TaiDuLieu();

        private void BtnHienTatCa_Click(object sender, EventArgs e)
        {
            txtTimTen.Clear();
            txtTimSoDen.Clear();
            chkLocNgay.Checked = false;
            cboLocDoMat.SelectedIndex = -1;
            TaiDuLieu();
        }

        private void ChkSapXepNgay_CheckedChanged(object sender, EventArgs e) => TaiDuLieu();

        private void ChkLocNgay_CheckedChanged(object sender, EventArgs e)
        {
            dtpTimNgay.Enabled = chkLocNgay.Checked;
        }

        /// <summary>
        /// Vẽ chữ xám nhạt "Chọn độ mật..." khi ô lọc chưa chọn gì (SelectedIndex = -1).
        /// </summary>
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
                new PointF(e.Bounds.X + 2, e.Bounds.Y + 2));

            e.DrawFocusRectangle();
        }

        private void NapDuLieu(List<VanBan> danhSach)
        {
            grid.DataSource = danhSach.Select((v, idx) => new
            {
                STT = idx + 1,
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
            if (grid.Columns["STT"] != null)
                grid.Columns["STT"]!.Width = 55;

            RenameCotNeuTonTai("STT", "STT");
            RenameCotNeuTonTai("TenVanBan", "Tên văn bản");
            RenameCotNeuTonTai("SoDen", "Số đến");
            RenameCotNeuTonTai("NgayNhan", "Ngày nhận");
            RenameCotNeuTonTai("DoMat", "Độ mật");
            RenameCotNeuTonTai("NgayHoanThanh", "Ngày hoàn thành");
            RenameCotNeuTonTai("TrangThai", "Trạng thái");
            RenameCotNeuTonTai("TepDinhKem", "Tệp đính kèm");

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

            CapNhatSoLuongMat();
        }

        private void CapNhatSoLuongMat()
        {
            var dem = DbHelper.DemTheoTungDoMat();
            int soMat = dem[DoMat.Mat];
            int soToiMat = dem[DoMat.ToiMat];
            int soTuyetMat = dem[DoMat.TuyetMat];
            int soKhong = dem[DoMat.Khong];
            int tongKhoa = soMat + soToiMat + soTuyetMat;

            lblDemMat.Text = $"Mật: {soMat}";
            lblDemToiMat.Text = $"Tối Mật: {soToiMat}";
            lblDemTuyetMat.Text = $"Tuyệt Mật: {soTuyetMat}";
            lblTongKhoaThuong.Text = $"🔒 Đang khóa: {tongKhoa}   |   📄 Thường: {soKhong}";
        }

        private void RenameCotNeuTonTai(string ten, string tieuDe)
        {
            if (grid.Columns[ten] != null) grid.Columns[ten]!.HeaderText = tieuDe;
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