using System.Collections.Generic;
using System.Threading.Tasks;
using _2024_staj_rehberUygulamasi.Models;
using Microsoft.EntityFrameworkCore;

namespace _2024_staj_rehberUygulamasi
{
    public class KisilerServisi
    {
        private readonly AppDbContext _context;

        public KisilerServisi(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddRehberAsync(string Name, string Surname, string Address, string GSM, string Image)
        {
            var kisi = new Rehber
            {
                Name = Name,
                Surname = Surname,
                Address = Address,
                GSM = GSM,
                Image= Image
            
            };

            _context.Kisiler.Add(kisi);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rehber>> GetAllKisilerAsync()
        {
            return await _context.Kisiler.ToListAsync();
        }
    }
}
