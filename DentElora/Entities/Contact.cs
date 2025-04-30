using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentElora.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Adres bilgisi gereklidir.")]
        [StringLength(250, ErrorMessage = "Adres 250 karakterden uzun olamaz.")]
        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon numarası gereklidir.")]
        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        [StringLength(20, ErrorMessage = "Telefon numarası 20 karakterden uzun olamaz.")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "E-posta adresi gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        [StringLength(100, ErrorMessage = "E-posta adresi 100 karakterden uzun olamaz.")]
        [Display(Name = "E-posta")]
        public string Email { get; set; }

        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        [Display(Name = "Harita")]
        public string? Map { get; set; }

        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        [StringLength(200, ErrorMessage = "URL 200 karakterden uzun olamaz.")]
        [Display(Name = "Instagram Hesabı")]
        public string? InstagramLink { get; set; }

        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        [StringLength(200, ErrorMessage = "URL 200 karakterden uzun olamaz.")]
        [Display(Name = "Facebook Hesabı")]
        public string? FacebookLink { get; set; }

        [Url(ErrorMessage = "Geçerli bir URL giriniz.")]
        [StringLength(200, ErrorMessage = "URL 200 karakterden uzun olamaz.")]
        [Display(Name = "Twitter Hesabı")]
        public string? TwitterLink { get; set; }
    }
}
