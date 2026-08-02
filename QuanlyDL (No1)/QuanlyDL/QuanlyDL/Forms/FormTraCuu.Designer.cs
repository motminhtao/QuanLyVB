namespace QuanlyDL.Forms
{
    partial class FormTraCuu
    {
        private System.ComponentModel.IContainer components = null!;

        private Label lblTieuDe = null!;
        private Label lblTen = null!;
        private TextBox txtTimTen = null!;
        private Label lblSoDen = null!;
        private TextBox txtTimSoDen = null!;
        private CheckBox chkLocNgay = null!;
        private DateTimePicker dtpTimNgay = null!;
        private Button btnTimKiem = null!;
        private Button btnHienTatCa = null!;
        private Button btnSua = null!;
        private Button btnXoa = null!;
        private DataGridView grid = null!;
        private Label lblGhiChu = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTraCuu));
            lblTieuDe = new Label();
            lblTen = new Label();
            txtTimTen = new TextBox();
            lblSoDen = new Label();
            txtTimSoDen = new TextBox();
            chkLocNgay = new CheckBox();
            dtpTimNgay = new DateTimePicker();
            btnTimKiem = new Button();
            btnHienTatCa = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            grid = new DataGridView();
            lblGhiChu = new Label();
            ((System.ComponentModel.ISupportInitialize)grid).BeginInit();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTieuDe.Location = new Point(23, 20);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(212, 30);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "TRA CỨU VĂN BẢN";
            // 
            // lblTen
            // 
            lblTen.AutoSize = true;
            lblTen.Location = new Point(23, 73);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(91, 20);
            lblTen.TabIndex = 1;
            lblTen.Text = "Tên văn bản:";
            // 
            // txtTimTen
            // 
            txtTimTen.Location = new Point(120, 69);
            txtTimTen.Margin = new Padding(3, 4, 3, 4);
            txtTimTen.Name = "txtTimTen";
            txtTimTen.Size = new Size(228, 27);
            txtTimTen.TabIndex = 2;
            // 
            // lblSoDen
            // 
            lblSoDen.AutoSize = true;
            lblSoDen.Location = new Point(366, 73);
            lblSoDen.Name = "lblSoDen";
            lblSoDen.Size = new Size(58, 20);
            lblSoDen.TabIndex = 3;
            lblSoDen.Text = "Số đến:";
            // 
            // txtTimSoDen
            // 
            txtTimSoDen.Location = new Point(434, 69);
            txtTimSoDen.Margin = new Padding(3, 4, 3, 4);
            txtTimSoDen.Name = "txtTimSoDen";
            txtTimSoDen.Size = new Size(159, 27);
            txtTimSoDen.TabIndex = 4;
            // 
            // chkLocNgay
            // 
            chkLocNgay.AutoSize = true;
            chkLocNgay.Location = new Point(23, 117);
            chkLocNgay.Margin = new Padding(3, 4, 3, 4);
            chkLocNgay.Name = "chkLocNgay";
            chkLocNgay.Size = new Size(166, 24);
            chkLocNgay.TabIndex = 5;
            chkLocNgay.Text = "Lọc theo Ngày nhận:";
            chkLocNgay.CheckedChanged += ChkLocNgay_CheckedChanged;
            // 
            // dtpTimNgay
            // 
            dtpTimNgay.Enabled = false;
            dtpTimNgay.Format = DateTimePickerFormat.Short;
            dtpTimNgay.Location = new Point(183, 113);
            dtpTimNgay.Margin = new Padding(3, 4, 3, 4);
            dtpTimNgay.Name = "dtpTimNgay";
            dtpTimNgay.Size = new Size(148, 27);
            dtpTimNgay.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(434, 109);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(126, 40);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "🔍 Tìm kiếm";
            btnTimKiem.Click += BtnTimKiem_Click;
            // 
            // btnHienTatCa
            // 
            btnHienTatCa.Location = new Point(571, 109);
            btnHienTatCa.Margin = new Padding(3, 4, 3, 4);
            btnHienTatCa.Name = "btnHienTatCa";
            btnHienTatCa.Size = new Size(114, 40);
            btnHienTatCa.TabIndex = 8;
            btnHienTatCa.Text = "Hiện tất cả";
            btnHienTatCa.Click += BtnHienTatCa_Click;
            // 
            // btnSua
            // 
            btnSua.Enabled = false;
            btnSua.Location = new Point(709, 109);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(80, 40);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.Click += BtnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Enabled = false;
            btnXoa.Location = new Point(800, 109);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(91, 40);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.Click += BtnXoa_Click;
            // 
            // grid
            // 
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersHeight = 29;
            grid.Location = new Point(23, 171);
            grid.Margin = new Padding(3, 4, 3, 4);
            grid.MultiSelect = false;
            grid.Name = "grid";
            grid.ReadOnly = true;
            grid.RowHeadersWidth = 51;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.Size = new Size(869, 507);
            grid.TabIndex = 11;
            grid.CellDoubleClick += Grid_CellDoubleClick;
            grid.SelectionChanged += Grid_SelectionChanged;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.ForeColor = Color.DimGray;
            lblGhiChu.Location = new Point(23, 687);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(565, 20);
            lblGhiChu.TabIndex = 12;
            lblGhiChu.Text = "Nhấp đúp vào 1 dòng để xem chi tiết. Văn bản có độ mật sẽ yêu cầu nhập mật khẩu.";
            // 
            // FormTraCuu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 733);
            Controls.Add(lblTieuDe);
            Controls.Add(lblTen);
            Controls.Add(txtTimTen);
            Controls.Add(lblSoDen);
            Controls.Add(txtTimSoDen);
            Controls.Add(chkLocNgay);
            Controls.Add(dtpTimNgay);
            Controls.Add(btnTimKiem);
            Controls.Add(btnHienTatCa);
            Controls.Add(btnSua);
            Controls.Add(btnXoa);
            Controls.Add(grid);
            Controls.Add(lblGhiChu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(930, 770);
            Name = "FormTraCuu";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Tra cứu văn bản";
            ((System.ComponentModel.ISupportInitialize)grid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}