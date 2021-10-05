using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


// ------------------------- TRỊNH PHÚC HIẾU 18CT1 --------------------- 
namespace XoSo_TrinhPhucHieu
{
    class Cls_Hieu
    {

        public static Hashtable luuGiaTri = new Hashtable();
        public static Hashtable luuGiaTri2 = new Hashtable();
        public static Hashtable giaiThuong = new Hashtable();
        public static Hashtable tenGiai = new Hashtable();
        public static Hashtable tenXoSo = new Hashtable();
        public static DateTime now = DateTime.Now;
        public static bool ktNgauNhien = true;
        public static bool ktQuay = true;
        public static int tmrNgauNhien = 1;
        public static int tmrNgauNhien1 = 2;
        public static String henGio = "";
       
        public static decimal soNgauNhien = 1;
        public static decimal soNgauNhien2 = 1;
        public static bool kt = true;

        // lấy giải
        public static String giaiGiDo(String a)
        {
            Cls_Hieu.giaiThuong.Clear();
            giaiThuong.Add("GiaiDB", "Giải ĐB");
            giaiThuong.Add("Giai1", "Giải Nhất");
            giaiThuong.Add("Giai2", "Giải Nhì");
            giaiThuong.Add("Giai3", "Giải Ba");
            giaiThuong.Add("Giai4", "Giải Tư");
            giaiThuong.Add("Giai5", "Giải Năm");
            giaiThuong.Add("Giai6", "Giải Sáu");
            giaiThuong.Add("Giai7", "Giải Bảy");
            giaiThuong.Add("Giai8", "Giải Tám");
            if (giaiThuong[a] == null) return "Không có";

            return giaiThuong[a].ToString();
        }
     

        // test bảng hashmap
        public static void hienThiKetQua()
        {
            foreach(DictionaryEntry V in luuGiaTri)
            {
                Console.WriteLine(V.Key + "\t" + V.Value);
            }
        }


        // tìm kiếm hiện tại
        public static String ketQuaTimKiem(String so,Hashtable luuGiaTri)
        {
            string timKiemDuoc = "";
            foreach (DictionaryEntry V in luuGiaTri)
            {
                String[] s = V.Value.ToString().Split('-');
                for(int i = 0; i < s.Length; i++)
                {

                    int so1 = so.Length - s[i].Length < 0 ? 0 : so.Length - s[i].Length;
                    if (so.Substring(so1).Equals(s[i])) timKiemDuoc +=   V.Key.ToString() + " " + s[i] + "@"; 
                }  
            }
            
            return timKiemDuoc;
        }

        // tìm kiếm tất cả file xổ số trong thư mục
        public static String ketQuaTimKiemTatCa(String so)
        {
            Hashtable timKiem = new Hashtable();
            String timKiemDuoc ="";
            String[] duongDan = layTenFile();
            for(int i = 0; i < duongDan.Length; i++)
            {
                timKiem.Clear();
                String[] duLieu = Cls_Hieu.docThuMuc(duongDan[i]);  // lấy dữ liệu từ đường dẫn
                Console.WriteLine(duongDan[i]);
                for (int y = 0; y < duLieu.Length; y++)
                {
                    
                    string[] s = duLieu[y].Split(':');
                    if (s.Length == 1) continue;
                    if (!timKiem.ContainsKey(s[0])) timKiem.Add(s[0],s[1]);
                }
                foreach (DictionaryEntry V in timKiem)
                {
                    String[] s = V.Value.ToString().Split('-');
                    for (int z = 0; z < s.Length; z++)
                    {

                        int so1 = so.Length - s[z].Length < 0 ? 0 : so.Length - s[z].Length;

                       
                        if (so.Substring(so1).Equals(s[z]))
                        {
                            timKiemDuoc += duongDan[i]+" "+V.Key.ToString() + " " + s[z] + "@";
                            
                        }
                    }
                }

            }
            return timKiemDuoc;
        }


