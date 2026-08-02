# QuanlyDL — Modun 1: Quản lý, lưu trữ văn bản/tài liệu có khóa bảo mật

Ứng dụng Windows Forms (.NET 8), chạy **offline hoàn toàn**, dùng SQLite làm
cơ sở dữ liệu. Toàn bộ dữ liệu (CSDL + tệp đính kèm) nằm gọn trong 1 thư mục
`Data` đặt cạnh file `QuanlyDL.exe` — chỉ cần copy nguyên thư mục ứng dụng
sang máy khác là dùng được ngay, không cần cài đặt gì thêm.

## 1. Cách mở dự án

1. Cài **Visual Studio 2022** (bản Community miễn phí), khi cài chọn workload
   **".NET desktop development"**.
2. Mở file `QuanlyDL.sln`.
3. Lần đầu mở, Visual Studio sẽ tự tải gói NuGet `Microsoft.Data.Sqlite`
   (cần Internet 1 lần duy nhất lúc này). Sau khi tải xong có thể build/chạy
   hoàn toàn offline.
4. Nhấn **F5** để chạy.

## 2. Cấu trúc dự án

```
QuanlyDL/
├── QuanlyDL.sln
└── QuanlyDL/
    ├── QuanlyDL.csproj
    ├── Program.cs                 → điểm khởi động
    ├── AppPaths.cs                → đường dẫn thư mục dữ liệu dùng chung
    ├── Models/
    │   └── VanBan.cs               → model 1 bản ghi văn bản
    ├── Data/
    │   └── DbHelper.cs             → toàn bộ thao tác SQLite
    ├── Security/
    │   ├── CryptoHelper.cs         → mã hóa/giải mã AES-GCM
    │   ├── VaultSession.cs         → giữ khóa mã hóa trong phiên làm việc
    │   └── VaultHelper.cs          → điều phối tạo/xác thực mật khẩu
    └── Forms/
        ├── FormMain                → menu chính + thông báo sắp đến hạn
        ├── FormNhapVanBan          → nhập văn bản mới
        ├── FormTraCuu              → tìm kiếm/danh sách văn bản
        ├── FormChiTiet             → xem chi tiết, giải mã, mở tệp đính kèm
        ├── FormTaoMatKhauVault     → thiết lập mật khẩu vùng có khóa (lần đầu)
        └── FormXacThucVault        → nhập mật khẩu để mở vùng có khóa
```

Khi chạy, ứng dụng tự tạo cấu trúc dưới thư mục `Data` (cạnh file .exe):

```
Data/
├── QuanlyDL.db          → cơ sở dữ liệu SQLite (thông tin văn bản + cài đặt)
├── Attachments/          → tệp đính kèm KHÔNG có độ mật (lưu nguyên bản)
├── AttachmentsLocked/    → tệp đính kèm CÓ độ mật (đã mã hóa AES, đuôi .enc)
└── TempGiaiMa/           → tệp tạm khi mở xem tài liệu đã mã hóa
```

## 3. Cách hoạt động theo yêu cầu nghiệp vụ

- **Nhập văn bản** (Form "Nhập văn bản mới"): nhập đủ 9 mục theo yêu cầu,
  trong đó *Tên văn bản*, *Số đến*, *Ngày nhận* bắt buộc; các mục còn lại
  tùy chọn. *Độ mật* mặc định "Không".
- **Phân vùng lưu trữ:** nếu Độ mật khác "Không", hệ thống yêu cầu mật khẩu
  (đặt lần đầu, xác thực từ lần sau), rồi **mã hóa** các trường Nội dung,
  Chuyển, Số&Ký hiệu HS, Cán bộ tiếp nhận (thuật toán AES‑256‑GCM, khóa suy
  ra từ mật khẩu bằng PBKDF2) và mã hóa cả tệp đính kèm trước khi ghi vào
  thư mục `AttachmentsLocked`. Văn bản không có độ mật lưu bình thường vào
  `Attachments`.
- **Thông báo hạn xử lý:** nếu có "Ngày hoàn thành", mỗi lần mở ứng dụng hệ
  thống kiểm tra và hiển thị thông báo cho các văn bản còn ≤ X ngày tới hạn
  (kể cả đã quá hạn) mà chưa được đánh dấu hoàn thành. Số ngày **X có thể
  tùy chỉnh** qua nút "⚙️ Cài đặt" ở màn hình chính (mặc định X = 2, lưu
  trong CSDL nên không mất khi khởi động lại).
- **Tra cứu:** tìm theo Tên văn bản / Số đến / Ngày nhận (có thể kết hợp
  hoặc để trống từng mục). Nhấp đúp một dòng để xem chi tiết — nếu văn bản
  thuộc vùng có khóa, hệ thống yêu cầu nhập mật khẩu trước khi hiển thị nội
  dung và cho phép mở tệp đính kèm.

## 4. Gợi ý nâng cấp về sau (đúng như định hướng "modun tính năng")

Vì kiến trúc đã tách rõ **Models / Data / Security / Forms**, bạn có thể bổ
sung modun mới (ví dụ: Modun 2 quản lý công việc, Modun 3 báo cáo thống kê…)
bằng cách thêm Form và bảng CSDL mới mà không ảnh hưởng phần đã có. Một số
hướng nâng cấp gợi ý cho Modun 1:

- Dùng khay hệ thống (`NotifyIcon`) để thông báo nhắc hạn dạng balloon-tip
  thay vì hộp thoại, kèm chạy nền kiểm tra định kỳ.
- Cho phép đính kèm **nhiều tệp** cho 1 văn bản (thêm bảng `TepDinhKem`
  quan hệ 1-nhiều với `VanBan`).
- Thêm chức năng đổi mật khẩu vùng có khóa (giải mã toàn bộ bằng khóa cũ,
  mã hóa lại bằng khóa mới).
- Xuất báo cáo Excel/PDF danh sách văn bản theo bộ lọc.
- Vì toàn bộ giao diện dựng bằng `TableLayoutPanel`/control chuẩn WinForms,
  bạn hoàn toàn có thể mở từng Form bằng **Designer kéo-thả** của Visual
  Studio để chỉnh sửa giao diện trực quan mà không phải sửa code tay.

## 5. Lưu ý bảo mật

- Mật khẩu vùng có khóa **không được lưu dưới dạng rõ** ở bất kỳ đâu; chỉ
  lưu salt + 1 đoạn dữ liệu kiểm tra đã mã hóa để xác thực.
- Nếu quên mật khẩu, dữ liệu đã mã hóa **không thể khôi phục** — nên nhắc
  người dùng ghi nhớ/lưu trữ mật khẩu ở nơi an toàn khi lần đầu thiết lập.
- Khi sao chép ứng dụng sang máy khác, hãy copy **toàn bộ** thư mục chứa
  file `.exe` (bao gồm thư mục `Data`) để không mất dữ liệu.
