using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace XoSo_TrinhPhucHieu
{
    class Cls_Hieu
    {

        public static Hashtable luuGiaTri = new Hashtable();
        public static Hashtable giaiThuong = new Hashtable();
        public static Hashtable tenGiai = new Hashtable();
        public static Hashtable tenXoSo = new Hashtable();
        public static DateTime now = DateTime.Now;
        public static bool ktNgauNhien = true;
        public static int tmrNgauNhien = 1;
        public static decimal soNgauNhien = 1;
        public static bool kt = true;
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
            return giaiThuong[a].ToString();
        }
       
        public static void hienThiKetQua()
        {
            foreach(DictionaryEntry V in luuGiaTri)
            {
                Console.WriteLine(V.Key + "\t" + V.Value);
            }
        }
        public static String ketQuaTimKiem(String so)
        {
            
            foreach (DictionaryEntry V in luuGiaTri)
            {
                String[] s = V.Value.ToString().Split('-');
                for(int i = 0; i < s.Length; i++)
                {

                    int so1 = so.Length - s[i].Length < 0 ? 0 : so.Length - s[i].Length;
                    
                    Console.WriteLine(s[i]);
                    if (so.Substring(so1).Equals(s[i])) return V.Key.ToString() + " " + s[i];
                }  
            }
            
            return "Error";
        }

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
        public static String giaiMaDuongDan(String path)
        {
            Console.WriteLine(tenXoSo[path].ToString());
            return tenXoSo[path].ToString();
        }
        public static void LuuThuMuc()
        {
            
            string h = now.ToString("yyyy_MM_dd+hh_mm_ss");
           
            Console.WriteLine(h);
            String path = @""+duongDan()+@"\KetQuaXoSo\DN+" +h+".txt";
            Console.WriteLine(path);
            String s = "";
            foreach (DictionaryEntry V in luuGiaTri)
            {
                s += V.Key+":"+V.Value + "\n";
            }
            using (FileStream fs = File.Create(path))
            {
                AddText(fs, s);
            }
            now = DateTime.Now;


        }
        public static string[] docThuMuc(String path)
        {

            luuGiaTri.Clear();
            /*
            foreach (DictionaryEntry V in luuGiaTri)
            {
                s += V.Key + ":" + V.Value + "\n";
            }
            */
            String[] duLieu = System.IO.File.ReadAllLines(path);

            return duLieu;


        }
        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        public static String duongDan()
        {
            string duongDan = Environment.CurrentDirectory.ToString();
            var url = Directory.GetParent(Directory.GetParent(duongDan).ToString());
           
            return url.ToString();
           
        }
        public static String[] layTenFile()
        {
            string[] file = Directory.GetFiles(duongDan() + @"\KetQuaXoSo\", "*.txt");
            return file;
        }
        
    }
}
