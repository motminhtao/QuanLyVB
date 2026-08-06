using System.IO;
using QuanlyDL.Data;
using QuanlyDL.Models;
using QuanlyDL.Security;

namespace QuanlyDL.Forms
{
    public partial class FormNhapVanBan : Form
    {
        private string? _duongDanTepDaChon;
        private long? _editingId;
        private string? _originalTenTepLuu;

        public FormNhapVanBan()
        {
            InitializeComponent();
            dtpNgayNhan.Value = DateTime.Today;
            dtpNgayHoanThanh.Value = DateTime.Today.AddDays(7);

            // Cho phép Form bắt sự kiện phím trước khi chuyển tới control đang focus
            KeyPreview = true;
            KeyDown += FormNhapVanBan_KeyDown;
        }

        /// <summary>
        /// Nhấn Enter sẽ nhảy sang ô kế tiếp (giống Tab), trừ:
        /// - Ô Nội dung (multiline): Enter dùng để xuống dòng như bình thường
        /// - Đang focus vào Button: Enter dùng để bấm nút đó (hành vi mặc định)
        /// </summary>
        private void FormNhapVanBan_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (ActiveControl is Button) return;
            if (ActiveControl == txtNoiDung) return; // cho phép xuống dòng

            e.Handled = true;
            e.SuppressKeyPress = true; // chặn tiếng "beep"
            SelectNextControl(ActiveControl, true, true, true, true);
        }

