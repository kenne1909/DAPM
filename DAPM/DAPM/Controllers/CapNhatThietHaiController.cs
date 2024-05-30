using DAPM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAPM.Controllers
{
    public class CapNhatThietHaiController : Controller
    {
        private readonly DbLuLutHoaVangContext _context;
        public CapNhatThietHaiController(DbLuLutHoaVangContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var chiTietThietHai = await _context.TbChitietMucDoThietHais
                .Include(ch => ch.IdDotLuNavigation)
                .Include(ch => ch.IdMucDoNavigation)
                .Include(ch => ch.IdTaiKhoanNavigation)
                .ToListAsync();
            return View(chiTietThietHai);
        }
    }
}
