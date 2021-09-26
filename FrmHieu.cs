using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSo_TrinhPhucHieu
{
    public partial class FrmHieu : Form
    {
        
        public FrmHieu()
        {
            InitializeComponent();
            rad2So.CheckedChanged += new EventHandler(radXuLy);
            rad3So.CheckedChanged += new EventHandler(radXuLy);
            radsoDayDu.CheckedChanged += new EventHandler(radXuLy);
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
        }

        private void radXuLy(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;
            tlpKetQua.Visible = true;
            tlpTimKiem.Visible = false;
            if(b.Checked && Cls_Hieu.luuGiaTri.Count<7)
            {
                    
                MessageBox.Show("Chưa có dữ liệu !!", " Thông Báo");
                b.Checked = false;
                return;

            }else if(radsoDayDu.Checked)
            {
                giaTriDayDu();
            }else if (rad2So.Checked) 
            {
                giaTri2So();
            }else if (rad3So.Checked)
            {
                giaTri3So();
            }
            

        }

      
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
       
        protected void xoa()
        {
            // giải db có 2 giải
            lbGiaiDB.Text = "000000";

            // giải 1 có 2 giải
            lbGiai1.Text = "00000";

            // giải 2 có 2 giải
            lbGiai2.Text = "00000";

            // giải 3 có 2 giải
            lbGiai31.Text = "00000";
            lbGiai32.Text = "00000";

            // giải 4 có 7 giải
            lbGiai41.Text = "00000";
            lbGiai42.Text = "00000";
            lbGiai43.Text = "00000";
            lbGiai44.Text = "00000";
            lbGiai45.Text = "00000";
            lbGiai46.Text = "00000";
            lbGiai47.Text = "00000";

            // giải 5
            lbGiai5.Text = "0000";

            // giải 6 3 giải
            lbGiai61.Text = "0000";
            lbGiai62.Text = "0000";
            lbGiai63.Text = "0000";

            // giải 7
            lbGiai7.Text = "000";

            //giải 8 
            lbGiai8.Text = "00";
        }
      
        private void tlpKetQua_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnbatDau_Click(object sender, EventArgs e)
        {
            cmbKQXS.Items.Clear();
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
            tlpKetQua.Visible = true;
            tlpTimKiem.Visible = false;
            Cls_Hieu.kt = Cls_Hieu.kt ? false : true;
           
            Cls_Hieu.soNgauNhien = nudNgauNhien.Value;
            Cls_Hieu.soNgauNhien = Cls_Hieu.soNgauNhien * 10;
            if(Cls_Hieu.soNgauNhien == 0)
            {

            }
            else
            {
                tmrQuay.Start();
            }
            
            




        }
        private void btnXoa_Click(object sender, EventArgs e)
        {

            thongTinVe.Text = "KẾT QUẢ XỔ SỐ ĐÀ NẴNG";
            
            Cls_Hieu.luuGiaTri.Clear();
            Cls_Hieu.hienThiKetQua();
            tlpTimKiem.Visible = false;
            tlpKetQua.Visible = true;
            xoa();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Length < 7 || txtTimKiem.Text.Length > 7)
            {
                MessageBox.Show("Giá trị vé số phải đủ 6 chữ số", "Thông Báo");
                return;
            }
            tlpKetQua.Visible = false;
            tlpTimKiem.Visible = true;
            String s = Cls_Hieu.ketQuaTimKiem(txtTimKiem.Text);
            if (!s.Equals("Error"))
            {
                string[] a = s.Split(' ');
                lbKqTimKiem.Text = a[1];
                
                lbGiaiTK.Text = Cls_Hieu.giaiGiDo(a[0]); 
            }
            



        }
        
        private void tmrQuay_Tick(object sender, EventArgs e)
        {
            var ngauNhien = new Random();
            if (Cls_Hieu.tmrNgauNhien >= 0 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien)
            {
                int so = ngauNhien.Next(00, 99);
                lbGiai8.Text = so < 10 ? "0"+so.ToString() : so.ToString();
            }
            else if(Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien*2)
            {
                lbGiai7.Text = ngauNhien.Next(0, 999).ToString("D3");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 2 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 3)
            {
                lbGiai61.Text = ngauNhien.Next(0, 9999).ToString("D4");
                lbGiai62.Text = ngauNhien.Next(0, 9999).ToString("D4");
                lbGiai63.Text = ngauNhien.Next(0, 9999).ToString("D4");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 3 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 4)
            {
                lbGiai5.Text = ngauNhien.Next(0, 9999).ToString("D4");       
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 4 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 5)
            {
                lbGiai41.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai42.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai43.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai44.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai45.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai46.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai47.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
            else if(Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 5 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 6)
            {
                lbGiai31.Text = ngauNhien.Next(0, 999999).ToString("D6");
                lbGiai32.Text = ngauNhien.Next(0, 999999).ToString("D6");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 6 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 7)
            {
                lbGiai31.Text = ngauNhien.Next(0, 999999).ToString("D6");
                lbGiai32.Text = ngauNhien.Next(0, 999999).ToString("D6");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 7 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 8)
            {
                lbGiai2.Text = ngauNhien.Next(0, 999999).ToString("D6");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 8 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 9)
            {
                lbGiai1.Text = ngauNhien.Next(0, 999999).ToString("D6");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 9 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 10)
            {
                lbGiaiDB.Text = ngauNhien.Next(0, 9999999).ToString("D7");
            }
            Cls_Hieu.tmrNgauNhien += 1;
            if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 10)
            {
                Cls_Hieu.tmrNgauNhien = 0;
                tmrQuay.Stop();
                luuKQ();
            }       
        }
        private void luuKQ() 
        {
            Cls_Hieu.luuGiaTri.Clear();
            Cls_Hieu.luuGiaTri.Add("Giai8", lbGiai8.Text);
            Cls_Hieu.luuGiaTri.Add("Giai7", lbGiai7.Text);
            Cls_Hieu.luuGiaTri.Add("Giai6", lbGiai61.Text + "-" + lbGiai62.Text + "-" + lbGiai63.Text);
            Cls_Hieu.luuGiaTri.Add("Giai5", lbGiai5.Text);
            Cls_Hieu.luuGiaTri.Add("Giai4", lbGiai41.Text + "-" + lbGiai42.Text + "-" + lbGiai43.Text + "-" +
                lbGiai44.Text + "-" + lbGiai45.Text + "-" + lbGiai46.Text + "-" + lbGiai47.Text);
            Cls_Hieu.luuGiaTri.Add("Giai3", lbGiai31.Text + "-" + lbGiai32.Text);
            Cls_Hieu.luuGiaTri.Add("Giai2", lbGiai2.Text);
            Cls_Hieu.luuGiaTri.Add("Giai1", lbGiai1.Text);
            Cls_Hieu.luuGiaTri.Add("GiaiDB", lbGiaiDB.Text);
        }

        private void rad2So_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }

        private void giaTri2So()
        {

            lbGiaiDB.Text = Cls_Hieu.luuGiaTri["GiaiDB"].ToString().Substring(Cls_Hieu.luuGiaTri["GiaiDB"].ToString().Length - 2);
            // giải 1 có 2 giải
            lbGiai1.Text = Cls_Hieu.luuGiaTri["Giai1"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai1"].ToString().Length - 2);

            // giải 2 có 2 giải
            lbGiai2.Text = Cls_Hieu.luuGiaTri["Giai2"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai2"].ToString().Length - 2);

            String[] s = Cls_Hieu.luuGiaTri["Giai3"].ToString().Split('-');

            // giải 3 có 2 giải
            lbGiai31.Text = s[0].Substring(s[0].Length - 2);
            lbGiai32.Text = s[1].Substring(s[1].Length - 2);
            s = Cls_Hieu.luuGiaTri["Giai4"].ToString().Split('-');
            // giải 4 có 7 giải
            
            lbGiai41.Text = s[0].Substring(s[0].Length-2);
            lbGiai42.Text = s[1].Substring(s[1].Length - 2);
            lbGiai43.Text = s[2].Substring(s[2].Length - 2);
            lbGiai44.Text = s[3].Substring(s[3].Length - 2);
            lbGiai45.Text = s[4].Substring(s[4].Length - 2);
            lbGiai46.Text = s[5].Substring(s[5].Length - 2);
            lbGiai47.Text = s[6].Substring(s[6].Length - 2);

            // giải 5
            lbGiai5.Text = Cls_Hieu.luuGiaTri["Giai5"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai5"].ToString().Length - 2);

            s = Cls_Hieu.luuGiaTri["Giai6"].ToString().Split('-');
            // giải 6 3 giải
            lbGiai61.Text = s[0].Substring(s[0].Length - 2);
            lbGiai62.Text = s[1].Substring(s[1].Length - 2);
            lbGiai63.Text = s[2].Substring(s[2].Length - 2);

            // giải 7
            lbGiai7.Text = Cls_Hieu.luuGiaTri["Giai7"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai7"].ToString().Length - 2);

            //giải 8 
            lbGiai8.Text = Cls_Hieu.luuGiaTri["Giai8"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai8"].ToString().Length - 2);
        }
        private void giaTri3So()
        {

            lbGiaiDB.Text = Cls_Hieu.luuGiaTri["GiaiDB"].ToString().Substring(Cls_Hieu.luuGiaTri["GiaiDB"].ToString().Length - 3);
            // giải 1 có 2 giải
            lbGiai1.Text = Cls_Hieu.luuGiaTri["Giai1"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai1"].ToString().Length - 3);

            // giải 2 có 2 giải
            lbGiai2.Text = Cls_Hieu.luuGiaTri["Giai2"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai2"].ToString().Length - 3);

            String[] s = Cls_Hieu.luuGiaTri["Giai3"].ToString().Split('-');

            // giải 3 có 2 giải
            lbGiai31.Text = s[0].Substring(s[0].Length - 3);
            lbGiai32.Text = s[1].Substring(s[1].Length - 3);
            s = Cls_Hieu.luuGiaTri["Giai4"].ToString().Split('-');
            // giải 4 có 7 giải

            lbGiai41.Text = s[0].Substring(s[0].Length - 3);
            lbGiai42.Text = s[1].Substring(s[1].Length - 3);
            lbGiai43.Text = s[2].Substring(s[2].Length - 3);
            lbGiai44.Text = s[3].Substring(s[3].Length - 3);
            lbGiai45.Text = s[4].Substring(s[4].Length - 3);
            lbGiai46.Text = s[5].Substring(s[5].Length - 3);
            lbGiai47.Text = s[6].Substring(s[6].Length - 3);

            // giải 5
            lbGiai5.Text = Cls_Hieu.luuGiaTri["Giai5"].ToString().Substring(Cls_Hieu.luuGiaTri["Giai5"].ToString().Length - 3);

            s = Cls_Hieu.luuGiaTri["Giai6"].ToString().Split('-');
            // giải 6 3 giải
            lbGiai61.Text = s[0].Substring(s[0].Length - 3);
            lbGiai62.Text = s[1].Substring(s[1].Length - 3);
            lbGiai63.Text = s[2].Substring(s[2].Length - 3);

            // giải 7
            lbGiai7.Text = Cls_Hieu.luuGiaTri["Giai7"].ToString();

            //giải 8 
            lbGiai8.Text = Cls_Hieu.luuGiaTri["Giai8"].ToString();
        }
        private void giaTriDayDu()
        {

            lbGiaiDB.Text = Cls_Hieu.luuGiaTri["GiaiDB"].ToString();
            // giải 1 có 2 giải
            lbGiai1.Text = Cls_Hieu.luuGiaTri["Giai1"].ToString();

            // giải 2 có 2 giải
            lbGiai2.Text = Cls_Hieu.luuGiaTri["Giai2"].ToString();

            String[] s = Cls_Hieu.luuGiaTri["Giai3"].ToString().Split('-');

            // giải 3 có 2 giải
            lbGiai31.Text = s[0];
            lbGiai32.Text = s[1];
            s = Cls_Hieu.luuGiaTri["Giai4"].ToString().Split('-');
            // giải 4 có 7 giải
            lbGiai41.Text = s[0];
            lbGiai42.Text = s[1];
            lbGiai43.Text = s[2];
            lbGiai44.Text = s[3];
            lbGiai45.Text = s[4];
            lbGiai46.Text = s[5];
            lbGiai47.Text = s[6];

            // giải 5
            lbGiai5.Text = Cls_Hieu.luuGiaTri["Giai5"].ToString();

            s = Cls_Hieu.luuGiaTri["Giai6"].ToString().Split('-');
            // giải 6 3 giải
            lbGiai61.Text = s[0];
            lbGiai62.Text = s[1];
            lbGiai63.Text = s[2];

            // giải 7
            lbGiai7.Text = Cls_Hieu.luuGiaTri["Giai7"].ToString();

            //giải 8 
            lbGiai8.Text = Cls_Hieu.luuGiaTri["Giai8"].ToString();
        }
        private void radsoDayDu_CheckedChanged(object sender, EventArgs e)
        { 
        }

        private void rad3So_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void panel10_Paint(object sender, EventArgs e)
        {
            
        }


        public void setColor()
        {
            if (lbGiai8 != default(Label))
                lbGiai8.BackColor = Color.Yellow;
            else { 
                lbGiai8 = default(Label);
            }
            //Resetting clicked label because another (or the same) was just clicked.
        }

        private void lbGiai8_Click(object sender, EventArgs e)
        {
            setColor();//Calling this here so clickedLabel is still the old value
            Label theLabel = (Label)sender;
            lbGiai8 = theLabel;
        }

        private void btnLuuXoSo_Click(object sender, EventArgs e)
        {
            /*
            if (Cls_Hieu.kt == true)
            {
                
                if (Cls_Hieu.luuGiaTri.Count == 0 )
                {
                    MessageBox.Show("Chưa có kết quả xổ số không thể lưu !!", "Thông Báo");
                    return;
                }    
                MessageBox.Show("Bạn đã lưu kết quả xổ số này !!","Thông Báo");
                
                return;
            }
            */
            Cls_Hieu.LuuThuMuc();
            cmbKQXS.Items.Clear();
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
            Cls_Hieu.kt = true;
        }
        private void hienThiXoSo(String thuMuc)
        {
            Cls_Hieu.luuGiaTri.Clear();
            String[] duLieu = Cls_Hieu.docThuMuc(thuMuc);
            for(int i = 0; i < duLieu.Length; i++)
            {
                string[] s= duLieu[i].Split(':');
                Cls_Hieu.luuGiaTri.Add(s[0], s[1]);
            }
            
;       }

        public static String giaiTriDoi(String duongDan)
        {
            string[] s = duongDan.Split('\\');
           
            string s2 = s[s.Length - 1].Substring(15).Replace("_", ":").Replace(".txt", "");
            string s1 = s[s.Length - 1].Replace("+", " - ").Remove(15);
            s1 = s1.Replace("DN", "ĐÀ NẴNG");
            s1 = s1.Replace("_", "/");
            return s1 +" LÚC "+ s2;
        }
       
        private void cmbKQXS_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox thuMuc = (ComboBox)sender;
            String duongDan = Cls_Hieu.giaiMaDuongDan(thuMuc.Text);
           
            hienThiXoSo(duongDan);
            
            String[] s1 = giaiTriDoi(duongDan).Replace(" LÚC ","@").Split('@');
            thongTinVe.Text = "KẾT QUẢ XỔ SỐ "+s1[0]+" LÚC "+s1[1];
            if (radsoDayDu.Checked)
            {
                giaTriDayDu();
            }
            else if(rad2So.Checked)
            {
                giaTri2So();
            }else if(rad3So.Checked)
            {
                giaTri3So();
            }
            else
            {
                giaTriDayDu();
            }
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String duongDan = Cls_Hieu.giaiMaDuongDan(cmbKQXS.SelectedItem.ToString());
            String[] s = giaiTriDoi(duongDan).Replace(" LÚC ", "@").Split('@');
            DialogResult res = MessageBox.Show("BẠN CÓ MUỐN XÓA KẾT QUẢ XỔ SỐ :   \n" + s[0]+" "+s[1], "ThÔNG BÁO", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                
                try { 
                File.Delete(Path.GetFullPath(duongDan));
                cmbKQXS.Items.Clear();
                cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
                MessageBox.Show("Xóa thành công");
                xoa();
                    Cls_Hieu.luuGiaTri.Clear();
                }
                catch
                {
                    MessageBox.Show("Lỗi Xóa");
                }
            }
            if (res == DialogResult.Cancel)
            {
                
           
            }
        }
    }
}
