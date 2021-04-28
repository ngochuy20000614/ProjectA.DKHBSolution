using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.ViewModel
{
    public class XetHocBongViewModel
    {
        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Mã sinh viên")]
        public string IdSinhVien { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Tên sinh viên")]
        public string TenSinhVien { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Lớp")]
        public string IdLop { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Số tín chỉ")]
        public int SoTinChi { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Điểm thang 4")]
        public double? DiemThang4 { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Điểm thang 10")]
        public double? DiemThang10 { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Xếp loại")]
        public string XepLoai { get; set; }

        [Required(ErrorMessage = "Mã sinh viên phải bắt buộc")]
        [DisplayName("Số tiền")]
        public double SoTien { get; set; }
    }
}
