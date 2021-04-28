using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectA.Models
{
    public partial class Diem
    {
        public string IdHocKy { get; set; }

        public string IdSinhVien { get; set; }

        public double? DiemThang4 { get; set; }

        public double? DiemThang10 { get; set; }

        public int SoTinChi { get; set; }

        public string XepLoai { get; set; }

        public byte DiemRenLuyen { get; set; }

        public virtual HocKy IdHocKyNavigation { get; set; }
        public virtual SinhVien IdSinhVienNavigation { get; set; }
    }
}
