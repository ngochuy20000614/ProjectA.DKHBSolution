using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectA.Models;
using ProjectA.Service;
using ProjectA.ViewModel;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    [Authorize]
    public class SinhVienController : Controller
    {
        private readonly ISinhVien _SinhVien;
        private readonly ILop _Lop;
        private readonly ApplicationDbContext _context;
       
        public SinhVienController(ISinhVien SinhVien, ILop Lop, ApplicationDbContext context)
        {
            _SinhVien = SinhVien;
            _Lop = Lop;
            _context = context;
        }

        public IActionResult Index(int? page = 0)
        {
            int limit = 3;
            int start;
            if (page > 0)
            {
               page = page;
            }
            else
            {
                page = 1;
            }
            start = (int)(page - 1) * limit;

            ViewBag.pageCurrent = page;

            int totalProduct = _SinhVien.totalProduct();

            ViewBag.totalProduct = totalProduct;

            ViewBag.numberPage = _SinhVien.numberPage(totalProduct, limit);

            var data = _SinhVien.paginationProduct(start, limit);

            return View(data.ToList());
        }


        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Lops = _Lop.GetAllLops;
            return View(_SinhVien.Create());
        }

        [HttpPost]
        public IActionResult Create(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                _SinhVien.Add(sinhVien);

                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var b = _SinhVien.Get(id);
            if (b == null)
                return NotFound();
            else
                return View(b);
        }

        [HttpPost]
        public IActionResult Delete(SinhVien sinhVien)
        {
            _SinhVien.Remove(sinhVien.IdSinhVien);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.Lops = _Lop.GetAllLops;
            return base.View(_SinhVien.Get(id));
        }

        [HttpPost]
        public IActionResult Edit(SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                //ViewBag.Lops = _Lop.GetAllLops;
                _SinhVien.Update(sinhVien);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Details(string id)
        {
            var sinhVien = _SinhVien.GetSinhVienById(id);
            if (sinhVien == null)
                return NotFound();
            else
                return View(sinhVien);
        }       
    }
}
