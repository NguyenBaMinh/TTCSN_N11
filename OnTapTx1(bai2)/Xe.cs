using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnTapTx1_bai2_
{
    internal class Xe
    {
        private string soDK, hangSX;
        private int namSX;
        public string SoDK
        {
            get { return soDK; }
            set { soDK = value; }
        }
        public string HangSX
        {
            get { return hangSX; }
            set { hangSX = value; }
        }
        public int NamSX
        {
            get { return namSX; }
            set { namSX = value; }
        }
        public Xe() { }
        public Xe(string soDK, string hangSX, int namSX)
        {
            this.soDK = soDK;
            this.hangSX = hangSX;
            this.namSX = namSX;
        }
        public override string ToString()
        {
            return $"{soDK,-15}{hangSX,-15}{namSX,-15}";
        }
        public override bool Equals(object obj)
        {
            Xe x = obj as Xe;
            return (this.soDK.Equals(x.soDK));
        }

    }
}