        public static string doiVietTat(string dai)
        {
            Hashtable doiten = new Hashtable();
            doiten.Add("ĐÀ NẴNG","DN");
            doiten.Add("HÀ NỘI","HN");
            doiten.Add("QUẢNG NAM","QN" );
            doiten.Add("SÀI GÒN","SG") ;
            doiten.Add("HUẾ","HU");
            doiten.Add("HẢI PHÒNG","HP");
            doiten.Add("GIA LAI","GL");
            doiten.Add("HÒA BÌNH","HB");
            doiten.Add("HÀ GIANG","HAG");
            doiten.Add("HÀ TĨNH","HT");
            doiten.Add("HƯNG YÊN","HY");
            doiten.Add("HẢI DƯƠNG","HD");
            doiten.Add("HẬU GIANG","HG");
            doiten.Add("ĐIỆN BIÊN","DB");
            doiten.Add("ĐẮK LẮK","DL");
            doiten.Add("ĐẮK NÔNG","DNN");
            doiten.Add("ĐỒNG NAI","DNA");
            doiten.Add("ĐỒNG THÁP","DT");
            doiten.Add("KHÁNH HÒA","KH");
            doiten.Add("KIÊN GIANG", "KG");
            doiten.Add("KON TUM", "KT");
            doiten.Add("LONG AN","LA");
            doiten.Add("LÀO CAI","LC");
            doiten.Add("LÂM ĐỒNG","LD");
            doiten.Add("LẠNG SƠN","LS");
            doiten.Add("NAM ĐỊNH","ND");
            doiten.Add("NGHỆ AN","NA");
            doiten.Add("NINH BÌNH","NB");
            doiten.Add("NINH THUẬN","NT");
            doiten.Add("PHÚ THỌ","PT");
            doiten.Add("PHÚ YÊN","PY");
            doiten.Add("QUẢNG BÌNH","QB");
            doiten.Add("QUẢNG NGÃI","QNA");
            doiten.Add("QUẢNG NINH","QNN");
            doiten.Add("QUẢNG TRỊ","QT");
            doiten.Add("SÓC TRĂNG","ST");
            doiten.Add("SƠN LA","SL");
            doiten.Add("THANH HÓA","TH");
            doiten.Add("THÁI BÌNH","TB");
            doiten.Add("THÁI NGUYÊN","TN");
            doiten.Add("TIỀN GIANG","TG");
            doiten.Add("TRÀ VINH","TV");
            doiten.Add("TUYÊN QUANG","TQ");
            doiten.Add("TÂY NINH","TNI");
            doiten.Add("VĨNH LONG", "VL");
            doiten.Add("VĨNH PHÚC","VP");
            doiten.Add("YÊN BÁI","YB");
            doiten.Add("AN GIANG","AG");
            doiten.Add("VŨNG TÀU","VT");
            doiten.Add("BẠC LIÊU","BL");
            doiten.Add("BẮC GIANG","BG");
            doiten.Add("BẮC KẠN","BK");
            doiten.Add("BẮC NINH","BN");
            doiten.Add("BẾN TRE","BTR");
            doiten.Add("BÌNH DƯƠNG","BDD");
            doiten.Add("BÌNH ĐỊNH","BD");
            doiten.Add("BÌNH PHƯỚC","BP");
            doiten.Add("BÌNH THUẬN","BT");
            doiten.Add("CAO BẰNG","CB");
            doiten.Add("CÀ MAU","CM");
            doiten.Add("CẦN THƠ", "CT");
            if (doiten[dai] == null) return "";
            return doiten[dai].ToString();
        }
        public static String ketQuaTimTheoDai(String so,String tenDai,string ngay)
        {
            Hashtable timKiem = new Hashtable();
            String timKiemDuoc = "";
            String[] duongDan = layTenFile();
            int count = 0; 
          
            for (int i = 0; i < duongDan.Length; i++)
            {
               
                if (duongDan[i].Contains(doiVietTat(tenDai.ToUpper())) && duongDan[i].Contains(ngay.Replace(@"/", "_"))) count += 1;
                else continue;
                timKiem.Clear();
                String[] duLieu = Cls_Hieu.docThuMuc(duongDan[i]);  // lấy dữ liệu từ đường dẫn
                Console.WriteLine(duongDan[i]);
                for (int y = 0; y < duLieu.Length; y++)
                {

                    string[] s = duLieu[y].Split(':');
                    if (s.Length == 1) continue;
                    if (!timKiem.ContainsKey(s[0])) timKiem.Add(s[0], s[1]);
                }
                foreach (DictionaryEntry V in timKiem)
                {
                    String[] s = V.Value.ToString().Split('-');
                    for (int z = 0; z < s.Length; z++)
                    {

                        int so1 = so.Length - s[z].Length < 0 ? 0 : so.Length - s[z].Length;


                        if (so.Substring(so1).Equals(s[z]))
                        {
                            timKiemDuoc += duongDan[i] + " " + V.Key.ToString() + " " + s[z] + "@";

                        }
                    }
                }

            }
           if(count == 0)
            {
                return "Không tìm thấy đài dò";
            }
            return timKiemDuoc;
        }


