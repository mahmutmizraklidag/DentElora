using System.ComponentModel.DataAnnotations;

namespace DentElora.Entities
{
    public class FAQ
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Soru alanı gereklidir.")]
        [StringLength(200, ErrorMessage = "Soru en fazla 200 karakter olabilir.")]
        [Display(Name = "Soru")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Cevap alanı gereklidir.")]
        [DataType(DataType.MultilineText)]
        [StringLength(2000, ErrorMessage = "Cevap en fazla 2000 karakter olabilir.")]
        [Display(Name = "Cevap")]
        public string Answer { get; set; }
    }
}
