using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentElora.Entities
{
    public class AboutUs
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Başlık"),Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Display(Name = "Açıklama"), Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [StringLength(1000, ErrorMessage = "Açıklama en fazla 1000 karakter olabilir.")]
        public string Description { get; set; }

        [StringLength(255, ErrorMessage = "Resim yolu en fazla 255 karakter olabilir.")]
        public string? Image { get; set; }
    }
}