        public static String ketQuaTimTheoNgay(String so, String ngay)
        {
            Hashtable timKiem = new Hashtable();
            String timKiemDuoc = "";
            String[] duongDan = layTenFile();
            for (int i = 0; i < duongDan.Length; i++)
            {
                if (duongDan[i].Contains(ngay)) continue;
                timKiem.Clear();
                String[] duLieu = Cls_Hieu.docThuMuc(duongDan[i]);  // lấy dữ liệu từ đường dẫn
                Console.WriteLine(duongDan[i]);
                for (int y = 0; y < duLieu.Length; y++)
                {

                    string[] s = duLieu[y].Split(':');
                    if (s.Length == 1) continue;
                    if (!timKiem.ContainsKey(s[0])) timKiem.Add(s[0], s[1]);
                }
                foreach (DictionaryEntry V in timKiem)
                {
                    String[] s = V.Value.ToString().Split('-');
                    for (int z = 0; z < s.Length; z++)
                    {

                        int so1 = so.Length - s[z].Length < 0 ? 0 : so.Length - s[z].Length;


                        if (so.Substring(so1).Equals(s[z]))
                        {
                            timKiemDuoc += duongDan[i] + " " + V.Key.ToString() + " " + s[z] + "@";

                        }
                    }
                }

            }
            return timKiemDuoc;
        }

        // giải mã đường dẫn
        public static String[] giaiMaTen()
        {
            tenXoSo.Clear();
            String[] s = layTenFile();
            for(int i = 0; i < s.Length; i++)
            {
                string s1 = FrmHieu.giaiTriDoi(s[i]);
                tenXoSo.Add(s1, s[i]);
            }
            String[] s2 = new string[tenXoSo.Count];
            int y = 0;
            foreach(DictionaryEntry v in tenXoSo)
            {
                s2[y] = v.Key.ToString();
                y += 1;
            }
            
            return s2;
        }


        // giải mã tên đường dẫn
        public static String giaiMaDuongDan(String path)
        {

            Console.WriteLine(tenXoSo[path].ToString());
            return tenXoSo[path].ToString();
        }
        public static void LuuThuMuc(String ngay,String dai,String gia)
        {
            ngay = ngay.Replace("/", "_");
            string h = ngay+"+"+DateTime.Now.ToString("HH_mm_ss");
           
            Console.WriteLine(h);
            String path = @""+duongDan()+@"\KetQuaXoSo\DN+"+h+".txt";
            Console.WriteLine(path);
            String s = "";
            foreach (DictionaryEntry V in luuGiaTri)
            {
                s += V.Key+":"+V.Value + "\n";
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "ĐÀI XỔ:" +"ĐÀ NẴNG" +"\n");
                AddText(fs,"GIÁ VÉ:"+gia+"\n");
                AddText(fs, s);
                
            }
        }

