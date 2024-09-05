using _2024_staj_rehberUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace _2024_staj_rehberUygulamasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly  KisilerServisi _kisilerServisi;
        private readonly AppDbContext _context;  // Veritabaný baðlamýný tanýmladýk

        public JsonResult Kisiler { get; private set; }

        public HomeController(KisilerServisi kisilerServisi, AppDbContext context )
        {
            _kisilerServisi = kisilerServisi;
            _context = context;
        }

        public IActionResult Index()
        {
            var all = _context.Kisiler.OrderByDescending(x => x.Id).ToList();  // Veritabaný baðlamý kullanarak sorgulama yaptýk
            return View(all);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<JsonResult> Rehber(string Name, string Surname, string Address, string GSM, string Image)
        {
          

            await _kisilerServisi.AddRehberAsync(Name, Surname, Address, GSM, Image);

            return (Kisiler);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rehber>>> GetKisiler()
        {
            return await _context.Kisiler.ToListAsync();
        }
    }
}
