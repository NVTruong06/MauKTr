using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenVanTruong_241230874.Models;
using System.Diagnostics;

namespace NguyenVanTruong_241230874.Controllers
{
    public class HomeController : Controller
    {
        private readonly QltaiSanContext db;
        public HomeController(QltaiSanContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var taisanList = db.TaiSans.Where(s => s.NguyenGia != null && s.NguyenGia >= 20).ToList();
            return View(taisanList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.MaLoai = new SelectList(db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaiSan taisan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MaLoai = new SelectList(db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", taisan.MaLoai);
                return View(taisan);
            }
            db.TaiSans.Add(taisan);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = db.TaiSans.Find(id);

            ViewBag.MaLoai = new SelectList(db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", item.MaLoai);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaiSan taisan)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.MaLoai = new SelectList(db.LoaiTaiSans.ToList(), "MaLoai", "TenLoai", taisan.MaLoai);
                return View(taisan);
            }
            var ts = db.TaiSans.Find(id);
            ts.MaLoai = taisan.MaLoai;
            ts.TenTs = taisan.TenTs;
            ts.NguyenGia = taisan.NguyenGia;
            ts.Anh = taisan.Anh;

            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
