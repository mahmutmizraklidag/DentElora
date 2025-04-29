using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        [Display(Name = "Adres")]
        public string? Address { get; set; }
        [Display(Name = "Telelfon")]
        public string? Phone { get; set; }
        [Display(Name = "E-posta")]
        public string? Email { get; set; }
        [Display(Name = "Harita")]
        public string? Map { get; set; }
        [Display(Name = "Instagram Hesabı")]
        public string? InstagramLink { get; set; }
        [Display(Name = "Facebook Hesabı")]
        public string? FacebookLink { get; set; }
        [Display(Name = "Twitter Hesabı")]
        public string? TwitterLink { get; set; }
    }
}
