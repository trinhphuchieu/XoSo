using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// ------------------------- TRỊNH PHÚC HIẾU 18CT1 --------------------- 
namespace XoSo_TrinhPhucHieu
{
    public partial class FrmDoSo : Form
    {
        private String ngay = "";
        private String tinh = "";

        public FrmDoSo(Hashtable s1, Hashtable s2,String[] giaiMaTen,String tinh,String ngay)
        {
            InitializeComponent();
          
        
            cmbKetQua.Items.AddRange(giaiMaTen);
       
            cmbDoHT.Items.Add("Không Chọn");
            cmbDai.SelectedIndex = 0;
            this.ngay = ngay;
            this.tinh = tinh;
            cmbDoHT.SelectedIndex = 0;
            if (s1.Count > 0)
            {
                cmbDoHT.Items.Add("Đà Nẵng");
             

            }
            if(s2.Count > 0)
            {
                cmbDoHT.Items.Add(tinh);
                
            }
            

        }

       

        private void cmbKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox thuMuc = (ComboBox)sender;
            String duongDan = Cls_Hieu.giaiMaDuongDan(thuMuc.Text);
            string[] s = FrmHieu.giaiTriDoi(duongDan).Split('-');// cắt tên
            string s1 = s[0].Trim().ToLower();
            string[] cat = s1.Split(' ');
            string sa = "";
            for(int i = 0; i < cat.Length; i++)
            {
                sa += char.ToUpper(cat[i][0]) + cat[i].Substring(1) + " ";
            }
          
            cmbDai.SelectedItem = sa.Trim();
        


        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            if (txtTimKiem.Text.Length < 2 || txtTimKiem.Text.Length > 6)
            {
                MessageBox.Show("Nhập Kết quả phải lớn hơn 2 và nhỏ hơn 6 !!", "Thông báo");
                return;
            }
            dgvKetQua.Rows.Clear();
            if(cmbDai.SelectedIndex != 0 && cmbDoHT.SelectedIndex !=0)
            {
                MessageBox.Show("Vui lòng chọn 1 hoặc 2\nDò đài vừa xổ hay dò theo ngày và đài.","Lưu Ý");
                cmbDoHT.SelectedIndex = 0;
                cmbDai.SelectedIndex = 0;
                return;
            }    
            // dò theo đà nẵng hiện tại xổ
            if (cmbDoHT.SelectedIndex == 1)
            {
                String s11 = Cls_Hieu.ketQuaTimKiem(txtTimKiem.Text, Cls_Hieu.luuGiaTri);
                String[] timDuoc1 = s11.Split('@');
                for (int i = 0; i < timDuoc1.Length - 1; i++)
                {
                    string[] a = timDuoc1[i].Split(' ');
                    dgvKetQua.Rows.Add("ĐÀ NẴNG" + " ngày " + this.ngay, Cls_Hieu.giaiGiDo(a[0]), a[1]);

                }
                if (s11.Length == 0) MessageBox.Show("Không tìm thấy kết quả !", "Thông Báo");

            }
            // dò theo đài xổ hiện tại
            if (cmbDoHT.SelectedIndex == 2)
            {
                String s12 = Cls_Hieu.ketQuaTimKiem(txtTimKiem.Text, Cls_Hieu.luuGiaTri2);
                String[] timDuoc2 = s12.Split('@');
                for (int i = 0; i < timDuoc2.Length - 1; i++)
                {
                    string[] a = timDuoc2[i].Split(' ');
                    dgvKetQua.Rows.Add(this.tinh + " ngày " + this.ngay, Cls_Hieu.giaiGiDo(a[0]), a[1]);

                }
                if (s12.Length == 0) MessageBox.Show("Không tìm thấy kết quả !", "Thông Báo");
            }
            // dò theo đài 
            if(cmbKetQua.SelectedIndex == -1 && cmbDoHT.SelectedIndex == 0 && cmbDai.SelectedIndex != 0)
            {
                String s13 = Cls_Hieu.ketQuaTimTheoDai(txtTimKiem.Text, cmbDai.Text, dtpngayDo.Text);
                String[] timDuoc3 = s13.Split('@');
                if (timDuoc3.Contains("Không tìm thấy đài dò"))
                {
                    MessageBox.Show("Không tìm thấy dữ liệu đài dò có ngày đó!", "Thông Báo");
                    return;
                }
                for (int i = 0; i < timDuoc3.Length - 1; i++)
                {
                    string[] a = timDuoc3[i].Split(' ');

                    dgvKetQua.Rows.Add(FrmHieu.giaiTriDoi(a[0]), Cls_Hieu.giaiGiDo(a[1]), a[2]);

                }
                if (s13.Length == 0) MessageBox.Show("Không tìm thấy kết quả !", "Thông Báo");

                return;
            }    
            // dò theo tên file
            if (cmbKetQua.SelectedIndex != -1 && cmbDoHT.SelectedIndex == 0 && cmbDai.SelectedIndex !=0)
            {

                String duongDan = Cls_Hieu.giaiMaDuongDan(cmbKetQua.Text); 
                Hashtable doso = new Hashtable();
                FrmHieu.doDai(duongDan, doso); // thêm giá trị
                String s4 = Cls_Hieu.ketQuaTimKiem(txtTimKiem.Text, doso);
                String[] timDuoc4 = s4.Split('@');
                for (int i = 0; i < timDuoc4.Length - 1; i++)
                {
                    string[] a = timDuoc4[i].Split(' ');
                    dgvKetQua.Rows.Add(cmbKetQua.Text, Cls_Hieu.giaiGiDo(a[0]), a[1]);

                }
                if (s4.Length == 0) MessageBox.Show("Không tìm thấy kết quả !", "Thông Báo");
            }

        }

