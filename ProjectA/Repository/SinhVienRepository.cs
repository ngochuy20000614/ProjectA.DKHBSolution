using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProjectA.ViewModel;
namespace ProjectA.Models
{
    public class SinhVienRepository : ISinhVien
    {
        private ApplicationDbContext _context;
        public SinhVienRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<SinhVien> GetStudents => _context.SinhViens.Include(x=>x.IdLopNavigation);

        public SinhVien Create()
        {
            var max = _context.SinhViens.Max(b => b.IdSinhVien);

            var b = new SinhVien()
            {
                IdSinhVien = Convert.ToString(Convert.ToInt64(max) + 1)
            };
            return b;
        }

        public void Add(SinhVien sinhVien)
        {
            _context.SinhViens.Add(sinhVien);
            _context.SaveChanges();
        }

        public SinhVien GetSinhVienById(string Id)
        {
            SinhVien dbEntity = _context.SinhViens
                                .Include(h => h.IdLopNavigation)
                                .FirstOrDefault(s => s.IdSinhVien == Id);
            return dbEntity;
        }

        public void Remove(string Id)
        {
            var b = Get(Id);
            _context.SinhViens.Remove(b);
            _context.SaveChanges();
        }
        public void Update(SinhVien sinhVien)
        {
            _context.SinhViens.Update(sinhVien);
            _context.SaveChanges();
        }
        public SinhVien Get(string id) => _context.SinhViens.FirstOrDefault(s => s.IdSinhVien == id);

        public SinhVien[] GetListSV(string search)
        {
            var movies = from m in _context.SinhViens
                         select m;

            if (!String.IsNullOrEmpty(search))
            {
                movies = movies.Where(
                    s => s.IdSinhVien.Contains(search) ||
                    s.TenSinhVien.Contains(search) ||
                    s.IdLop.Contains(search));
            }
            return movies.ToArray();
        }

        public async Task<List<SinhVienViewModel>> GetSinhViens()
        {
            var query = from p in _context.SinhViens
                        join pt in _context.Lops on p.IdLop equals pt.IdLop
                        select new { p, pt };

            return await query.Select(x => new SinhVienViewModel()
            {
                IdSinhVien = x.p.IdSinhVien,
                TenSinhVien = x.p.TenSinhVien,
                TenLop = x.pt.TenLop,
                NgaySinh = x.p.NgaySinh,
                GioiTinh = x.p.GioiTinh
            }).ToListAsync();
        }
        public (SinhVien[] books, int pages, int page) Paging(int page)
        {
            int x = _context.SinhViens.Count();
            int size = 5;
            int pages = (int)Math.Ceiling((double)x / size);
            var books = _context.SinhViens.Skip((page - 1) * size).Take(size).ToArray();
            return (books, pages, page);
        }

        public int numberPage(int totalProduct, int limit)
        {
            float numberpage = totalProduct / limit;
            return (int)Math.Ceiling(numberpage);

        }

        public IEnumerable<SinhVien> paginationProduct(int start, int limit)
        {
            var data = (from s in _context.SinhViens select s);
            var dataProduct = data.OrderByDescending(x => x.IdSinhVien).Skip(start).Take(limit);
            return dataProduct.ToList();
        }

        public int totalProduct()
        {
            return _context.SinhViens.Count();
        }
    }
}
