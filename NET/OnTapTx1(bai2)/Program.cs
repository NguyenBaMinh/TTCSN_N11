using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapTx1_bai2_
{
    internal class Program
    {   
        static List<Xe> ds = new List<Xe>();
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            bool exit = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=====MENU CHƯƠNG TRÌNH======");
                Console.WriteLine("1.Nhập thông tin");
                Console.WriteLine("2.Hiển thị danh sách");
                Console.WriteLine("3.Sửa");
                Console.WriteLine("4.Thoát");
                Console.WriteLine("5.Sắp xếp");
                Console.Write("Nhập lựa chọn của bạn: ");
                Console.ResetColor();
                string luachon = Console.ReadLine();
                switch (luachon)
                {
                    case "1":
                        NhapThongTin();
                        break;
                    case "2":
                        HienThiDanhSach();
                        break;
                    case "3":
                        Sua();
                        break;
                    case "4":
                        exit = true;
                        break;
                    case "5":
                        SapXep();
                        break;
                    default:
                        Console.WriteLine("Bạn nhập sai! vui lòng nhập lại");
                        break;
                }
            }while (!exit);
        }
        public static void NhapThongTin()
        {
            Console.WriteLine("1.Xe");
            Console.WriteLine("2.Xe Tải");
            Console.Write("Nhập lựa chọn: ");
            string chon = Console.ReadLine();
            switch (chon)
            {
                case "1":
                    Xe xe = new Xe();
                    Console.Write("Nhập số đăng ký: ");
                    xe.SoDK = Console.ReadLine();
                    if(ds.Exists( x => x.SoDK == xe.SoDK))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Số đăng ký bị trùng!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Nhập hãng sản xuất: ");
                        xe.HangSX = Console.ReadLine();
                        Console.Write("Nhập năm sản xuất: ");
                        xe.NamSX = int.Parse(Console.ReadLine());
                        ds.Add(xe);
                        Console.WriteLine("Thêm thành công!");
                    }
                    break;
                case "2":
                    XeTai xt = new XeTai();
                    Console.Write("Nhập số đăng ký: ");
                    xt.SoDK = Console.ReadLine();
                    if (ds.Exists(x => x.SoDK == xt.SoDK))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Số đăng ký bị trùng!");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("Nhập hãng sản xuất: ");
                        xt.HangSX = Console.ReadLine();
                        Console.Write("Nhập năm sản xuất: ");
                        xt.NamSX = int.Parse(Console.ReadLine());
                        Console.Write("Nhập tải trọng: ");
                        xt.TaiTrong = int.Parse(Console.ReadLine());
                        ds.Add(xt);
                        Console.WriteLine("Thêm thành công!");
                    }
                    break;
            }
        }

        public static void HienThiDanhSach()
        {
            Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}","Số đăng ký","Hãng sản xuất","Năm snar xuất","Tải trọng","Phí đường bộ");
            foreach (Xe x in ds)
            {
                Console.WriteLine(x.ToString());
            }
        }
        public static void Sua()
        {
            Console.Write("Nhập số đăng ký cần sửa: ");
            string sua = Console.ReadLine();
            var xe = ds.Find(x => x.SoDK == sua);
            if (xe == null) {
                Console.WriteLine("Không tìm thấy xe!");
            }

        }
        public static void SapXep()
        {
            ds.Sort((x1, x2) =>
            {
                int q = string.Compare(x1.HangSX, x2.HangSX);
                if (q == 0)
                {
                    q = x1.NamSX.CompareTo(x2.NamSX);
                }
                return q;
            });
            Console.WriteLine("Danh sách sau khyi sắp xêp: ");
            HienThiDanhSach();
            
        }
    }
}
/*
 sửa
public static void Sua()
{
    Console.Write("Nhập số đăng ký cần sửa: ");
    string sua = Console.ReadLine();
    var xe = ds.Find(x => x.SoDK == sua);
    if (xe == null)
    {
        Console.WriteLine("Không tìm thấy xe!");
        return;
    }

    Console.Write("Nhập hãng sản xuất mới: ");
    xe.HangSX = Console.ReadLine();
    Console.Write("Nhập năm sản xuất mới: ");
    xe.NamSX = int.Parse(Console.ReadLine());

    if (xe is XeTai xeTai)
    {
        Console.Write("Nhập tải trọng mới: ");
        xeTai.TaiTrong = int.Parse(Console.ReadLine());
    }

    Console.WriteLine("Sửa thông tin thành công!");
}

tìm kiếm
public static void TimKiem()
{
    Console.Write("Nhập số đăng ký cần tìm: ");
    string s = Console.ReadLine();
    var ketqua = ds.Find(x => x.SoDK == s);
    if (ketqua != null)
    {
        Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", "Số đăng ký", "Hãng sản xuất", "Năm sản xuất", "Tải trọng", "Phí đường bộ");
        Console.WriteLine(ketqua.ToString());
    }
    else
    {
        Console.WriteLine("Không tìm thấy xe.");
    }
}

xóa
public static void Xoa()
{
    Console.Write("Nhập số đăng ký cần xóa: ");
    string ma = Console.ReadLine();
    var xe = ds.Find(x => x.SoDK == ma);
    if (xe != null)
    {
        ds.Remove(xe);
        Console.WriteLine("Đã xóa xe có số đăng ký: " + ma);
    }
    else
    {
        Console.WriteLine("Không tìm thấy xe để xóa.");
    }
}

 
 */
