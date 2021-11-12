using System;
using System.Collections;
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
            rad2So2.CheckedChanged += new EventHandler(radXuLy2);
            rad3So2.CheckedChanged += new EventHandler(radXuLy2);
            radsoDayDu2.CheckedChanged += new EventHandler(radXuLy2);
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
           // cmbDaiQuay.Items.AddRange(new String[] { "Quảng Nam", "Hà Nội", "Sài Gòn", "Huế", "Đà Nẵng" });
            //cmbGio.Items.AddRange(new String[] { "00","1","2","3","4","5","6","7","8","9","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24"});

            //cmbPhut.Items.AddRange(new String[] { "00","01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24","25","26","27","28","29","30","31","32","33","34","35","36","37","38","39","40","41","42","43","44","45","46","47","48","49","50","51","52","53","54","55","56","57","58","59" });
            String[] gioPhut = DateTime.Now.ToString("HH:mm:ss").Split(':');
            cmbGio.SelectedItem =  gioPhut[0];
            cmbPhut.SelectedItem = gioPhut[1];
            cmbGiay.SelectedItem = gioPhut[2];
            cmbGia.SelectedIndex = 0;
            cmbGio.Click += new EventHandler(cmbXuLy);
            cmbPhut.Click += new EventHandler(cmbXuLy);
            cmbGiay.Click += new EventHandler(cmbXuLy);
            cmbDaiQuay.SelectedIndex = 0;
            
            lbTinhKhac.Text = "KẾT QUẢ XỔ SỐ " + cmbDaiQuay.SelectedItem.ToString().ToUpper();
            tmrGio.Start();

        }
        
        private void cmbXuLy(object sender, EventArgs e)
        {
            ComboBox b = (ComboBox)sender;

            Cls_Hieu.henGio = cmbGio.Text +":"+ cmbPhut.Text +":"+ cmbGiay.Text;
            tmrThoiGian.Stop();


        }
        private void radXuLy(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;
          
        
            
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
        private void radXuLy2(object sender, EventArgs e)
        {
            RadioButton b = (RadioButton)sender;


            if (b.Checked && Cls_Hieu.luuGiaTri2.Count < 7)
            {

                MessageBox.Show("Chưa có dữ liệu !!", " Thông Báo");
                b.Checked = false;
                return;

            }
            else if (radsoDayDu2.Checked)
            {
                giaTriDayDu2();
            }
            else if (rad2So2.Checked)
            {
                giaTri2So2();
            }
            else if (rad3So2.Checked)
            {
                giaTri3So2();
            }


        }


        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            /*
            if (System.Text.RegularExpressions.Regex.IsMatch(txtTimKiem.Text, "[^0-9]"))
            {
                MessageBox.Show("Vui Lòng Chỉ Nhập Số.");
                txtTimKiem.Text = txtTimKiem.Text.Remove(txtTimKiem.Text.Length - 1);
                // con trỏ  phía sau
                txtTimKiem.Focus();
                txtTimKiem.SelectionStart = txtTimKiem.Text.Length;
            }
            */

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
        protected void xoa2()
        {
            // giải db có 2 giải
            lbGiaiDBK.Text = "000000";

            // giải 1 có 2 giải
            lbGiai1K.Text = "00000";

            // giải 2 có 2 giải
            lbGiai2K.Text = "00000";

            // giải 3 có 2 giải
            lbGiai31K.Text = "00000";
            lbGiai32K.Text = "00000";

            // giải 4 có 7 giải
            lbGiai41K.Text = "00000";
            lbGiai42K.Text = "00000";
            lbGiai43K.Text = "00000";
            lbGiai44K.Text = "00000";
            lbGiai45K.Text = "00000";
            lbGiai46K.Text = "00000";
            lbGiai47K.Text = "00000";

            // giải 5
            lbGiai5K.Text = "0000";

            // giải 6 3 giải
            lbGiai61K.Text = "0000";
            lbGiai62K.Text = "0000";
            lbGiai63K.Text = "0000";

            // giải 7
            lbGiai7K.Text = "000";

            //giải 8 
            lbGiai8K.Text = "00";
        }

        private void tlpKetQua_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnbatDau_Click(object sender, EventArgs e)
        {
            Cls_Hieu.luuGiaTri.Clear();
            Cls_Hieu.luuGiaTri2.Clear();
            if(Cls_Hieu.ktQuay == false)
            {
                MessageBox.Show("Hệ Thống đang quay số", "Thông Báo");
                return;
            }
            xoa();
            xoa2();
            cmbKQXS.Items.Clear();
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
            tlpKetQua.Visible = true;
        
            Cls_Hieu.kt = Cls_Hieu.kt ? false : true;
           
            
            Cls_Hieu.soNgauNhien = nudNgauNhien.Value * 10;
            Cls_Hieu.soNgauNhien2 = nudNgauNhien.Value * 10;
            lbTinhKhac.Text = "KẾT QUẢ XỔ SỐ " + cmbDaiQuay.Text.ToUpper();
            thongTinVe.Text = "KẾT QUẢ XỔ SỐ ĐÀ NẴNG";

            if (chkDaNang.Checked && !chkTinhKhac.Checked) 
                {
                    tmrQuay.Start();
                    Cls_Hieu.ktQuay = false;
                  
                }
                else if(!chkDaNang.Checked && chkTinhKhac.Checked)
                {
                    tmrQuay2.Start();
                    Cls_Hieu.ktQuay = false;
                    
                }
                else if(chkDaNang.Checked && chkTinhKhac.Checked)
                {
                    tmrQuay.Start();
                    tmrQuay2.Start();
                    Cls_Hieu.ktQuay = false;
                   
                }
                else
                {
                    MessageBox.Show("Chưa chọn Đài Xổ Số","Thông Báo");
                }    
                
                
            
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("BẠN CÓ MUỐN LÀM MỚI MÀN HÌNH","ThÔNG BÁO",MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
               MessageBox.Show("LÀM MỚI THÀNH CÔNG");   
            }
            if (res == DialogResult.Cancel)
            {
                return;
            }
            cmbKQXS.Items.Clear();
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
            Cls_Hieu.ktQuay = true;
            Cls_Hieu.tmrNgauNhien = 1;
            Cls_Hieu.tmrNgauNhien1 = 2;
            tmrQuay.Stop();
            tmrQuay2.Stop();
            thongTinVe.Text = "KẾT QUẢ XỔ SỐ ĐÀ NẴNG";
            cmbDaiQuay.SelectedIndex = 0;
            lbTinhKhac.Text = "KẾT QUẢ XỔ SỐ " + cmbDaiQuay.Text.ToUpper();
            Cls_Hieu.luuGiaTri2.Clear();
            Cls_Hieu.luuGiaTri.Clear();
            Cls_Hieu.hienThiKetQua();
            tmrThoiGian.Stop();
       
            xoa();
            xoa2();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)      
        {

            FrmDoSo hieu = new FrmDoSo(Cls_Hieu.luuGiaTri, Cls_Hieu.luuGiaTri2, Cls_Hieu.giaiMaTen(), cmbDaiQuay.Text, dtpNgayGio.Text);
            if (Cls_Hieu.luuGiaTri2.Count <=0 && Cls_Hieu.luuGiaTri.Count <= 0 ||Cls_Hieu.ktQuay == false)
            {
                DialogResult res = MessageBox.Show("Chưa có kết quả hiện tại!\n Bạn có muốn tìm kiếm tất cả kết quả đã lưu ?", "ThÔNG BÁO", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    
                    hieu.Show();
                    return;
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
            
            hieu.Show();

        }
        
        // hàm random đài 1
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
                lbGiai31.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai32.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }     
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 6 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 7)
            {
                lbGiai2.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 7 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 8)
            {
                lbGiai1.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 8 && Cls_Hieu.tmrNgauNhien <= Cls_Hieu.soNgauNhien * 9)
            {
                lbGiaiDB.Text = ngauNhien.Next(0, 999999).ToString("D6");
            }
            Cls_Hieu.tmrNgauNhien += 1;
            if (Cls_Hieu.tmrNgauNhien > Cls_Hieu.soNgauNhien * 9)
            {
                Cls_Hieu.ktQuay = true;
                Cls_Hieu.kt = false;
                Cls_Hieu.tmrNgauNhien = 0;
                cmbKQXS.Enabled = true;
                tmrQuay.Stop();
                luuKQ();
            }       
        }
        // lưu vào hashtable 1
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
        //lưu vào hashtable 2
        private void luuKQ2()
        {
            Cls_Hieu.luuGiaTri2.Clear();
            Cls_Hieu.luuGiaTri2.Add("Giai8", lbGiai8K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai7", lbGiai7K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai6", lbGiai61K.Text + "-" + lbGiai62K.Text + "-" + lbGiai63K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai5", lbGiai5K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai4", lbGiai41K.Text + "-" + lbGiai42K.Text + "-" + lbGiai43K.Text + "-" +
                lbGiai44K.Text + "-" + lbGiai45K.Text + "-" + lbGiai46K.Text + "-" + lbGiai47K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai3", lbGiai31K.Text + "-" + lbGiai32K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai2", lbGiai2K.Text);
            Cls_Hieu.luuGiaTri2.Add("Giai1", lbGiai1K.Text);
            Cls_Hieu.luuGiaTri2.Add("GiaiDB", lbGiaiDBK.Text);
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

        private void giaTri2So2()
        {

            lbGiaiDBK.Text = Cls_Hieu.luuGiaTri2["GiaiDB"].ToString().Substring(Cls_Hieu.luuGiaTri2["GiaiDB"].ToString().Length - 2);
            // giải 1 có 2 giải
            lbGiai1K.Text = Cls_Hieu.luuGiaTri2["Giai1"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai1"].ToString().Length - 2);

            // giải 2 có 2 giải
            lbGiai2K.Text = Cls_Hieu.luuGiaTri2["Giai2"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai2"].ToString().Length - 2);

            String[] s = Cls_Hieu.luuGiaTri2["Giai3"].ToString().Split('-');

            // giải 3 có 2 giải
            lbGiai31K.Text = s[0].Substring(s[0].Length - 2);
            lbGiai32K.Text = s[1].Substring(s[1].Length - 2);
            s = Cls_Hieu.luuGiaTri2["Giai4"].ToString().Split('-');
            // giải 4 có 7 giải

            lbGiai41K.Text = s[0].Substring(s[0].Length - 2);
            lbGiai42K.Text = s[1].Substring(s[1].Length - 2);
            lbGiai43K.Text = s[2].Substring(s[2].Length - 2);
            lbGiai44K.Text = s[3].Substring(s[3].Length - 2);
            lbGiai45K.Text = s[4].Substring(s[4].Length - 2);
            lbGiai46K.Text = s[5].Substring(s[5].Length - 2);
            lbGiai47K.Text = s[6].Substring(s[6].Length - 2);

            // giải 5
            lbGiai5K.Text = Cls_Hieu.luuGiaTri2["Giai5"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai5"].ToString().Length - 2);

            s = Cls_Hieu.luuGiaTri2["Giai6"].ToString().Split('-');
            // giải 6 3 giải
            lbGiai61K.Text = s[0].Substring(s[0].Length - 2);
            lbGiai62K.Text = s[1].Substring(s[1].Length - 2);
            lbGiai63K.Text = s[2].Substring(s[2].Length - 2);

            // giải 7
            lbGiai7K.Text = Cls_Hieu.luuGiaTri2["Giai7"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai7"].ToString().Length - 2);

            //giải 8 
            lbGiai8K.Text = Cls_Hieu.luuGiaTri2["Giai8"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai8"].ToString().Length - 2);
        }
        private void giaTri3So2()
        {

            lbGiaiDBK.Text = Cls_Hieu.luuGiaTri2["GiaiDB"].ToString().Substring(Cls_Hieu.luuGiaTri2["GiaiDB"].ToString().Length - 3);
            // giải 1 có 2 giải
            lbGiai1K.Text = Cls_Hieu.luuGiaTri2["Giai1"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai1"].ToString().Length - 3);

            // giải 2 có 2 giải
            lbGiai2K.Text = Cls_Hieu.luuGiaTri2["Giai2"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai2"].ToString().Length - 3);

            String[] s = Cls_Hieu.luuGiaTri2["Giai3"].ToString().Split('-');

            // giải 3 có 2 giải
            lbGiai31K.Text = s[0].Substring(s[0].Length - 3);
            lbGiai32K.Text = s[1].Substring(s[1].Length - 3);
            s = Cls_Hieu.luuGiaTri2["Giai4"].ToString().Split('-');
            // giải 4 có 7 giải

            lbGiai41K.Text = s[0].Substring(s[0].Length - 3);
            lbGiai42K.Text = s[1].Substring(s[1].Length - 3);
            lbGiai43K.Text = s[2].Substring(s[2].Length - 3);
            lbGiai44K.Text = s[3].Substring(s[3].Length - 3);
            lbGiai45K.Text = s[4].Substring(s[4].Length - 3);
            lbGiai46K.Text = s[5].Substring(s[5].Length - 3);
            lbGiai47K.Text = s[6].Substring(s[6].Length - 3);

            // giải 5
            lbGiai5K.Text = Cls_Hieu.luuGiaTri2["Giai5"].ToString().Substring(Cls_Hieu.luuGiaTri2["Giai5"].ToString().Length - 3);

            s = Cls_Hieu.luuGiaTri2["Giai6"].ToString().Split('-');
            // giải 6 3 giải
            lbGiai61K.Text = s[0].Substring(s[0].Length - 3);
            lbGiai62K.Text = s[1].Substring(s[1].Length - 3);
            lbGiai63K.Text = s[2].Substring(s[2].Length - 3);

            // giải 7
            lbGiai7K.Text = Cls_Hieu.luuGiaTri2["Giai7"].ToString();

            //giải 8 
            lbGiai8K.Text = Cls_Hieu.luuGiaTri2["Giai8"].ToString();
        }
        private void giaTriDayDu2()
        {

            lbGiaiDBK.Text = Cls_Hieu.luuGiaTri2["GiaiDB"].ToString();
            // giải 1 có 2 giải
            lbGiai1K.Text = Cls_Hieu.luuGiaTri2["Giai1"].ToString();

            // giải 2 có 2 giải
            lbGiai2K.Text = Cls_Hieu.luuGiaTri2["Giai2"].ToString();

            String[] s = Cls_Hieu.luuGiaTri2["Giai3"].ToString().Split('-');

            // giải 3 có 2 giải
            lbGiai31K.Text = s[0];
            lbGiai32K.Text = s[1];
            s = Cls_Hieu.luuGiaTri2["Giai4"].ToString().Split('-');
            // giải 4 có 7 giải
            lbGiai41K.Text = s[0];
            lbGiai42K.Text = s[1];
            lbGiai43K.Text = s[2];
            lbGiai44K.Text = s[3];
            lbGiai45K.Text = s[4];
            lbGiai46K.Text = s[5];
            lbGiai47K.Text = s[6];

            // giải 5
            lbGiai5K.Text = Cls_Hieu.luuGiaTri2["Giai5"].ToString();

            s = Cls_Hieu.luuGiaTri2["Giai6"].ToString().Split('-');
            // giải 6 3 giải
            lbGiai61K.Text = s[0];
            lbGiai62K.Text = s[1];
            lbGiai63K.Text = s[2];

            // giải 7
            lbGiai7K.Text = Cls_Hieu.luuGiaTri2["Giai7"].ToString();

            //giải 8 
            lbGiai8K.Text = Cls_Hieu.luuGiaTri2["Giai8"].ToString();
        }




        private void btnLuuXoSo_Click(object sender, EventArgs e)
        {
            Cls_Hieu.now = DateTime.Now;
            
            if(Cls_Hieu.ktQuay == false)
            {
                MessageBox.Show("đang quay số không thể lưu !!", "Thông Báo");
                return;
            }
            if (Cls_Hieu.kt == true || cmbKQXS.SelectedIndex != -1)
            {
                
                if (Cls_Hieu.luuGiaTri.Count != 0 || Cls_Hieu.luuGiaTri2.Count == 0 && (Cls_Hieu.luuGiaTri.Count == 0 || Cls_Hieu.luuGiaTri2.Count != 0))
                {
                    MessageBox.Show("Không thể lưu !!", "Thông Báo");
                    return;
                }    
                MessageBox.Show("Bạn đã lưu kết quả xổ số này !!","Thông Báo");   
                return;
            }
            if (chkDaNang.Checked && !chkTinhKhac.Checked)
            {
                
                DialogResult res = MessageBox.Show("BẠN CÓ MUỐN LƯU KẾT QUẢ \nXổ Số Đà Nẵng ngày " + dtpNgayGio.Text, "ThÔNG BÁO", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Cls_Hieu.LuuThuMuc(dtpNgayGio.Text, "ĐÀ NẴNG", cmbGia.Text);
                    MessageBox.Show("LƯU THÀNH CÔNG");
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
            }
            else if (!chkDaNang.Checked && chkTinhKhac.Checked)
            {
                DialogResult res = MessageBox.Show("BẠN CÓ MUỐN LƯU KẾT QUẢ \nXổ Số "+cmbDaiQuay.Text+" ngày "+ dtpNgayGio.Text+"\n"+"Giá vé "+cmbGia.Text,"ThÔNG BÁO", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Cls_Hieu.LuuThuMuc2(cmbDaiQuay.SelectedItem.ToString().ToUpper(), dtpNgayGio.Text, cmbDaiQuay.Text, cmbGia.Text);
                    MessageBox.Show("LƯU THÀNH CÔNG");
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
                
                
            }
            else if (chkDaNang.Checked && chkTinhKhac.Checked)
            {
                DialogResult res = MessageBox.Show("BẠN CÓ MUỐN LƯU KẾT QUẢ \nXổ Số " + cmbDaiQuay.Text + " ngày " + dtpNgayGio.Text + "\nXổ Số Đà Nẵng ngày "+ dtpNgayGio.Text, "ThÔNG BÁO", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Cls_Hieu.LuuThuMuc(dtpNgayGio.Text, "ĐÀ NẴNG", cmbGia.Text);
                    Cls_Hieu.LuuThuMuc2(cmbDaiQuay.SelectedItem.ToString().ToUpper(), dtpNgayGio.Text, cmbDaiQuay.Text, cmbGia.Text);
                    MessageBox.Show("LƯU THÀNH CÔNG");
                }
                if (res == DialogResult.Cancel)
                {
                    return;
                }
               
            }
            else
            {
                MessageBox.Show("Chưa chọn Đài Lưu", "Thông Báo");
                return;
            }
            
            cmbKQXS.Items.Clear();
            cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
            Cls_Hieu.kt = true;
        }
        private void hienThiXoSo(String thuMuc)
        {
            Cls_Hieu.luuGiaTri.Clear();
            String[] duLieu = Cls_Hieu.docThuMuc(thuMuc);
            
            for (int i = 0; i < duLieu.Length; i++)
            {
                string[] s= duLieu[i].Split(':');
                if (s.Length <= 1) continue;
                Cls_Hieu.luuGiaTri.Add(s[0], s[1]);
            }
            
;       }

        public static void doDai(String thuMuc,Hashtable doDai)
        {
            
            String[] duLieu = Cls_Hieu.docThuMuc(thuMuc);

            for (int i = 0; i < duLieu.Length; i++)
            {
                string[] s = duLieu[i].Split(':');
                if (s.Length <= 1) continue;
                doDai.Add(s[0], s[1]);
            }
        }
        private void hienThiXoSo2(String thuMuc)
        {
           
            Cls_Hieu.luuGiaTri2.Clear();
            String[] duLieu = Cls_Hieu.docThuMuc(thuMuc);
            string[] ss = duLieu[1].Split(':');
            string[] dai = duLieu[0].Split(':');
            cmbGia.SelectedItem = ss[1];
            cmbDaiQuay.SelectedItem = dai[1];
            for (int i = 0; i < duLieu.Length; i++)
            {
                string[] s = duLieu[i].Split(':');
                if (s.Length <= 1) continue;
                Cls_Hieu.luuGiaTri2.Add(s[0], s[1]);
            }

;
        }


        // đổi ra tên đài
        public static String doiChu(String ten)
        {
            String[] ten1 = ten.Split(' ');
            
            Hashtable doiten = new Hashtable();
            doiten.Add("DN","ĐÀ NẴNG");    
            doiten.Add("HN", "HÀ NỘI");
            doiten.Add("QN", "QUẢNG NAM");
            doiten.Add("SG", "SÀI GÒN");
            doiten.Add("HU", "HUẾ");  
            doiten.Add("HP", "HẢI PHÒNG");
            doiten.Add("GL", "GIA LAI");
            doiten.Add("HB", "HÒA BÌNH");
            doiten.Add("HAG", "HÀ GIANG");
            doiten.Add("HT", "HÀ TĨNH");
            doiten.Add("HY", "HƯNG YÊN");
            doiten.Add("HD", "HẢI DƯƠNG");
            doiten.Add("HG", "HẬU GIANG");
            doiten.Add("DB", "ĐIỆN BIÊN");
            doiten.Add("DL", "ĐẮK LẮK");
            doiten.Add("DNN", "ĐẮK NÔNG");
            doiten.Add("DNA", "ĐỒNG NAI");
            doiten.Add("DT", "ĐỒNG THÁP");
            doiten.Add("KH", "KHÁNH HÒA");
            doiten.Add("KG", "KIÊN GIANG");
            doiten.Add("KT", "KON TUM");
            doiten.Add("LA", "LONG AN");
            doiten.Add("LC", "LÀO CAI");
            doiten.Add("LD", "LÂM ĐỒNG");
            doiten.Add("LS", "LẠNG SƠN");
            doiten.Add("ND", "NAM ĐỊNH");
            doiten.Add("NA", "NGHỆ AN");
            doiten.Add("NB", "NINH BÌNH");
            doiten.Add("NT", "NINH THUẬN");
            doiten.Add("PT", "PHÚ THỌ");
            doiten.Add("PY", "PHÚ YÊN");
            doiten.Add("QB", "QUẢNG BÌNH");
            doiten.Add("QNA", "QUẢNG NGÃI");
            doiten.Add("QNN", "QUẢNG NINH");
            doiten.Add("QT", "QUẢNG TRỊ");
            doiten.Add("ST", "SÓC TRĂNG");
            doiten.Add("SL", "SƠN LA");
            doiten.Add("TH", "THANH HÓA");
            doiten.Add("TB", "THÁI BÌNH");
            doiten.Add("TN", "THÁI NGUYÊN");
            doiten.Add("TG", "TIỀN GIANG");
            doiten.Add("TV", "TRÀ VINH");
            doiten.Add("TQ", "TUYÊN QUANG");
            doiten.Add("TNI", "TÂY NINH");
            doiten.Add("VL", "VĨNH LONG");
            doiten.Add("VP", "VĨNH PHÚC");
            doiten.Add("YB", "YÊN BÁI");
            doiten.Add("AG", "AN GIANG");
            doiten.Add("VT", "VŨNG TÀU");
            doiten.Add("BL", "BẠC LIÊU");
            doiten.Add("BG", "BẮC GIANG");
            doiten.Add("BK", "BẮC KẠN");
            doiten.Add("BN", "BẮC NINH");
            doiten.Add("BTR", "BẾN TRE");
            doiten.Add("BDD", "BÌNH DƯƠNG");
            doiten.Add("BD", "BÌNH ĐỊNH");
            doiten.Add("BP", "BÌNH PHƯỚC");
            doiten.Add("BT", "BÌNH THUẬN");
            doiten.Add("CB", "CAO BẰNG");
            doiten.Add("CM", "CÀ MAU");
            doiten.Add("CT", "CẦN THƠ");
            if (doiten[ten1[0]] == null) return "Lỗi";

            return doiten[ten1[0]].ToString()+" "+ten1[1]+" "+ten1[2];
        }


        // hàm đổi chữ hiển thị
        public static String giaiTriDoi(String duongDan)
        {
           
            string[] s = duongDan.Split('\\');
            string s2="";
            string s1="";
            try
            {
                 s2 = s[s.Length - 1].Substring(15).Replace("_", ":").Replace(".txt", "");
                 s1 = s[s.Length - 1].Replace("+", " - ").Remove(16);
            }
            catch
            {
                MessageBox.Show("Lỗi","Thông Báo");
            }
            s1 = doiChu(s1);
            s1 = s1.Replace("_", "/");
            return s1 +" LÚC "+ s2;
        }
       
        private void cmbKQXS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (Cls_Hieu.ktQuay == false)
            {
                MessageBox.Show("Không thể thực hiện thao tác", "Thông Báo");
                cmbKQXS.Items.Clear();
                cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
                return;
            }
            
            ComboBox thuMuc = (ComboBox)sender;
            String duongDan = Cls_Hieu.giaiMaDuongDan(thuMuc.Text);
        
           
            
            String[] s1 = giaiTriDoi(duongDan).Replace(" LÚC ","@").Split('@');
            
          if(!s1[0].Contains("ĐÀ NẴNG"))
            {
                
                hienThiXoSo2(duongDan);
                
                lbTinhKhac.Text = "KẾT QUẢ XỔ SỐ "+s1[0]+" LÚC "+s1[1];
            if (radsoDayDu2.Checked)
            {

                giaTriDayDu2();
            }
            else if (rad2So2.Checked)
            {
                giaTri2So2();
            }
            else if (rad3So2.Checked)
            {
                giaTri3So2();
            }
            else
            {
                if (Cls_Hieu.luuGiaTri2["GiaiDB"] == null) return;
                giaTriDayDu2();
            }
            }
            else
            {


                hienThiXoSo(duongDan);
                thongTinVe.Text = "KẾT QUẢ XỔ SỐ " + s1[0] + " LÚC " + s1[1];
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
                if (Cls_Hieu.luuGiaTri["GiaiDB"] == null) return;
                giaTriDayDu();
            }
                
            }

        }
        //xóa file thư mục
        
        private void button1_Click(object sender, EventArgs e)
        {

            if (cmbKQXS.SelectedItem == null)
            {
                MessageBox.Show("Bạn chưa chọn kết quả xóa", "Thông báo");
                return;
            }
          
            
            String duongDan = Cls_Hieu.giaiMaDuongDan(cmbKQXS.SelectedItem.ToString());
           
            String[] s = giaiTriDoi(duongDan).Replace(" LÚC ", "@").Split('@');
            DialogResult res = MessageBox.Show("BẠN CÓ MUỐN XÓA KẾT QUẢ XỔ SỐ :   \n" + s[0]+" Lúc "+s[1], "ThÔNG BÁO", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                
                try { 
                File.Delete(Path.GetFullPath(duongDan));
                cmbKQXS.Items.Clear();
                cmbKQXS.Items.AddRange(Cls_Hieu.giaiMaTen());
                cmbDaiQuay.SelectedIndex = 0;
                lbTinhKhac.Text = "KẾT QUẢ XỐ XỐ " + cmbDaiQuay.SelectedItem.ToString().ToUpper();
                thongTinVe.Text = "KẾT QUẢ XỔ SỔ ĐÀ NẴNG";
                MessageBox.Show("Xóa thành công");
                    if (duongDan.Contains("DN"))
                    {
                        xoa();
                        Cls_Hieu.luuGiaTri.Clear();
                    }
                    else
                    {
                        xoa2();
                        Cls_Hieu.luuGiaTri2.Clear();
                    }
                
                
                    
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
        
        private void tmrQuay2_Tick(object sender, EventArgs e)
        {
            var ngauNhien = new Random();
            if (Cls_Hieu.tmrNgauNhien1 >= 0 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2)
            {
                int so = ngauNhien.Next(00, 99);
                lbGiai8K.Text = so < 10 ? "0" + so.ToString() : so.ToString();
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 2)
            {
                lbGiai7K.Text = ngauNhien.Next(0, 999).ToString("D3");
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 2 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 3)
            {
                lbGiai61K.Text = ngauNhien.Next(0, 9999).ToString("D4");
                lbGiai62K.Text = ngauNhien.Next(0, 9999).ToString("D4");
                lbGiai63K.Text = ngauNhien.Next(0, 9999).ToString("D4");
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 3 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 4)
            {
                lbGiai5K.Text = ngauNhien.Next(0, 9999).ToString("D4");
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 4 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 5)
            {
                lbGiai41K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai42K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai43K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai44K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai45K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai46K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai47K.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 5 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 6)
            {
                lbGiai31K.Text = ngauNhien.Next(0, 99999).ToString("D5");
                lbGiai32K.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
           
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 6 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 7)
            {
                lbGiai2K.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 7 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 8)
            {
                lbGiai1K.Text = ngauNhien.Next(0, 99999).ToString("D5");
            }
            else if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 8 && Cls_Hieu.tmrNgauNhien1 <= Cls_Hieu.soNgauNhien2 * 9)
            {
                lbGiaiDBK.Text = ngauNhien.Next(0, 999999).ToString("D6");
            }
            Cls_Hieu.tmrNgauNhien1 += 1;
            if (Cls_Hieu.tmrNgauNhien1 > Cls_Hieu.soNgauNhien2 * 9)
            {
                Cls_Hieu.kt = false;
                Cls_Hieu.ktQuay = true;
                Cls_Hieu.tmrNgauNhien1 = 2;
                tmrQuay2.Stop();
                luuKQ2();
            }
        }

        public int giay = 0; 
        private void tmrThoiGian_Tick(object sender, EventArgs e)
        {
            
            String[] gioPhut = lbGio.Text.Split(':');
            if(chkDaNang.Checked) thongTinVe.Text = "ĐANG HẸN GIỜ";
            if(chkTinhKhac.Checked) lbTinhKhac.Text = "ĐANG HẸN GIỜ";

            if (gioPhut[0] == cmbGio.Text && cmbPhut.Text == gioPhut[1] && cmbGiay.Text == gioPhut[2])
            {
                tmrThoiGian.Stop();
                btnbatDau.PerformClick();
                thongTinVe.Text = "KẾT QUẢ XỔ SỐ ĐÀ NẴNG";
                lbTinhKhac.Text = "KẾT QUẢ XỔ SỐ "+cmbDaiQuay.Text.ToUpper();
            }

          
        }

     

        private void nudNgauNhien_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbDaiQuay_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox b = (ComboBox)sender;

            lbTinhKhac.Text = "KẾT QUẢ XỔ SỐ " + b.Text.ToUpper();
        }

        private void btnHenGio_Click(object sender, EventArgs e)
        {
            if(Cls_Hieu.ktQuay == false)
            {
                MessageBox.Show("Đang quay không thể hẹn giờ !", "Thông báo");
                return;
            }
            String[] gioPhut = lbGio.Text.Split(':');
            if(!chkDaNang.Checked && !chkTinhKhac.Checked)
            {
                MessageBox.Show("Chưa chọn Đài Xổ","Thông báo");
                return;
            }
            if(Int32.Parse(gioPhut[0]) <= Int32.Parse(cmbGio.Text))
            {
                if(Int32.Parse(gioPhut[1]) <= Int32.Parse(cmbPhut.Text) || Int32.Parse(cmbGio.Text) - Int32.Parse(gioPhut[0]) > 0)
                {
                    if(Int32.Parse(gioPhut[2]) <= Int32.Parse(cmbGiay.Text) || Int32.Parse(gioPhut[1]) < Int32.Parse(cmbPhut.Text)|| Int32.Parse(cmbGio.Text) - Int32.Parse(gioPhut[0]) > 0)
                    {     
                        tmrThoiGian.Start();
                        Cls_Hieu.luuGiaTri.Clear();
                        Cls_Hieu.luuGiaTri2.Clear();
                        xoa();
                        xoa2();
                        MessageBox.Show("Hẹn Giờ Thành Công", "Thông Báo");
                    }
                    else
                    {
                        MessageBox.Show("Không thể hẹn số giây nhỏ hơn hiện tại", "Thông Báo");
                        return;
                    }  
                }
                else
                {
                    MessageBox.Show("Không thể hẹn số phút nhỏ hơn hiện tại", "Thông Báo");
                    return;
                }
                
            }
            else
            {
                MessageBox.Show("Không thể hẹn số giờ nhỏ hơn hiện tại","Thông Báo");
                return;
            }
            
            

        }

        private void tmrGio_Tick(object sender, EventArgs e)
        {
            lbGio.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
