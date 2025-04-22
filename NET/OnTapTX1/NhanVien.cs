using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapTX1
{
    internal class NhanVien : Person
    {
        public string maNV, chucVu;
        public int hslcb;
        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }
        public string ChucVu
        {
            get { return chucVu; }
            set { chucVu = value; } 
        }
        public int Hslcb
        {
            get { return hslcb; }
            set { hslcb = value; }
        }
        public NhanVien() : base() { }
        public NhanVien(string hoTen, string diaChi, string maNV, string chucVu, int hslcb)
            : base(hoTen,diaChi)
        {
            this.maNV = maNV;
            this.chucVu = chucVu;
            this.hslcb = hslcb;
        }

        public override double tinhLuong()
        {
            int hscv;
            if (chucVu == "Giam doc") {
                hscv = 10;
            }
            else if (chucVu == "Truong phong" || chucVu == "Pho giam doc")
            {
                hscv = 6;
            }
            else if (chucVu == "Pho phong")
            {
                hscv = 4;
            }
            else
            {
                hscv = 2;
            }
            return (hslcb + hscv) * 2000000;
        }
        public override string ToString()
        {
            return $"{MaNV,-15}"  + base.ToString() + $"{ChucVu,-15}{Hslcb,-15}{tinhLuong(),-15}";
        }
        public override bool Equals(object obj)
        {
           NhanVien n = obj as NhanVien;
            return (this.MaNV.Equals(n.MaNV));
        }

    }
    }
