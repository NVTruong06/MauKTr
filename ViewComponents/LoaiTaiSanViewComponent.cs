using Microsoft.AspNetCore.Mvc;
using NguyenVanTruong_241230874.Models;

namespace NguyenVanTruong_241230874.ViewComponents
{
    public class LoaiTaiSanViewComponent : ViewComponent
    {
        private readonly QltaiSanContext db;
        public LoaiTaiSanViewComponent(QltaiSanContext context)
        {
            db = context;
        }
        public IViewComponentResult Invoke()
        {
            var loaiList = db.LoaiTaiSans.ToList();
            return View(loaiList);
        }
    }
}
