using System.ComponentModel.DataAnnotations;

namespace _2024_staj_rehberUygulamasi.Models
{
    public class Kisi
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Surname { get; set; }

        public string? Address { get; set; }

        [Required]

        public string? GSM { get; set; }
        public string? Image { get; set; }

       

        // Diğer gerekli alanlar
    }
}