        // lưu file
        public static void LuuFile(String ngay)
        {

            string h = DateTime.Now.ToString("yyyy_MM_dd+HH_mm_ss");

            String path = @"" + duongDan() + @"\KetQuaXoSo\DN+" + h + "sss.txt";

            FileStream fs = File.Create(path);
            var sr = new StreamWriter(fs);
            String s = "";
            foreach (DictionaryEntry V in luuGiaTri)
            {
                s += V.Key + ":" + V.Value + "\n";
                
            }
            sr.WriteLine(s);
            sr.Close();
            fs.Close();
            
            
        }
        // ghi dữ liệu
        public static void LuuThuMuc2(String ten,String ngay,String dai,String gia)
        {
            ten = ten.Replace("HÀ NỘI", "HN");
            ten = ten.Replace("QUẢNG NAM","QN");
            ten = ten.Replace("SÀI GÒN", "SG");
            ten = ten.Replace("HẢI PHÒNG", "HP");
            ten = ten.Replace("GIA LAI", "GL");
            ten = ten.Replace("HÒA BÌNH", "HB");
            ten = ten.Replace("HÀ GIANG", "HAG");
            ten = ten.Replace("HÀ TĨNH", "HT");
            ten = ten.Replace("HƯNG YÊN", "HY");
            ten = ten.Replace("HẢI DƯƠNG", "HD");
            ten = ten.Replace("HẬU GIANG", "HG");
            ten = ten.Replace("ĐIỆN BIÊN", "DB");
            ten = ten.Replace("ĐẮK LẮK", "DL");
            ten = ten.Replace("ĐẮK NÔNG", "DNN");
            ten = ten.Replace("ĐỒNG NAI", "DNA");
            ten = ten.Replace("ĐỒNG THÁP", "DT");
            ten = ten.Replace("KHÁNH HÒA", "KH");
            ten = ten.Replace("KIÊN GIANG", "KG");
            ten = ten.Replace("KON TUM", "KT");
            ten = ten.Replace("LONG AN", "LA");
            ten = ten.Replace("LÀO CAI", "LC");
            ten = ten.Replace("LÂM ĐỒNG", "LD");
            ten = ten.Replace("LẠNG SƠN", "LS");
            ten = ten.Replace("NAM ĐỊNH", "ND");
            ten = ten.Replace("NGHỆ AN", "NA");
            ten = ten.Replace("NINH BÌNH","NB");
            ten = ten.Replace("NINH THUẬN", "NT");
            ten = ten.Replace("PHÚ THỌ", "PT");
            ten = ten.Replace("PHÚ YÊN", "PY");
            ten = ten.Replace("QUẢNG BÌNH", "QB");
            ten = ten.Replace("QUẢNG NGÃI", "QNA");
            ten = ten.Replace("QUẢNG NINH", "QNN");
            ten = ten.Replace("QUẢNG TRỊ", "QT");
            ten = ten.Replace("SÓC TRĂNG", "ST");
            ten = ten.Replace("SƠN LA", "SL");
            ten = ten.Replace("THANH HÓA", "TH");
            ten = ten.Replace("THÁI BÌNH", "TB");
            ten = ten.Replace("THÁI NGUYÊN", "TN");
            ten = ten.Replace("TIỀN GIANG", "TG");
            ten = ten.Replace("TRÀ VINH", "TV");
            ten = ten.Replace("TUYÊN QUANG", "TQ");
            ten = ten.Replace("TÂY NINH", "TNI");
            ten = ten.Replace("VĨNH LONG", "VL");
            ten = ten.Replace("VĨNH PHÚC", "VP");
            ten = ten.Replace("YÊN BÁI", "YB");
            ten = ten.Replace("AN GIANG", "AG");
            ten = ten.Replace("VŨNG TÀU", "VT");
            ten = ten.Replace("BẠC LIÊU", "BL");
            ten = ten.Replace("BẮC GIANG", "BG");
            ten = ten.Replace("BẮC KẠN", "BK");
            ten = ten.Replace("BẮC NINH", "BN");
            ten = ten.Replace("BẾN TRE", "BTR");
            ten = ten.Replace("BÌNH DƯƠNG", "BDD");
            ten = ten.Replace("BÌNH ĐỊNH", "BD");
            ten = ten.Replace("BÌNH PHƯỚC", "BP");
            ten = ten.Replace("BÌNH THUẬN", "BT");
            ten = ten.Replace("CAO BẰNG", "CB");
            ten = ten.Replace("CÀ MAU", "CM");
            ten = ten.Replace("CẦN THƠ", "CT");
            ten = ten.Replace("HUẾ", "HU");

            ngay = ngay.Replace("/", "_");
            string h = ngay + "+" + DateTime.Now.ToString("HH_mm_ss");

            String path = @"" + duongDan() + @"\KetQuaXoSo\"+ten+"+" + h + ".txt";
            Console.WriteLine(path);
            String s = "";
            foreach (DictionaryEntry V in luuGiaTri2)
            {
                s += V.Key + ":" + V.Value + "\n";
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, "ĐÀI XỔ:" + dai + "\n");
                AddText(fs, "GIÁ VÉ:" + gia + "\n");
                AddText(fs, s);
            }
        }
        // đọc dữ liệu
        public static string[] docThuMuc(String path)
        {

            
            
            String[] duLieu = System.IO.File.ReadAllLines(path);

            return duLieu;


        }
        // ghi dữ liệu
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }


        // lấy đường dẫn thư mục
        public static String duongDan()
        {
            string duongDan = Environment.CurrentDirectory.ToString(); // lấy đường dẫn thư mục
            var url = Directory.GetParent(Directory.GetParent(duongDan).ToString()); // lấy thư mục cha
           
            return url.ToString();
           
        }
       
        // lấy tên file
        public static String[] layTenFile()
        {
            string[] file = Directory.GetFiles(duongDan() + @"\KetQuaXoSo\", "*.txt");
            return file;
        }
        
    }
}
