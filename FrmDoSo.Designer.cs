
namespace XoSo_TrinhPhucHieu
{
    partial class FrmDoSo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dtpngayDo = new System.Windows.Forms.DateTimePicker();
            this.cmbDai = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbKetQua = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDoHT = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnDoLai = new System.Windows.Forms.Button();
            this.btnDoKetQuaLuu = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.LightGray;
            this.btnTimKiem.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.ForeColor = System.Drawing.Color.Black;
            this.btnTimKiem.Location = new System.Drawing.Point(374, 128);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(135, 34);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Dò Vé";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dtpngayDo
            // 
            this.dtpngayDo.CustomFormat = "dd/MM/yyyy";
            this.dtpngayDo.Font = new System.Drawing.Font("Times New Roman", 12.8F, System.Drawing.FontStyle.Bold);
            this.dtpngayDo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpngayDo.Location = new System.Drawing.Point(490, 7);
            this.dtpngayDo.Name = "dtpngayDo";
            this.dtpngayDo.Size = new System.Drawing.Size(153, 32);
            this.dtpngayDo.TabIndex = 2;
            this.dtpngayDo.ValueChanged += new System.EventHandler(this.dtpngayDo_ValueChanged);
            // 
            // cmbDai
            // 
            this.cmbDai.DropDownHeight = 90;
            this.cmbDai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDai.DropDownWidth = 30;
            this.cmbDai.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.cmbDai.FormattingEnabled = true;
            this.cmbDai.IntegralHeight = false;
            this.cmbDai.Items.AddRange(new object[] {
            "Không Chọn",
            "Đà Nẵng",
            "Quảng Nam",
            "Huế",
            "Hà Nội",
            "Sài Gòn",
            "Hải Phòng",
            "Gia Lai",
            "Hòa Bình",
            "Hà Giang",
            "Hà Tĩnh",
            "Hưng Yên",
            "Hải Dương",
            "Hậu Giang",
            "Điện Biên",
            "Đắk Lắk",
            "Đắk Nông",
            "Đồng Nai",
            "Đồng Tháp",
            "Khánh Hòa",
            "Kiên Giang",
            "Kon Tum",
            "Long An",
            "Lào Cai",
            "Lâm Đồng",
            "Lạng Sơn",
            "Nam Định",
            "Nghệ An",
            "Ninh Bình",
            "Ninh Thuận",
            "Phú Thọ",
            "Phú Yên",
            "Quảng Bình",
            "Quảng Ngãi",
            "Quảng Ninh",
            "Quảng Trị",
            "Sóc Trăng",
            "Sơn La",
            "Thanh Hóa",
            "Thái Bình",
            "Thái Nguyên",
            "Tiền Giang",
            "Trà Vinh",
            "Tuyên Quang",
            "Tây Ninh",
            "Vĩnh Long",
            "Vĩnh Phúc",
            "Yên Bái",
            "An Giang",
            "Vũng Tàu",
            "Bạc Liêu",
            "Bắc Giang",
            "Bắc Kạn",
            "Bắc Ninh",
            "Bến Tre",
            "Bình Dương",
            "Bình Định",
            "Bình Phước",
            "Bình Thuận",
            "Cao Bằng",
            "Cà Mau",
            "Cần Thơ"});
            this.cmbDai.Location = new System.Drawing.Point(490, 49);
            this.cmbDai.Name = "cmbDai";
            this.cmbDai.Size = new System.Drawing.Size(160, 31);
            this.cmbDai.TabIndex = 3;
            this.cmbDai.SelectedIndexChanged += new System.EventHandler(this.cmbDai_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nhập Số dò";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(347, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chọn ngày dò";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(387, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Chọn đài";
            // 
            // cmbKetQua
            // 
            this.cmbKetQua.BackColor = System.Drawing.SystemColors.Menu;
            this.cmbKetQua.DropDownHeight = 110;
            this.cmbKetQua.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKetQua.DropDownWidth = 30;
            this.cmbKetQua.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.cmbKetQua.FormattingEnabled = true;
            this.cmbKetQua.IntegralHeight = false;
            this.cmbKetQua.Location = new System.Drawing.Point(203, 87);
            this.cmbKetQua.Name = "cmbKetQua";
            this.cmbKetQua.Size = new System.Drawing.Size(445, 31);
            this.cmbKetQua.TabIndex = 7;
            this.cmbKetQua.SelectedIndexChanged += new System.EventHandler(this.cmbKetQua_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(2, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dò Kết Quả Lưu";
            // 
            // cmbDoHT
            // 
            this.cmbDoHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoHT.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.cmbDoHT.FormattingEnabled = true;
            this.cmbDoHT.Location = new System.Drawing.Point(203, 50);
            this.cmbDoHT.Name = "cmbDoHT";
            this.cmbDoHT.Size = new System.Drawing.Size(159, 31);
            this.cmbDoHT.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 11.8F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(2, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 23);
            this.label5.TabIndex = 10;
            this.label5.Text = "Dò Kết Quả Vừa Xổ";
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvKetQua.Location = new System.Drawing.Point(-1, 168);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.RowHeadersWidth = 51;
            this.dgvKetQua.RowTemplate.Height = 24;
            this.dgvKetQua.Size = new System.Drawing.Size(651, 366);
            this.dgvKetQua.TabIndex = 12;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Đài Quay";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 210;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Giải";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Kết Quả";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 140;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.BackColor = System.Drawing.SystemColors.Info;
            this.txtTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiem.Location = new System.Drawing.Point(138, 7);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(203, 30);
            this.txtTimKiem.TabIndex = 14;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnDoLai
            // 
            this.btnDoLai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnDoLai.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDoLai.ForeColor = System.Drawing.Color.Red;
            this.btnDoLai.Location = new System.Drawing.Point(515, 128);
            this.btnDoLai.Name = "btnDoLai";
            this.btnDoLai.Size = new System.Drawing.Size(135, 34);
            this.btnDoLai.TabIndex = 13;
            this.btnDoLai.Text = "Xóa";
            this.btnDoLai.UseVisualStyleBackColor = false;
            this.btnDoLai.Click += new System.EventHandler(this.btnDoLai_Click);
            // 
            // btnDoKetQuaLuu
            // 
            this.btnDoKetQuaLuu.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnDoKetQuaLuu.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold);
            this.btnDoKetQuaLuu.ForeColor = System.Drawing.Color.Black;
            this.btnDoKetQuaLuu.Location = new System.Drawing.Point(162, 128);
            this.btnDoKetQuaLuu.Name = "btnDoKetQuaLuu";
            this.btnDoKetQuaLuu.Size = new System.Drawing.Size(206, 34);
            this.btnDoKetQuaLuu.TabIndex = 15;
            this.btnDoKetQuaLuu.Text = "Dò Kết Quả Lưu";
            this.btnDoKetQuaLuu.UseVisualStyleBackColor = false;
            this.btnDoKetQuaLuu.Click += new System.EventHandler(this.btnDoKetQuaLuu_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(5, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 32);
            this.button1.TabIndex = 16;
            this.button1.Text = "!";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmDoSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 536);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnDoKetQuaLuu);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnDoLai);
            this.Controls.Add(this.dgvKetQua);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDoHT);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbKetQua);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbDai);
            this.Controls.Add(this.dtpngayDo);
            this.Controls.Add(this.btnTimKiem);
            this.Name = "FrmDoSo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dò Vé - Phúc Hiếu";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DateTimePicker dtpngayDo;
        private System.Windows.Forms.ComboBox cmbDai;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbKetQua;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDoHT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvKetQua;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnDoLai;
        private System.Windows.Forms.Button btnDoKetQuaLuu;
        private System.Windows.Forms.Button button1;
    }
}