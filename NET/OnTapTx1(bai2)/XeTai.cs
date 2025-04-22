using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapTx1_bai2_
{
    internal class XeTai: Xe
    {
        public int taiTrong;
        public int TaiTrong
        {
            get { return taiTrong; }
            set { taiTrong = value; }
        }
        public XeTai() : base() { }
        public XeTai(string soDK, string hangSX, int namSX, int taiTrong)
            :base(soDK, hangSX, namSX)
        {
            this.taiTrong = taiTrong;
        }
        public double tinhPhi()
        {
            if (taiTrong > 0 && taiTrong < 8)
            {
                return 1000000;
            }
            else if (taiTrong >= 8 && taiTrong <= 13)
            {
                return 2000000;
            }
            else return 3000000;
        }
        public override string ToString()
        {
            return base.ToString() +$"{taiTrong,-15}{tinhPhi(),-15}";
        }
    }
}
