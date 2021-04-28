using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectA.Models;
using ProjectA.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectA.Controllers
{
    public class XetHocBongController : Controller
    {
        private readonly IXetHocBong _XetHocBong;
        private readonly ApplicationDbContext _context;
        public XetHocBongController(IXetHocBong XetHocBong, ApplicationDbContext context)
        {
            _XetHocBong = XetHocBong;
            _context = context;
        }

        public IActionResult Index()
        {
            var xetHocBong = _XetHocBong.DanhSachDatHocBong();
            return View(xetHocBong);
        }
    }
}
