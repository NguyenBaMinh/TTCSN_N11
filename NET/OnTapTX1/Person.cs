using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OnTapTX1
{
    internal abstract class Person
    {
        private string hoTen, diaChi;
        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }
        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }
        public Person() { }
        public Person(string hoTen, string diaChi)
        {
            this.hoTen = hoTen;
            this.diaChi = diaChi;
        }
        public override string ToString()
        {
            return $"{HoTen,-30}{DiaChi,-15}";
        }

        public abstract double tinhLuong();
    }
}