        /// <summary>
        /// Constructor để sửa văn bản hiện có.
        /// </summary>
        public FormNhapVanBan(long id) : this()
        {
            _editingId = id;
            var vb = DbHelper.LayTheoId(id);
            if (vb == null)
            {
                MessageBox.Show("Không tìm thấy văn bản để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // Điền các trường
            txtTen.Text = vb.TenVanBan;
            txtSoDen.Text = vb.SoDen;
            dtpNgayNhan.Value = vb.NgayNhan;
            cboDoMat.SelectedItem = vb.MucDoMat;
            if (vb.NgayHoanThanh.HasValue)
            {
                chkCoHan.Checked = true;
                dtpNgayHoanThanh.Value = vb.NgayHoanThanh.Value;
            }
            else
            {
                chkCoHan.Checked = false;
            }

            // Văn bản có độ mật: FormTraCuu đã bắt xác thực trước khi mở form này.
            // Nếu vì lý do nào đó khoá vẫn chưa mở -> chặn hẳn, không cho sửa
            // (giống hành vi chặn của chức năng Xóa).
            if (vb.CoDoMat)
            {
                if (VaultSession.Khoa == null)
                {
                    MessageBox.Show("Cần xác thực mật khẩu trước khi sửa văn bản có độ mật.",
                        "Chưa xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                try
                {
                    txtChuyen.Text = CryptoHelper.GiaiMaChuoi(VaultSession.Khoa, vb.Chuyen);
                    txtSoKyHieu.Text = CryptoHelper.GiaiMaChuoi(VaultSession.Khoa, vb.SoKyHieuHS);
                    txtNoiDung.Text = CryptoHelper.GiaiMaChuoi(VaultSession.Khoa, vb.NoiDung);
                    txtCanBo.Text = CryptoHelper.GiaiMaChuoi(VaultSession.Khoa, vb.CanBoTiepNhan);
                }
                catch
                {
                    MessageBox.Show("Không thể giải mã dữ liệu (mật khẩu không đúng hoặc dữ liệu lỗi). Không thể sửa văn bản này.",
                        "Lỗi giải mã", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }
            }

            // Tệp đính kèm cũ (chỉ hiển thị tên gốc)
            _originalTenTepLuu = vb.TenTepLuu;
            txtTenTepChon.Text = vb.TenTepGoc ?? "";
        }

        private void ChkCoHan_CheckedChanged(object? sender, EventArgs e)
        {
            dtpNgayHoanThanh.Enabled = chkCoHan.Checked;
        }

        private void BtnChonTep_Click(object? sender, EventArgs e)
        {
            using var ofd = new OpenFileDialog
            {
                Title = "Chọn tệp đính kèm (bất kỳ định dạng)",
                Filter = "Tất cả tệp (*.*)|*.*"
            };
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                _duongDanTepDaChon = ofd.FileName;
                txtTenTepChon.Text = Path.GetFileName(ofd.FileName);
            }
        }

        private void BtnLuu_Click(object? sender, EventArgs e)
        {
            if (!KiemTraHopLe()) return;

            string mucDoMat = cboDoMat.SelectedItem?.ToString() ?? DoMat.Khong;
            bool coDoMat = mucDoMat != DoMat.Khong;

            // Nếu có độ mật -> cần mở khóa vùng lưu trữ có khóa trước khi lưu
            if (coDoMat)
            {
                if (!VaultHelper.DamBaoDaMoKhoa(this))
                {
                    MessageBox.Show("Cần xác thực mật khẩu để lưu văn bản có độ mật.",
                        "Chưa xác thực", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var vb = new VanBan
            {
                TenVanBan = txtTen.Text.Trim(),
                SoDen = txtSoDen.Text.Trim(),
                NgayNhan = dtpNgayNhan.Value.Date,
                Chuyen = ChuoiRong(txtChuyen.Text),
                SoKyHieuHS = ChuoiRong(txtSoKyHieu.Text),
                NoiDung = ChuoiRong(txtNoiDung.Text),
                CanBoTiepNhan = ChuoiRong(txtCanBo.Text),
                MucDoMat = mucDoMat,
                NgayHoanThanh = chkCoHan.Checked ? dtpNgayHoanThanh.Value.Date : null,
                DaHoanThanh = false,
                NgayTao = DateTime.Now,
            };

            // Mã hóa các trường nội dung nếu có độ mật
            if (coDoMat)
            {
                var khoa = VaultSession.Khoa!;
                vb.Chuyen = CryptoHelper.MaHoaChuoi(khoa, vb.Chuyen);
                vb.SoKyHieuHS = CryptoHelper.MaHoaChuoi(khoa, vb.SoKyHieuHS);
                vb.NoiDung = CryptoHelper.MaHoaChuoi(khoa, vb.NoiDung);
                vb.CanBoTiepNhan = CryptoHelper.MaHoaChuoi(khoa, vb.CanBoTiepNhan);
            }

            // Xử lý tệp đính kèm: nếu người dùng chọn tệp mới (_duongDanTepDaChon != null),
            // lưu tệp mới và xóa tệp cũ (nếu đang sửa).
            if (!string.IsNullOrEmpty(_duongDanTepDaChon))
            {
                string phanMoRong = Path.GetExtension(_duongDanTepDaChon);
                string tenTepMoi = Guid.NewGuid().ToString("N") + (coDoMat ? phanMoRong + ".enc" : phanMoRong);
                string thuMucDich = coDoMat ? AppPaths.ThuMucTepCoKhoa : AppPaths.ThuMucTepKhongKhoa;
                string duongDanDich = Path.Combine(thuMucDich, tenTepMoi);

                if (coDoMat)
                {
                    CryptoHelper.MaHoaTep(VaultSession.Khoa!, _duongDanTepDaChon, duongDanDich);
                }
                else
                {
                    File.Copy(_duongDanTepDaChon, duongDanDich, overwrite: true);
                }

                // Nếu đang sửa và có tệp cũ, xóa tệp cũ trên đĩa
                if (_editingId.HasValue && !string.IsNullOrEmpty(_originalTenTepLuu))
                {
                    var thuMucCu = (mucDoMat == DoMat.Khong) ? AppPaths.ThuMucTepKhongKhoa : AppPaths.ThuMucTepCoKhoa;
                    var duongDanCu = Path.Combine(thuMucCu, _originalTenTepLuu);
                    try
                    {
                        if (File.Exists(duongDanCu)) File.Delete(duongDanCu);
                    }
                    catch
                    {
                        // Không dừng lưu vì không thể xóa tệp cũ
                    }
                }

                vb.TenTepLuu = tenTepMoi;
                vb.TenTepGoc = Path.GetFileName(_duongDanTepDaChon);
            }
            else
            {
                // Nếu không chọn tệp mới khi sửa, giữ tệp cũ (nếu có)
                if (_editingId.HasValue)
                {
                    vb.TenTepLuu = _originalTenTepLuu;
                    // giữ tên gốc không đổi (nguyên trạng)
                    vb.TenTepGoc = txtTenTepChon.Text;
                }
            }

            if (_editingId.HasValue)
            {
                vb.Id = _editingId.Value;
                DbHelper.CapNhatVanBan(vb);
            }
            else
            {
                DbHelper.ThemVanBan(vb);
            }

            // Chỉ hiện thông báo khi lưu văn bản CÓ ĐỘ MẬT, và chỉ khi người dùng
            // đã bật tuỳ chọn "Hiển thị thông báo khi lưu văn bản Mật" trong Cài đặt.
            if (coDoMat && DbHelper.LayHienThongBaoLuuMat())
            {
                MessageBox.Show("Đã lưu văn bản vào Vùng lưu trữ CÓ KHÓA (đã mã hóa).",
                    "Lưu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool KiemTraHopLe()
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                CanhBao("Vui lòng nhập Tên văn bản.", txtTen);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtSoDen.Text))
            {
                CanhBao("Vui lòng nhập Số đến.", txtSoDen);
                return false;
            }
            return true;
        }

        private void CanhBao(string thongDiep, Control dieuKhien)
        {
            MessageBox.Show(thongDiep, "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            dieuKhien.Focus();
        }

        private static string? ChuoiRong(string s) => string.IsNullOrWhiteSpace(s) ? null : s.Trim();
    }
}