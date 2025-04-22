using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapTX1
{
    internal class Program
    {
        static List<NhanVien> ds = new List<NhanVien>();
        static void Main(string[] args)
        {
            bool exit = false;
            do
            {
                Console.WriteLine("MENU CHUONG TRINH");
                Console.WriteLine("1.Them nhan vien");
                Console.WriteLine("2.Hien thi danh sach");
                Console.WriteLine("3.Sap xep");
                Console.WriteLine("4.Thoat");
                Console.WriteLine("5.Xoa");
                Console.WriteLine("6.Tim kiem");
                Console.WriteLine("7.Sua");
                Console.Write("Nhap lua chon cua ban: ");
                string luachon = Console.ReadLine();
                switch (luachon)
                {
                    case "1":
                        Them();
                        break;
                    case "2":
                        HienThiDanhSach();
                        break;
                    case "3":
                        Sapxep();
                        break;
                    case "4":
                        exit = true;
                        break;
                    case "5":
                        Xoa();
                        break;
                    case "6":
                        TimKiem();
                        break;
                    case "7":
                        Sua();
                        break;
                    default:
                        Console.WriteLine("Ban nhap sai! Vui long nhap lai");
                        break;
                }
            }while (!exit);
        }
        public static void Them()
        {
            NhanVien n = new NhanVien();
            Console.WriteLine("Nhap thong tin cua nhan vien");
            Console.Write("Nhap ma nhan vien: ");
            n.MaNV = Console.ReadLine();
            if(ds.Exists(x => x.MaNV == n.MaNV))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Nhap trung ma nhan vien!");
                Console.ResetColor();
            }
            else
            {
                Console.Write("Nhap ho ten: ");
                n.HoTen = Console.ReadLine();
                Console.Write("Nhap dia chi: ");
                n.DiaChi = Console.ReadLine();
                Console.Write("Nhap chuc vu: ");
                n.chucVu = Console.ReadLine();
                Console.Write("Nhap he so luong co ban: ");
                n.hslcb = int.Parse(Console.ReadLine());
                ds.Add(n);
                Console.WriteLine("Them thanh cong!");
            }
        }
        public static void HienThiDanhSach()
        {
            //Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-15}{4,-15}{5,-15}", "Ma nhan vien","Ho va ten","Dia chi","Chuc vu","He so luong co ban","Luong");
            foreach (NhanVien q in ds)
            {
                Console.WriteLine(q.ToString());
            }
        }
        public static void Sapxep()
        {
            ds.Sort((x1, x2) =>
            {
                int q = string.Compare(x1.HoTen, x2.HoTen);
                if (q == 0)
                {
                    q = x1.hslcb.CompareTo(x2.hslcb);
                }
                return q;
            });
            Console.WriteLine("Danh sach sau khi sap xep: ");
            HienThiDanhSach();
        }
        public static void Xoa()
        {
            NhanVien n = new NhanVien();
            Console.Write("Nhap ma nhan vien can xoa: ");
            n.maNV = Console.ReadLine();
            for(int i = 0; i < ds.Count; i++) 
            {
                if (n.maNV == ds[i].maNV)
                {
                    ds.Remove(ds[i]);
                    Console.WriteLine("Xoa thanh cong!");
                    HienThiDanhSach();
                }
                else
                {
                    Console.WriteLine("Khong co ma nhan vien tren!");
                }
            }
        }
        public static void TimKiem()
        {
            NhanVien nv = new NhanVien();
            Console.Write("Nhap ma nhan vien can tim: ");
            nv.maNV = Console.ReadLine();
            for(int i = 0;i < ds.Count; i++)
            {
                if(nv.maNV == ds[i].maNV)
                {
                    Console.WriteLine("Tim thay nhan vien!");
                    Console.WriteLine("{0,-15}{1,-30}{2,-15}{3,-15}{4,-15}{5,-15}", "Ma nhan vien", "Ho va ten", "Dia chi", "Chuc vu", "He so luong co ban", "Luong");
                    Console.WriteLine(ds[i].ToString());
                }
                else
                {
                    Console.WriteLine("Khong tim thay nhan vien!");
                }
            }
        }
        public static void Sua()
        {
            bool kiemtra = false;
            NhanVien n = new NhanVien();
            Console.Write("Nhap ma nhan vien can sua: ");
            n.maNV = Console.ReadLine();
            for (int i = 0; i < ds.Count; i++)
            {
                if(n.maNV == ds[i].maNV)
                {
                    kiemtra = true;
                    Console.Write("Nhap ho ten moi: ");
                    ds[i].HoTen = Console.ReadLine();
                    Console.Write("Nhap dia chi moi: ");
                    ds[i].DiaChi = Console.ReadLine();
                    Console.Write("Nhap chuc vu moi: ");
                    ds[i].chucVu = Console.ReadLine();
                    Console.Write("Nhap he so luong co ban moi: ");
                    ds[i].hslcb = int.Parse(Console.ReadLine());
                    Console.WriteLine("Sua thanh cong!");
                    break;
                }
            }
            if (!kiemtra)
            {
                Console.WriteLine("Khong tim thay thong tin");
            }
            //HienThiDanhSach();
        }
    }
}
