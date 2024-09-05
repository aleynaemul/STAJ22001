using Microsoft.AspNetCore.Mvc;
using _2024_staj_rehberUygulamasi.Models;
using Microsoft.EntityFrameworkCore;
namespace _2024_staj_rehberUygulamasi.Controllers
{
    public class KisiController : Controller
    {
        private readonly AppDbContext _context;

        public KisiController(AppDbContext context)
        {
            _context = context;
        }

        // Modal popup üzerinden kullanıcı eklemek için POST action
        //[HttpPost]
        //public async Task<IActionResult> AddKisi(Rehber rehber)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(rehber);
        //        await _context.SaveChangesAsync();
        //        return Json(new { success = true, rehber= rehber });
        //    }
        //    return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        //}

        [HttpPost]
        public async Task<IActionResult> AddKisi(Rehber rehber)
        {
            if (ModelState.IsValid)
            {
                // Resim Base64 olarak geldiği varsayımıyla
                _context.Add(rehber);
                await _context.SaveChangesAsync();
                return Json(new { success = true, rehber = rehber });
            }
            return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        [HttpGet]
        public IActionResult GetKisiler()
        {
            var kisiler = _context.Kisiler.ToList();
            return Json(kisiler);
        }


        [HttpPost]
        public async Task<IActionResult> KisiSil([FromForm] int kisiId)
        {
            var kisi = await _context.Kisiler.FirstOrDefaultAsync(k => k.Id == kisiId);
            if (kisi == null)
            {
                return BadRequest("Aradığınız kişi bulunamadı.");
            }
            else
            {
                _context.Kisiler.Remove(kisi);
                await _context.SaveChangesAsync();
                return Ok("Kişi Başarıyla Silindi.");
            }
        }
      
        [HttpPost]
        public async Task<IActionResult> EditKisi([FromBody] Kisi updatedKisi)
        {
            try
            {
                if (updatedKisi == null || updatedKisi.Id <=0)
                {
                    return BadRequest("Güncellenecek kişi bilgileri geçerli değil.");
                }

                var kisi = await _context.Kisiler.FindAsync(updatedKisi.Id);
                if (kisi == null)
                {
                    return Json(new { success = false, message = "Kişi bulunamadı" });
                }
               
                kisi.Name = updatedKisi.Name;
                kisi.Surname = updatedKisi.Surname;
                kisi.Address = updatedKisi.Address;
                kisi.GSM = updatedKisi.GSM;
                kisi.Image = updatedKisi.Image;

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Kişi başarıyla güncellendi" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}
