using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentElora.Entities
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim Soyisim gereklidir.")]
        [StringLength(100, ErrorMessage = "İsim Soyisim en fazla 100 karakter olabilir.")]
        [Display(Name = "İsim Soyisim")]
        public string Name { get; set; }
       
        [StringLength(200, ErrorMessage = "Resim URL'si en fazla 200 karakter olabilir.")]
        [Display(Name = "Resim")]
        public string? Image { get; set; }
        [Display(Name = "Görevi")]
        public string? Role { get; set; }
    }
}