        // xóa
        private void btnDoLai_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = "";
            cmbDoHT.SelectedIndex = 0;
            cmbDai.SelectedIndex = 0;
            cmbKetQua.Items.Clear();
            cmbKetQua.Items.AddRange(Cls_Hieu.giaiMaTen());
            dgvKetQua.Rows.Clear();

        }

  
        // sự kiện cho text
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTimKiem.Text, "[^0-9]"))
            {
                MessageBox.Show("Vui Lòng Chỉ Nhập Số.");
                txtTimKiem.Text = txtTimKiem.Text.Remove(txtTimKiem.Text.Length - 1);
                // con trỏ  phía sau
                txtTimKiem.Focus();
                txtTimKiem.SelectionStart = txtTimKiem.Text.Length;
            }
        }

        // dò lưu
        private void btnDoKetQuaLuu_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length < 2 || txtTimKiem.Text.Length > 6)
            {
                MessageBox.Show("Nhập Kết quả phải lớn hơn 2  và nhỏ hớn 6 !!", "Thông báo");
                return;
            }
            dgvKetQua.Rows.Clear();

            // dò tất cả
            String s3 = Cls_Hieu.ketQuaTimKiemTatCa(txtTimKiem.Text);
            String[] timDuoc3 = s3.Split('@');

            for (int i = 0; i < timDuoc3.Length - 1; i++)
            {
                string[] a = timDuoc3[i].Split(' ');
                dgvKetQua.Rows.Add(FrmHieu.giaiTriDoi(a[0]), Cls_Hieu.giaiGiDo(a[1]), a[2]);
            }
            if (s3.Length == 0) MessageBox.Show("Không tìm thấy kết quả !", "Thông Báo");

        }

        private void dtpngayDo_ValueChanged(object sender, EventArgs e)
        {

                
            
        }

        private void cmbDai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Dò kết quả xổ vừa xổ, nên để \"Không chọn\"\nNếu đang dò theo ngày dò và đài dò !!","Lưu Ý khi dò");
        }
    }
}
