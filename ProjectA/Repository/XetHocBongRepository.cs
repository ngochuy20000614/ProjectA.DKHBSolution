using ProjectA.Models;
using ProjectA.Service;
using ProjectA.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Repository
{
    public class XetHocBongRepository : IXetHocBong
    {
        private readonly ApplicationDbContext _context;
        public XetHocBongRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public XetHocBongViewModel[] DanhSachDatHocBong()
        {
            double heSo = 1;
            double soTien = 5320000;
            var sinhVien = from sv in _context.SinhViens
                           join d in _context.Diems on sv.IdSinhVien equals d.IdSinhVien
                           join l in _context.Lops on sv.IdLop equals l.IdLop
                           orderby d.DiemThang4 descending
                           select new { sv, d, l };
            var query = sinhVien.Select(x => new XetHocBongViewModel()
            {
                IdSinhVien = x.sv.IdSinhVien,
                TenSinhVien = x.sv.TenSinhVien,
                IdLop = x.l.IdLop,
                SoTinChi = x.d.SoTinChi,
                DiemThang10 = x.d.DiemThang4,
                DiemThang4 = x.d.DiemThang10,
                XepLoai = x.d.XepLoai,
                SoTien = heSo * soTien
            });
            return query.ToArray();
        }
    }
}
