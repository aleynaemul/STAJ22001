using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace _2024_staj_rehberUygulamasi.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Rehber> Kisiler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost; Database=Rehber; User Id=sa; Password=Sa741852; TrustServerCertificate=True");
            optionsBuilder.EnableSensitiveDataLogging();

        }
    }

    public class Rehber
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string? GSM { get; set; }
        public string? Image { get; set; } // Base64 formatında resim verisi
    }
}
